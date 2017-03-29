using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.ServiceProcess;
using Microsoft.HomeServer.Extensibility;
using System.Diagnostics;
using System.Threading;
using Microsoft.HomeServer.Common.Client;
using Microsoft.HomeServer.SDK.Interop.v1;

namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    public partial class SettingsTabUserControl : UserControl
    {
        IConsoleServices consoleServices;
       
        delegate void UpdateProgessCallback(int BytesRead, int TotalBytes);

        public SettingsTabUserControl()
        {
            InitializeComponent();
        }

        public SettingsTabUserControl(int width, int height, IConsoleServices consoleServices)
            : this()
        {
            this.Width = width;
            this.Height = height;
            this.consoleServices = consoleServices;
        }

        private void SettingsTabUserControl_Load(object sender, EventArgs e)
        {
            // Check Status of ClamAV.
            CheckStatus();

            // Load Proxy Settings
            LoadProxySettings();

            // Update Service Status
            UpdateServiceStatus();
        }

        private void UpdateServiceStatus()
        {
            ServiceController scanService = null;
            ServiceController updateService = null;
            try
            {
                scanService = new ServiceController(ClamConfig.Services.Scan);
                updateService = new ServiceController(ClamConfig.Services.Update);
            }
            catch (Exception)
            {
                ServicesNotFound();
            }

            if (scanService == null)
            {
                ServicesNotFound();
                return;
            }
            if (updateService == null)
            {
                ServicesNotFound();
                return;
            }

            try
            {
                if (scanService.Status == ServiceControllerStatus.Running)
                {
                    ClamAVScanEnabledLabel.Image = CommonImages.GreenIcon;
                    ScanEnabledLabel("WHSClamAV Scan Enabled");
                    ClamAVScanEnableButton.Text = "Disable";
                }
                else
                {
                    ClamAVScanEnabledLabel.Image = CommonImages.RedIcon;
                    ScanEnabledLabel("WHSClamAV Scan Disabled");
                    ClamAVScanEnableButton.Text = "Enable";
                }
            }
            catch (Exception)
            {
                ServicesNotFound();
                return;
            }

            try
            {
                if (updateService.Status == ServiceControllerStatus.Running)
                {
                    ClamAVUpdateEnabledLabel.Image = CommonImages.GreenIcon;
                    UpdateEnabledLabel("WHSClamAV Update Enabled");
                    ClamAVUpdateEnableButton.Text = "Disable";
                }
                else
                {
                    ClamAVUpdateEnabledLabel.Image = CommonImages.RedIcon;
                    UpdateEnabledLabel("WHSClamAV Update Disabled");
                    ClamAVUpdateEnableButton.Text = "Enable";
                }
            }
            catch (Exception)
            {
                ServicesNotFound();
                return;
            }

            if (ServicePending(updateService))
                ClamAVUpdateEnabledLabel.Image = CommonImages.GrayIcon;

            if (ServicePending(scanService))
                ClamAVScanEnabledLabel.Image = CommonImages.GrayIcon;
        }

        private void ServicesNotFound()
        {
            ClamAVUpdateEnabledLabel.Image = CommonImages.RedIcon;
            UpdateEnabledLabel("WHSClamAV Update Service not found");

            ClamAVScanEnabledLabel.Image = CommonImages.RedIcon;
            ScanEnabledLabel("WHSClamAV Scan Service not found");

            ClamAVUpdateEnableButton.Enabled = false;
            ClamAVScanEnableButton.Enabled = false;
        }

        private bool ServicePending(ServiceController service)
        {
            switch (service.Status)
            {
                case ServiceControllerStatus.ContinuePending:
                case ServiceControllerStatus.PausePending:
                case ServiceControllerStatus.StartPending:
                case ServiceControllerStatus.StopPending:
                    return true;

                default:
                    return false;
            }
        }


        private void ClamAVEnableButton_Click(object sender, EventArgs e)
        {

        }

        private void ClamAVEnabledLabel_CheckedChanged(object sender, EventArgs e)
        {
            // We don't want any changes to the radio button by user clicks
            //ClamAVEnabledLabel.Checked = !ClamAVEnabledLabel.Checked;
        }


        private void ClamAVUpdateEnableButton_Click(object sender, EventArgs e)
        {
            if (ClamAVUpdateEnableButton.Text.Equals("Enable"))
            {
                if (EnableService(ClamConfig.Services.Update, true))
                {
                    ClamAVUpdateEnableButton.Text = "Disable";
                    UpdateEnabledLabel("WHSClamAV Update Enabled");
                    ClamAVUpdateEnabledLabel.Image = CommonImages.GreenIcon;
                }
            }
            else
            {
                if (EnableService(ClamConfig.Services.Update, false))
                {
                    ClamAVUpdateEnableButton.Text = "Enable";
                    UpdateEnabledLabel("WHSClamAV Update Disabled");
                    ClamAVUpdateEnabledLabel.Image = CommonImages.RedIcon;
                }
            }

        }

        private void ClamAVScanEnableButton_Click(object sender, EventArgs e)
        {
            if (ClamAVScanEnableButton.Text.Equals("Enable"))
            {
                if (EnableService(ClamConfig.Services.Scan, true))
                {
                    ClamAVScanEnableButton.Text = "Disable";
                    ScanEnabledLabel("WHSClamAV Scan Enabled");
                    ClamAVScanEnabledLabel.Image = CommonImages.GreenIcon;
                }
            }
            else
            {
                if (EnableService(ClamConfig.Services.Scan, false))
                {
                    ClamAVScanEnableButton.Text = "Enable";
                    ScanEnabledLabel("WHSClamAV Scan Disabled");
                    ClamAVScanEnabledLabel.Image = CommonImages.RedIcon;
                }
            }
        }

        private bool EnableService(string serviceName, Boolean enable)
        {
            ServiceController service = null;
            try
            {
                service = new ServiceController(serviceName);
            }
            catch (Exception)
            {
                return false;
            }

            if (enable)
                startService(service);
            else
                stopService(service);

            return true;
        }

        private void startService(ServiceController service)
        {
            switch (service.Status)
            {
                case ServiceControllerStatus.Running:
                case ServiceControllerStatus.StartPending:
                case ServiceControllerStatus.ContinuePending:
                case ServiceControllerStatus.StopPending:
                case ServiceControllerStatus.PausePending:
                    break;

                case ServiceControllerStatus.Paused:
                    service.Continue();
                    break;

                case ServiceControllerStatus.Stopped:
                    service.Start();
                    break;
            }
        }

        private void stopService(ServiceController service)
        {
            switch (service.Status)
            {
                case ServiceControllerStatus.Running:
                case ServiceControllerStatus.Paused:
                    service.Stop();
                    break;

                case ServiceControllerStatus.StartPending:
                case ServiceControllerStatus.PausePending:
                case ServiceControllerStatus.ContinuePending:
                    break;

                case ServiceControllerStatus.Stopped:
                case ServiceControllerStatus.StopPending:

                    break;
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            switch (DownloadButton.Text)
            {
                case "Download":
                    DoDownload();
                    break;

                case "Install":
                    DoInstall();
                    break;

                case "Remove":
                    DoRemove();
                    break;

                case "Upgrade":
                    DoUpgrade();
                    break;

                default:
                    break;
            }
        }

        private void DoDownload()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs upgrade of currently install ClamWin
        /// Basically we do a remove, download and install in one go
        /// </summary>
        private void DoUpgrade()
        {
            DoRemove();
            DoDownload();
            DoInstall();
        }

        private void DoRemove()
        {
            DownloadButton.Text = "Removing";
            DownloadButton.Enabled = false;

            string command = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ClamWin\\unins000.exe";

            System.Diagnostics.Process installer = new System.Diagnostics.Process();
            installer.StartInfo.FileName = command;
            installer.Start();

            installer.WaitForExit();

            CheckStatus();
        }

        private void CheckStatus()
        {
            // Check if installed clam files exist
            if (ClamConfig.IsInstalled())
            {
                if (ClamWinUpgradeAvailable())
                {
                    SetUpgrade();
                }
                else
                {
                    SetRemove();
                }
            }
            else if (DownloadOkay())
            {
                SetInstall();
            }
            else
            {
                SetDownload();
            }

            CheckEnabled();
        }

        /// <summary>
        /// Checks to see if there is an upgrade available
        /// </summary>
        /// <returns>True if an upgrade is available false if not</returns>
        private bool ClamWinUpgradeAvailable()
        {
            return false;
        }

        private void CheckEnabled()
        {
            UpdateServiceStatus();

            ClamConfig config = new ClamConfig();

            // Enable save button if we have clam config file
            ProxySaveButton.Enabled = File.Exists(config.ClamConfigFile);
        }

        private static bool DownloadOkay()
        {
            String file = ClamConfig.ClamAVInstallFile;
            if (File.Exists(file))
            {
                // File Exists but is it valid
                FileInfo fi = new FileInfo(file);
                if (fi.Length > 100000)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetDownload()
        {
            DownloadButton.Text = "Download";
            DownloadButton.Enabled = true;
            DeleteButton.Text = "Delete";
            DeleteButton.Visible = false;
            UpdateInstallLabel("ClamAV has not been downloaded");
            ClamAVInstallLabel.Image = CommonImages.RedIcon;
            DownloadProgressBar.Visible = false;
        }

        private void SetInstall()
        {
            DownloadButton.Text = "Install";
            DownloadButton.Enabled = true;
            DeleteButton.Text = "Delete";
            DeleteButton.Visible = true;
            UpdateInstallLabel("ClamAV is not installed   ");
            ClamAVInstallLabel.Image = CommonImages.YellowIcon;
            DownloadProgressBar.Visible = false;
        }

        private void SetRemove()
        {
            DownloadButton.Text = "Remove";
            DownloadButton.Enabled = true;
            DeleteButton.Text = "Delete";
            DeleteButton.Visible = false;
            UpdateInstallLabel("ClamAV is installed   ");
            ClamAVInstallLabel.Image = CommonImages.GreenIcon;
            DownloadProgressBar.Visible = false;
        }

        //Sec
        private void SetUpgrade()
        {
            DownloadButton.Text = "Remove";
            DownloadButton.Enabled = true;
            DeleteButton.Text = "Upgrade";
            DeleteButton.Visible = true;
            UpdateInstallLabel("ClamAV is installaed and can be upgraded");
            ClamAVInstallLabel.Image = CommonImages.YellowIcon;
            DownloadProgressBar.Visible = false;
        }
        
        private void DoInstall()
        {
            DownloadButton.Text = "Installing";
            DownloadButton.Enabled = false;

            // NOTB - no ask toolbaar 
            string command = ClamConfig.ClamAVInstallFile;
            string args = "/sp- /silent /norestart /NOTB";

            System.Diagnostics.Process installer = new System.Diagnostics.Process();
            installer.StartInfo.FileName = command;
            installer.StartInfo.Arguments = args;
            installer.Start();
            
            UpdateInstallLabel("Waiting to Kill Process FreshClam   ");

            // Thread.Sleep(3000);

            while (ClamConfig.WaitForProcess(installer.ProcessName))
                ClamConfig.FindAndKillProcess("freshclam");

            installer.WaitForExit();

            UpdateInstallLabel("Waiting to Kill Process ClamTray   ");

            while (ClamConfig.WaitForProcess("ClamTray"))
                ClamConfig.FindAndKillProcess("ClamTray");

            // Remove automatic start of ClamAV
            ClamConfig.RemoveRegistryKeys();

            // Set Quarantine option
            // Also remove warning for update
            try
            {
                ClamConfig clamConfig = new ClamConfig();
                clamConfig.WriteClamConfigKey("moveinfected", "1");
                clamConfig.WriteClamConfigKey("warnoutofdate", "0");
            }
            catch (Exception ex)
            {
                ThrowError.Throw(ex.Message);
            }

            CheckStatus();
        }

        private void UpdateLabel(string message, Control ctrl)
        {
            ctrl.Text = message;
            ctrl.Refresh();
        }

        private void UpdateInstallLabel(String message)
        {
            UpdateLabel(message, ClamAVInstallLabel);
        }

        private void UpdateEnabledLabel(String message)
        {
            UpdateLabel(message, ClamAVUpdateEnabledLabel);
        }

        private void ScanEnabledLabel(String message)
        {
            UpdateLabel(message, ClamAVScanEnabledLabel);
        }

        private void UpdateProgress(int BytesRead, int TotalBytes)
        {
            // Calculate the download progress in percentages
            Int32 PercentProgress = Convert.ToInt32((BytesRead * 100) / TotalBytes);
            // Make progress on the progress bar
            DownloadProgressBar.Value = BytesRead;
            // Display the current progress on the form
            UpdateInstallLabel("Downloading ClamAV - " + BytesRead.ToString() + " (" + PercentProgress + "%) ");

            // Set the LED to Gray
            if ((PercentProgress & 2) == 0)
            {
                ClamAVInstallLabel.Image = CommonImages.GrayIcon;
            }
            else
            {
                ClamAVInstallLabel.Image = CommonImages.GreenIcon;
            }

            ClamAVInstallLabel.Refresh();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(ClamConfig.ClamAVInstallFile))
            {
                File.Delete(ClamConfig.ClamAVInstallFile);
            }

            CheckStatus();
        }

        private void ProxySaveButton_Click(object sender, EventArgs e)
        {
            ClamConfig config = new ClamConfig();

            // Check if config file exists
            if (!File.Exists(config.ClamConfigFile))
            {
                ThrowError.Throw("ClamAV Config File does not exist\nHave you installed ClamAV?");
                return;
            }

            // Check Fields
            if (String.IsNullOrEmpty(ProxyServerTextBox.Text.Trim()) && !String.IsNullOrEmpty(ProxyUserTextBox.Text.Trim()))
            {
                ProxyServerTextBox.BackColor = Color.Red;
                return;
            }

            if (String.IsNullOrEmpty(ProxyUserTextBox.Text.Trim()) && !String.IsNullOrEmpty(ProxyPasswordTextBox.Text.Trim()))
            {
                ProxyUserTextBox.BackColor = Color.Red;
                return;
            }

            if (!String.IsNullOrEmpty(ProxyPortTextBox.Text))
            {
                try
                {
                    Int32 port = Int32.Parse(ProxyPortTextBox.Text);
                    if (port < 0 || port > 65535)
                    {
                        ProxyPortTextBox.BackColor = Color.Red;
                        return;
                    }
                }
                catch (Exception)
                {
                    ProxyPortTextBox.BackColor = Color.Red;
                    return;
                }
            }

            // All okay so clear all errors
            ProxyServerTextBox.BackColor = Color.White;
            ProxyPortTextBox.BackColor = Color.White;
            ProxyUserTextBox.BackColor = Color.White;
            ProxyPasswordTextBox.BackColor = Color.White;

            // Save Fields
            config.WriteClamConfigKey("host", ProxyServerTextBox.Text.ToString().Trim());
            config.WriteClamConfigKey("port", ProxyPortTextBox.Text.ToString().Trim());
            config.WriteClamConfigKey("user", ProxyUserTextBox.Text.ToString().Trim());
            config.WriteClamConfigKey("password", ProxyPasswordTextBox.Text.ToString().Trim());

            //Disable Save Button
            ProxySaveButton.Enabled = false;
        }

        private void ProxyServerTextBox_TextChanged(object sender, EventArgs e)
        {
            ProxyServerTextBox.BackColor = Color.White;
            ProxySaveButton.Enabled = true;
        }

        private void ProxyPortTextBox_TextChanged(object sender, EventArgs e)
        {
            ProxyPortTextBox.BackColor = Color.White;
            ProxySaveButton.Enabled = true;
        }

        private void ProxyUserTextBox_TextChanged(object sender, EventArgs e)
        {
            ProxyUserTextBox.BackColor = Color.White;
            ProxySaveButton.Enabled = true;
        }

        private void ProxyPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            ProxyPasswordTextBox.BackColor = Color.White;
            ProxySaveButton.Enabled = true;
        }

        private void LoadProxySettings()
        {
            ClamConfig config = new ClamConfig();

            ProxyServerTextBox.Text = config.ReadClamConfigKey("host");
            ProxyPortTextBox.Text = config.ReadClamConfigKey("port");
            ProxyUserTextBox.Text = config.ReadClamConfigKey("user");
            ProxyPasswordTextBox.Text = config.ReadClamConfigKey("password");
        }

        private void serviceUpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateServiceStatus();
        }

    }
}
