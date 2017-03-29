
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using Microsoft.HomeServer.SDK.Interop.v1;

using Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1;


namespace WHSClamAVUpdateService
{

    public partial class WHSClamAVUpdate : ServiceBase, INotificationCallback
    {
        System.Timers.Timer timer = null;
        ClamConfig ClamAVConfig = null;
        WHSInfo pInfo = null;

        // Counter to decrement for webCheck - intial setting check every hour, units are tens of seconds 
        public const int DEFAULT_WEB_CHECK_INTERVAL = 2;
        int WebCheckInterval = DEFAULT_WEB_CHECK_INTERVAL;

        DateTime lastUpdate = DateTime.MinValue;

        Boolean hasAlertDefinitionsOutOfDate = false;
        Boolean hasAlertAddinOutOfDate = false;
        Boolean hasAlertClamWinOutOfDate = false;
        Boolean hasAlertNotInstalled = false;
        Boolean hasAlertVirusFound = false;

        public WHSClamAVUpdate()
        {
            InitializeComponent();
            ClamAVConfig = new ClamConfig();
            // Set up WHSInfo and register for notifications
            pInfo = new WHSInfo();
            pInfo.RegisterForNotifications(this);

            timer = new System.Timers.Timer();

            lastUpdate = DateTime.Now;
        }

        protected override void OnStart(string[] args)
        {
            // Update WHSClamAV
            string ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
            string Version = "WHSClamAV Update Service was started.  Version: " + ver;
            EventLog.WriteEntry("WHSClamAV Update", Version, EventLogEntryType.Information);

            // Sleep for a while (10 Seconds)
            timer.Interval = (10 * 1000);
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            LogStatusCheck();
            if (TimeToDoUpdate())
            {
                EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update service automatic update triggered", EventLogEntryType.Information);
                DoUpdate();
            }
        }

        private bool TimeToDoUpdate()
        {
            // Do update every 7 hours 7 minutes and 7 seconds
            if (DateTime.Now > lastUpdate.AddHours(7).AddMinutes(7).AddSeconds(7))
            {
                lastUpdate = DateTime.Now;
                return true;
            }
            else
                return false;
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update service was stopped", EventLogEntryType.Information);
            timer.Stop();
        }

        protected override void OnPause()
        {
            EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update service was paused", EventLogEntryType.Information);
            timer.Stop();
        }

        protected override void OnContinue()
        {
            EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update service was continued", EventLogEntryType.Information);
            timer.Start();
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);

            switch (command)
            {
                case (int)ClamConfig.ServiceCommand.noop:
                    break;

                case (int)ClamConfig.ServiceCommand.update:
                    EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update service was instructed to perform update by command", EventLogEntryType.Information);
                    DoUpdate();
                    break;

                case (int)ClamConfig.ServiceCommand.kill:
                    EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update service was instructed to kill the update process", EventLogEntryType.Information);
                    DoKill();
                    break;

                default:
                    ThrowError.Throw("Invalid Command at WHSClamAVUpdate:OnCustomCommand()");
                    break;
            }
        }

        private void DoKill()
        {
            Process[] processes = Process.GetProcessesByName("freshclam");
            if (processes == null)
            {
                EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update didn't find freshclam process to kill", EventLogEntryType.Information);
                return;
            }
            foreach (Process fc in processes)
            {
                EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update service killed freshclam process", EventLogEntryType.Information);
                fc.Kill();
            }
        }

        private void DoUpdate()
        {
            // Create FreshClam.Conf File

            // Get location of current config file
            FileInfo configFile = new FileInfo(ClamAVConfig.ClamConfigFile);
            string freshClamConfFile = configFile.DirectoryName + "\\FreshClam.conf";

            // Delete config if it already exists
            if (File.Exists(freshClamConfFile))
                File.Delete(freshClamConfFile);

            // Use the path of the config file for the location of FreshClam.conf
            using (TextWriter freshClamConf = new StreamWriter(freshClamConfFile))
            {
                freshClamConf.WriteLine("# FreshClam.conf file created by ClamAV WHS Add-in " + DateTime.Now.ToString());
                freshClamConf.WriteLine("#");
                freshClamConf.WriteLine("DatabaseMirror " + ClamAVConfig.ReadClamConfigKey("dbmirror"));
                freshClamConf.WriteLine("#");
                freshClamConf.WriteLine("MaxAttempts 3");
                freshClamConf.WriteLine("#");

                // Direct to log file
                freshClamConf.WriteLine("UpdateLogFile " + ClamAVConfig.ReadClamConfigKey("dbupdatelogfile"));
                freshClamConf.WriteLine("#");

                // Setup proxy if required
                if (!string.IsNullOrEmpty(ClamAVConfig.ReadClamConfigKey("host")))
                {
                    freshClamConf.WriteLine("HTTPProxyServer " + ClamAVConfig.ReadClamConfigKey("host"));
                    if (!string.IsNullOrEmpty(ClamAVConfig.ReadClamConfigKey("port")))
                        freshClamConf.WriteLine("HTTPProxyPort " + ClamAVConfig.ReadClamConfigKey("port"));
                    if (!string.IsNullOrEmpty(ClamAVConfig.ReadClamConfigKey("user")))
                        freshClamConf.WriteLine("HTTPProxyUsername " + ClamAVConfig.ReadClamConfigKey("user"));
                    if (!string.IsNullOrEmpty(ClamAVConfig.ReadClamConfigKey("password")))
                        freshClamConf.WriteLine("HTTPProxyPassword " + ClamAVConfig.ReadClamConfigKey("password"));
                }
                freshClamConf.WriteLine("# End");
                // Write and Close compelted by end of using
            }

            // Run Fresh Clam

            // Update status

            string command = ClamAVConfig.ReadClamConfigKey("freshclam");
            string args = "--config-file=\"" + freshClamConfFile + "\"";
            args += " --datadir=\"" + ClamAVConfig.ReadClamConfigKey("database") + "\"";

            System.Diagnostics.Process freshClam = new System.Diagnostics.Process();
            freshClam.StartInfo.FileName = command;
            freshClam.StartInfo.Arguments = args;
            freshClam.Exited += new EventHandler(freshClam_Exited);
            freshClam.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(freshClam_OutputDataReceived);
            freshClam.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(freshClam_ErrorDataReceived);
            freshClam.EnableRaisingEvents = true;
            freshClam.Start();

            switch (ClamAVConfig.ReadClamConfigKey("priority"))
            {
                case "Low":
                    freshClam.PriorityClass = System.Diagnostics.ProcessPriorityClass.BelowNormal;
                    break;

                case "Med":
                    freshClam.PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;
                    break;

                case "High":
                    freshClam.PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal;
                    break;

                default:
                    freshClam.PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;
                    break;
            }
        }

        void freshClam_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {

        }

        void freshClam_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
        }

        void freshClam_Exited(object sender, EventArgs e)
        {
            EventLog.WriteEntry("WHSClamAV Update", "WHSClamAV Update completed an update process", EventLogEntryType.Information);
            pInfo.AddNotification(ClamConfig.Notification.WHSClamAVUpdateCompleted, 
                WHS_Notification_Severity.WHS_INFO, 
                ClamConfig.Notification.WHSClamAVUpdateCompleted, 
                ClamConfig.Notification.WHSClamAVUpdateCompleted, "", "", "");
        }

        private void LogStatusCheck()
        {
            if (!ClamConfig.IsInstalled())
            {
                LogStatusInstall();
            }
            else
            {
                if (hasAlertNotInstalled)
                {
                    pInfo.RemoveNotification("WHSClamAV-ClamWinNotInstalled");
                    hasAlertNotInstalled = false;
                }
            }

            // If virus found
            string quarDir = ClamAVConfig.ReadClamConfigKey("quarantinedir");
            if (Directory.Exists(quarDir))
            {
                if (Directory.GetFiles(quarDir).Length > 0)
                {
                    LogStatusVirus();
                }
                else if (hasAlertVirusFound)
                {
                    pInfo.RemoveNotification("WHSClamAV-Virus-Found");
                    hasAlertVirusFound = false;
                }
            }
            else if (hasAlertVirusFound)
            {
                pInfo.RemoveNotification("WHSClamAV-Virus-Found");
                hasAlertVirusFound = false;
            }

            // If not updated for more than 24 hours
            string defDir = ClamAVConfig.ReadClamConfigKey("database");
            if (Directory.Exists(defDir))
            {
                string[] files = Directory.GetFiles(defDir);
                DateTime lastAccess = DateTime.MinValue;
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.LastWriteTime > lastAccess)
                        lastAccess = fileInfo.LastWriteTime;
                }
                // If definition are more than 3 days old then raise the error
                if (lastAccess < DateTime.Now.AddDays(-3.0))
                {
                    LogStatusDefinitionsUpdate();
                }
                else if (hasAlertDefinitionsOutOfDate)
                {
                    pInfo.RemoveNotification("WHSClamAV-Definitions-OutOfDate");
                    hasAlertDefinitionsOutOfDate = false;
                }
            }
            else if (hasAlertDefinitionsOutOfDate)
            {
                pInfo.RemoveNotification("WHSClamAV-Definitions-OutOfDate");
                hasAlertDefinitionsOutOfDate = false;
            }

            // REMOVEBEFOREBUILD

            WebCheckInterval--;
            if (WebCheckInterval < 1)
            {
                WebCheckInterval = DEFAULT_WEB_CHECK_INTERVAL * 10000; // Ensure we don't fire until the next interval has passed
                DoWebCheck();
            }
        
        }

        private void DoWebCheck()
        {
            // Check version of ClamWin installed against that on the web
            Fetch.GetClamWinURL();
            Fetch.GetClamWinVersion();
            CheckClamWinVersion();
            CheckAddInVersion();
        }
                
        private void CheckClamWinVersion()
        {
            throw new NotImplementedException();
        }

        private void CheckAddInVersion()
        {
            throw new NotImplementedException();
        }

                
        private void LogStatusVirus()
        {
            hasAlertVirusFound = true;
            pInfo.AddNotification(
                "WHSClamAV-Virus-Found",
                WHS_Notification_Severity.WHS_WARNING,
                "WHSClamAV: Virus Found",
                "Please see the quarantine directory for the found virus(es).",
                "", "", "");
        }

        private void LogStatusDefinitionsUpdate()
        {
            hasAlertDefinitionsOutOfDate = true;
            pInfo.AddNotification(
                "WHSClamAV-Definitions-OutOfDate",
                WHS_Notification_Severity.WHS_WARNING,
                "WHSClamAV: Virus Definitions Out Of Date",
                "Please manually update the virus definitions.",
                "", "", "");
        }

        private void LogStatusAddinUpdate()
        {
            hasAlertDefinitionsOutOfDate = true;
            pInfo.AddNotification(
                "WHSClamAV-Addin-OutOfDate",
                WHS_Notification_Severity.WHS_WARNING,
                "WHSClamAV: Newer version of WHSClamAV available",
                "An update to the WHSClamAV Add-In is available.  You may download a new version from SourceForge or use AddInCentral to update.",
                "", "", "");
        }

        private void LogStatusClamWinUpdate()
        {
            hasAlertDefinitionsOutOfDate = true;
            pInfo.AddNotification(
                "WHSClamAV-ClamWin-OutOfDate",
                WHS_Notification_Severity.WHS_WARNING,
                "WHSClamAV: Newer version of ClamWin availble",
                "A newer version of ClamWin has been detected.  The update will be automatically applied in the next 24 hours or you many manually apply the update.",
                "", "", "");
        }

        private void LogStatusInstall()
        {
            hasAlertNotInstalled = true;
            pInfo.AddNotification(
                "WHSClamAV-ClamWinNotInstalled",
                WHS_Notification_Severity.WHS_WARNING,
                "WHSClamAV: ClamWin Not Installed",
                "In order to have functional virus scanning ClamWin needs to be installed.",
                "", "", "");
        }

        #region INotificationCallback Members

        public void BackupStateChanged(WHSBackupState State)
        {
            // throw new NotImplementedException();
        }

        public void Disconnected()
        {
           //  throw new NotImplementedException();
        }

        public void NotificationChanged(string UniqueID, WHS_Notification_Type Type, WHS_Notification_Severity Severity, int IsSuppressed, string textHeader, string textDescription, string helpFilename, string helpSection, string helpLinkText)
        {
           // throw new NotImplementedException();
        }

        public void PhysicalDiskChanged(IDiskInfo pDiskInfo)
        {
           // throw new NotImplementedException();
        }

        public void ReConnected()
        {
           // throw new NotImplementedException();
        }

        public void UserInfoChanged()
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
