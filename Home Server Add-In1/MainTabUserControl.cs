using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using Microsoft.HomeServer.Extensibility;
using Microsoft.HomeServer.Controls;
using Microsoft.HomeServer.HomeServerConsoleTab;
using Microsoft.HomeServer.Common.Client;
using Microsoft.HomeServer.SDK.Interop.v1;

namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    public partial class MainTabUserControl : UserControl
    {
        IConsoleServices consoleServices;

        Random n = new Random((int)DateTime.Now.Ticks);

        ClamConfig ClamAVConfig;

        WHSInfoClass pInfo = null;

        public MainTabUserControl()
        {
            InitializeComponent();
            ClamAVConfig = new ClamConfig();
            pInfo = new WHSInfoClass();
            pInfo.Init("WHSClamAV");
            PopulateSharesMenuItem();
        }

        private void PopulateSharesMenuItem()
        {
            Array shares = pInfo.GetShareInfo();

            shareToolStripMenuItem.DropDownItems.Clear();

            foreach (IShareInfo share in shares)
            {
                Image menuImage = null;
                // Todo:
                //if (shareIsInUserGroup(share.Name))
                //menuImage = CommonImages.GreenIcon;
                //else
                menuImage = CommonImages.GrayIcon;

                shareToolStripMenuItem.DropDownItems.Add(share.Name, menuImage, new EventHandler(SharesMenuItemClicked));
            }
        }

        void SharesMenuItemClicked(object sender, EventArgs e)
        {
            string shareName = sender.ToString();
            string sharePath = string.Empty;
            Array shares = pInfo.GetShareInfo2();
            foreach (IShareInfo2 share in shares)
            {
                if (share.Name.Equals(shareName))
                {
                    sharePath = share.Path;
                }
            }

            string pathName = string.Format("\"{0}\"", sharePath);
            StartScan(pathName);
        }

        private bool shareIsInUserGroup(string name)
        {

            if (n.Next(0, 2) == 1)
                return true;
            else
                return false;
        }

        public MainTabUserControl(int width, int height, IConsoleServices consoleServices)
            : this()
        {
            this.Width = width;
            this.Height = height;
            this.consoleServices = consoleServices;
        }

        private void MainTabUserControl_Load(object sender, EventArgs e)
        {
            LogScanPropertyPageNonEditableTextBoxField.Clear();
            LogUpdatePropertyPageNonEditableTextBoxField.Clear();
            ConfigFilePropertyPageNonEditableTextBoxField.Clear();

            LoadLogs();

            // MessageBox.Show(this.Parent.Size.ToString());

            // Set up size of control for non default sizes.
            LogTabControl.Width = this.Parent.Size.Width;
            LogTabControl.Height = this.Parent.Size.Height - LogTabControl.Top;

            LogStatusCheck();

            StopToolBarButton.Image = CommonImages.TaskFailure16;
        }

        private void LogStatusCheck()
        {
            QuarantineToolBarButton.Enabled = ClamConfig.IsInstalled();
            UpdateToolBarButton.Enabled = ClamConfig.IsInstalled();
            ScanToolBarButton.Enabled = ClamConfig.IsInstalled();
        }

        private void LoadLogs()
        {
            // Load the config first so we can get the log file locations
            LoadConfig();

            // Get Log File locations
            ClamAVConfig.GetLogFileLocations();

            LoadScanLog();
            LoadUpdateLog();
        }

        private void LoadConfig()
        {
            ConfigFilePropertyPageNonEditableTextBoxField.Text = ClamAVConfig.LoadLogFromFile(ClamAVConfig.ClamConfigFile);
            ConfigFilePropertyPageNonEditableTextBoxField.SelectionStart = ConfigFilePropertyPageNonEditableTextBoxField.Text.Length;
            ConfigFilePropertyPageNonEditableTextBoxField.ScrollToCaret();
        }

        private void LoadScanLog()
        {
            LogScanPropertyPageNonEditableTextBoxField.Text = ClamAVConfig.LoadLogFromFile(ClamAVConfig.ClamScanLogFile);
            LogScanPropertyPageNonEditableTextBoxField.SelectionStart = LogScanPropertyPageNonEditableTextBoxField.Text.Length;
            LogScanPropertyPageNonEditableTextBoxField.ScrollToCaret();
        }

        private void LoadUpdateLog()
        {
            LogUpdatePropertyPageNonEditableTextBoxField.Text = ClamAVConfig.LoadLogFromFile(ClamAVConfig.ClamUpdateLogFile);
            LogUpdatePropertyPageNonEditableTextBoxField.SelectionStart = LogUpdatePropertyPageNonEditableTextBoxField.Text.Length;
            LogUpdatePropertyPageNonEditableTextBoxField.ScrollToCaret();
        }


        private void UpdateScanLog()
        {
            LogScanPropertyPageNonEditableTextBoxField.Text +=
                ClamAVConfig.LoadLogFromFile(ClamAVConfig.ClamScanLogFile, LogScanPropertyPageNonEditableTextBoxField.Text.Length);
            LogScanPropertyPageNonEditableTextBoxField.SelectionStart = LogScanPropertyPageNonEditableTextBoxField.Text.Length;
            LogScanPropertyPageNonEditableTextBoxField.ScrollToCaret();
        }

        private void UpdateUpdateLog()
        {
            LogUpdatePropertyPageNonEditableTextBoxField.Text +=
                ClamAVConfig.LoadLogFromFile(ClamAVConfig.ClamUpdateLogFile, LogUpdatePropertyPageNonEditableTextBoxField.Text.Length);
            LogUpdatePropertyPageNonEditableTextBoxField.SelectionStart = LogUpdatePropertyPageNonEditableTextBoxField.Text.Length;
            LogUpdatePropertyPageNonEditableTextBoxField.ScrollToCaret();
        }

        void ActionButton_Click(object sender, EventArgs e)
        {
            OpenSettingsTab();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearAction();
        }

        private void ClearAction()
        {
            foreach (Control ctrl in LogTabControl.SelectedTab.Controls)
            {
                if (ctrl is PropertyPageNonEditableTextBoxField)
                {
                    PropertyPageNonEditableTextBoxField ppnedtf = ctrl as PropertyPageNonEditableTextBoxField;
                    ppnedtf.Clear();
                }
            }

            switch (LogTabControl.SelectedTab.Name)
            {
                case "LogScanTabPage":
                    ClamAVConfig.ClearClamLogFile(ClamAVConfig.ClamScanLogFile);
                    break;

                case "LogUpdateTabPage":
                    ClamAVConfig.ClearClamLogFile(ClamAVConfig.ClamUpdateLogFile);
                    break;

                case "ConfigFileTabPage":
                case "ClamWinVerTabPage":
                default:
                    ThrowError.Throw("Error in MainTabUserControl.ClearAction()");
                    break;

            }

            RefreshAction();

        }

        private void ClearToolBarButton_Click(object sender, EventArgs e)
        {
            ClearAction();
        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            ClearAction();
        }

        private void LogMessageListBox_Click(object sender, EventArgs e)
        {
            OpenSettingsTab();
        }

        private void OpenSettingsTab()
        {
            this.consoleServices.OpenSettings(new Guid("{032775ff-f451-40d7-997b-7ebbff56e136}"));
        }

        private void RefreshToolBarButton_Click(object sender, EventArgs e)
        {
            RefreshAction();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshAction();
        }

        private void RefreshAction()
        {
            switch (LogTabControl.SelectedTab.Name)
            {
                case "LogScanTabPage":
                    LoadScanLog();
                    break;

                case "LogUpdateTabPage":
                    LoadUpdateLog();
                    break;

                case "ConfigFileTabPage":
                    LoadConfig();
                    break;

                case "ClamWinVerTabPage":
                default:
                    ThrowError.Throw("Error in MainTabUserControl.RefreshAction()");
                    break;

            }
        }

        private void LogTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTabButtonStatus(LogTabControl.SelectedTab.Name);

            UpdateTabContents(LogTabControl.SelectedTab.Name);
        }

        private void UpdateTabContents(string TabName)
        {
            switch (TabName)
            {
                // Only enable updating for version log
                case "LogScanTabPage":
                case "LogUpdateTabPage":
                case "ConfigFileTabPage":
                    break;

                // Don't allow update or clearing of version status - not yet implemented.
                case "ClamWinVerTabPage":
                    RefreshVersionInformation();
                    break;

                default:
                    ThrowError.Throw("Error in MainTabUserControl.UpdateTabContents()");
                    break;
            }
        }

        private void RefreshVersionInformation()
        {
            VersionPropertyPageNonEditableTextBoxField.Text = ClamAVConfig.VersionAsString();
        }

        private void UpdateTabButtonStatus(string TabName)
        {
            switch (TabName)
            {
                // Only enabled clear button for Log files
                case "LogScanTabPage":
                case "LogUpdateTabPage":
                    RefreshToolBarButton.Enabled = true;
                    ClearToolBarButton.Enabled = true;
                    break;

                // Don't allow clearing of config
                case "ConfigFileTabPage":
                    RefreshToolBarButton.Enabled = true;
                    ClearToolBarButton.Enabled = false;
                    break;

                // Don't allow update or clearing of version status - not yet implemented.
                case "ClamWinVerTabPage":
                    RefreshToolBarButton.Enabled = false;
                    ClearToolBarButton.Enabled = false;
                    break;

                default:
                    ThrowError.Throw("Error in MainTabUserControl.UpdateTabButtonStatus()");
                    break;
            }
        }

        private void UpdateToolBarButton_Click(object sender, EventArgs e)
        {
            ServiceController sc = null;
            try
            {
                sc = new ServiceController(ClamConfig.Services.Update);
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                if (sc.Status != ServiceControllerStatus.Running)
                {
                    ThrowError.Throw("Update Service is not running: Service is " + sc.Status.ToString());
                    return;
                }
            }
            catch (Exception)
            {
                ThrowError.Throw("Update Service is not found on this machine");
                return;
            }


            // First disable update button
            EnableToolbarButtons(false);

            // Start showing updated log
            UpdateLogUpdateTimer.Enabled = true;
            LogTabControl.SelectTab("LogUpdateTabPage");

            ClearAction();

            try
            {
                sc.ExecuteCommand((int)ClamConfig.ServiceCommand.update);
            }
            catch (Exception)
            {
                ThrowError.Throw("Scanning Service is not found on this machine");
                return;
            }

        }

        private void QuarantineToolBarButton_Click(object sender, EventArgs e)
        {
            string quarDir = ClamAVConfig.ReadClamConfigKey("quarantinedir");
            //Open Quarantinne Directory in explorer
            if (Directory.Exists(quarDir))
                System.Diagnostics.Process.Start(quarDir);
        }

        private void ScanToolBarButton_Click(object sender, EventArgs e)
        {
            StartScan("C:\\");
        }

        private void ScanSharesToolBarButton_Click(object sender, EventArgs e)
        {
            StartScan("D:\\shares\\");
        }

        private void userDefinedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fetch custom drive paths
            // foreach (string path in Paths)
            // StartScan(pathToScan)
            // suppress log clearing between paths

            ThrowError.Throw("Not yet implemented");
        }

        private void StopToolBarButton_Click(object sender, EventArgs e)
        {
            ScanLogUpdateTimer.Stop();
            UpdateLogUpdateTimer.Stop();

            KillServiceThreads(ClamConfig.Services.Scan);
            KillServiceThreads(ClamConfig.Services.Update);

            System.Threading.Thread.Sleep(1000);

            ClamConfig.FindAndKillProcess("clamav");
            ClamConfig.FindAndKillProcess("clamscan");
            ClamConfig.FindAndKillProcess("freshclam");
            ClamConfig.FindAndKillProcess("clamwin");
            ClamConfig.FindAndKillProcess("clamtray");
        }

        private static void KillServiceThreads(string serviceName)
        {
            ServiceController sc = null;
            try
            {
                sc = new ServiceController(serviceName);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                sc.ExecuteCommand((int)ClamConfig.ServiceCommand.kill);
            }
            catch (Exception)
            {
                ThrowError.Throw("Service " + serviceName + " is not found on this machine");
                return;
            }

        }

        private void StartScan(string pathName)
        {
            ServiceController sc = null;
            try
            {
                sc = new ServiceController(ClamConfig.Services.Scan);
            }
            catch (Exception)
            {
                return;
            }

            EnableToolbarButtons(false);
            ScanLogUpdateTimer.Enabled = true;
            LogTabControl.SelectTab("LogScanTabPage");

            // Clear Update Log
            ClearAction();

            // Send our path to scan 
            pInfo.AddNotification(ClamConfig.Notification.WHSClamAVScanShare, WHS_Notification_Severity.WHS_INFO, pathName, pathName, "", "", "");
            try
            {
                sc.ExecuteCommand((int)ClamConfig.ServiceCommand.scanShare);
            }
            catch (Exception)
            {
                ThrowError.Throw("Scanning Service is not found on this machine");
                return;
            }

        }

        private void ScanMemoryToolBarButton_Click(object sender, EventArgs e)
        {
            ServiceController sc = null;
            try
            {
                sc = new ServiceController(ClamConfig.Services.Scan);
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                if (sc.Status != ServiceControllerStatus.Running)
                {
                    ThrowError.Throw("Scanning Service is not running: Service is " + sc.Status.ToString());
                    return;
                }
            }
            catch (Exception)
            {
                ThrowError.Throw("Scanning Service is not found on this machine");
                return;
            }

            EnableToolbarButtons(false);
            ScanLogUpdateTimer.Enabled = true;
            LogTabControl.SelectTab("LogScanTabPage");

            // Clear Update Log
            ClearAction();
            try
            {
                sc.ExecuteCommand((int)ClamConfig.ServiceCommand.scanMemory);
            }
            catch (Exception)
            {
                ThrowError.Throw("Scanning Service is not found on this machine");
                return;
            }

        }

        private void ScanDropDownButton_Click(object sender, EventArgs e)
        {
            PopulateSharesMenuItem();
        }

        private void ScanBackupToolBarButton_Click(object sender, EventArgs e)
        {
            StartScan("E:\\");
        }



        private void EnableToolbarButtons(bool value)
        {
            // Enable ClamAV operation buttons
            ScanMemoryToolBarButton.Enabled = value;
            ScanSharesToolBarButton.Enabled = value;
            ScanToolBarButton.Enabled = value;
            UpdateToolBarButton.Enabled = value;

            userDefinedToolStripMenuItem.Enabled = value;


            // Don't disable the shareToolStrip menu item - just all it's children
            // shareToolStripMenuItem.Enabled = value;
            shareToolStripMenuItem.Enabled = value;
            foreach (ToolStripMenuItem menuItem in shareToolStripMenuItem.DropDownItems)
                menuItem.Enabled = value;
            shareToolStripMenuItem.Enabled = true;

            // Do opposite for Stop button
            StopToolBarButton.Enabled = !value;
        }

        private void ScanLogUpdateTimer_Tick(object sender, EventArgs e)
        {
            //  Update Scan Log
            UpdateScanLog();
        }

        private void UpdateLogUpdateTimer_Tick(object sender, EventArgs e)
        {
            //  Update Update Log
            UpdateUpdateLog();
        }

        private void CheckClamAVComponentStatusTimer_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(@"E:\"))
                ScanBackupToolBarButton.Enabled = true;
            else
                ScanBackupToolBarButton.Enabled = false;

            // Update Warning in top right of window
            LogStatusCheck();

            if (ClamConfig.FindProcess("freshclam") || ClamConfig.FindProcess("clamscan"))
            {
                EnableToolbarButtons(false);
                if (ClamConfig.FindProcess("clamscan"))
                {
                    ClamScanStatusLabel.Text = "Scanner Running";
                    ClamScanStatusLabel.Image = CommonImages.GreenIcon32;
                    ClamScanStatusLabel.Enabled = true;

                    // If clamscan is running but we did not start it in the console then update the output
                    if (!ScanLogUpdateTimer.Enabled)
                        ScanLogUpdateTimer.Start();
                }
                else
                {
                    ClamScanStatusLabel.Text = "Scanner Idle";
                    ClamScanStatusLabel.Image = CommonImages.GrayIcon32;
                    ClamScanStatusLabel.Enabled = false;
                    ScanLogUpdateTimer.Stop();
                }
                if (ClamConfig.FindProcess("freshclam"))
                {
                    ClamUpdateStatusLabel.Text = "Updater Running";
                    ClamUpdateStatusLabel.Image = CommonImages.GreenIcon32;
                    ClamUpdateStatusLabel.Enabled = true;

                    // If freshclam is running but we did not start it in the console then update the output
                    if (!UpdateLogUpdateTimer.Enabled)
                        UpdateLogUpdateTimer.Start();
                }
                else
                {
                    ClamUpdateStatusLabel.Text = "Updater Idle";
                    ClamUpdateStatusLabel.Image = CommonImages.GrayIcon32;
                    ClamUpdateStatusLabel.Enabled = false;
                    UpdateLogUpdateTimer.Stop();
                }
            }
            else
            {
                EnableToolbarButtons(true);
                ClamScanStatusLabel.Text = "Scanner Idle";
                ClamScanStatusLabel.Image = CommonImages.GrayIcon32;
                ClamScanStatusLabel.Enabled = false;
                ClamUpdateStatusLabel.Text = "Updater Idle";
                ClamUpdateStatusLabel.Image = CommonImages.GrayIcon32;
                ClamUpdateStatusLabel.Enabled = false;
                UpdateLogUpdateTimer.Stop();
                ScanLogUpdateTimer.Stop();
            }
            ClamUpdateStatusLabel.Visible = true;
            ClamScanStatusLabel.Visible = true;
        }

        private void LogScanPropertyPageNonEditableTextBoxField_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
