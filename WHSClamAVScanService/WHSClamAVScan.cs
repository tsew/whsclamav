using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1;
using Microsoft.HomeServer.SDK.Interop.v1;



namespace WHSClamAVScanService
{
    public partial class WHSClamAVScan : ServiceBase, INotificationCallback
    {
        ClamConfig ClamAVConfig;

        string scanSharePath = string.Empty;

        System.Timers.Timer timer = null;
        bool busy = false;

        public string pathToScan = string.Empty;

        WHSInfoClass pInfo = null;

        public WHSClamAVScan()
        {
            InitializeComponent();

            ClamAVConfig = new ClamConfig();

            timer = new System.Timers.Timer(60000); // check every minute
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

            pInfo = new WHSInfoClass();
            pInfo.Init("WHSClamAVService");

            pInfo.RegisterForNotifications(this);
        }

        private void serviceNotificationHandler()
        {
            throw new NotImplementedException();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool scanning_time = false;
            if (scanning_time)
                DoScan();
        }

        private void DoScan()
        {
            busy = true;
            timer.Stop();
            EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan service scan action fired", EventLogEntryType.Information);
            timer.Start();
            busy = false;
        }

        protected override void OnStart(string[] args)
        {
            string ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
            string Version = "WHSClamAV Scan Service was started.  Version: " + ver;
            EventLog.WriteEntry("WHSClamAV Scan", Version, EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            if (busy)
            {
                EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan service was busy scanning", EventLogEntryType.Information);
                KillScan();
            }

            EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan service was stopped", EventLogEntryType.Information);
        }

        protected override void OnPause()
        {
            EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan service was paused", EventLogEntryType.Information);
            timer.Stop();
        }

        protected override void OnContinue()
        {
            EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan service was continued", EventLogEntryType.Information);
            timer.Start();
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);

            switch (command)
            {
                case (int)ClamConfig.ServiceCommand.noop:
                    break;

                case (int)ClamConfig.ServiceCommand.scanMemory:
                    EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan started for Memory Scan", EventLogEntryType.Information); 
                    ScanMemory();
                    break;

                case (int)ClamConfig.ServiceCommand.scanSystem:
                    EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan started for System Scan (C:\\)", EventLogEntryType.Information);
                    ScanSystem();
                    break;

                case (int)ClamConfig.ServiceCommand.scanData:
                    EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan started for Data Scan (D:\\Shares\\)", EventLogEntryType.Information);
                    ScanData();
                    break;

                case (int)ClamConfig.ServiceCommand.scanCustom:
                    EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan started for Custom Scan", EventLogEntryType.Information);
                    ScanCustom();
                    break;

                case (int)ClamConfig.ServiceCommand.scanShare:
                    System.Threading.Thread.Sleep(3333); // Sleep to ensure the scan Path is updated
                    // Scanning for shares parameter is handled by notification
                    EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan started for Share Scan" + scanSharePath, EventLogEntryType.Information);
                    ScanShare(scanSharePath);
                    break;

                case (int)ClamConfig.ServiceCommand.kill:
                    EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan was commanded to Kill all running ClamAV processes", EventLogEntryType.Information);
                    KillScan();
                    break;

                default:
                    EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan command was not handled", EventLogEntryType.Information);
                    break;
            }
        }

        private void ScanSystem()
        {
            StartScan("C:\\");
        }

        private void ScanData()
        {
            StartScan("D:\\shares\\");
        }

        private void ScanCustom()
        {
            // Fetch custom drive paths
            // foreach (string path in Paths)
            // StartScan(pathToScan)
            // suppress log clearing between paths
            throw new NotImplementedException();
        }

        private void ScanShare(string path)
        {
            StartScan(path);
        }

        private void KillScan()
        {
            ClamConfig.FindAndKillProcess("clamav");
            ClamConfig.FindAndKillProcess("clamscan");
            ClamConfig.FindAndKillProcess("freshclam");
            ClamConfig.FindAndKillProcess("clamwin");
            ClamConfig.FindAndKillProcess("clamtray");
        }

        private void ScanMemory()
        {
            string command = ClamAVConfig.ReadClamConfigKey("clamscan");
            string options = "--memory" + " --database=\"" + ClamAVConfig.ReadClamConfigKey("database") + "\"";

            System.Diagnostics.Process scanMem = new System.Diagnostics.Process();
            scanMem.StartInfo.FileName = command;

            if (ClamAVConfig.ReadClamConfigKey("showprogress").Trim().Equals("1"))
                scanMem.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            else
                scanMem.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            scanMem.StartInfo.Arguments = options + " --log=\"" + ClamAVConfig.ReadClamConfigKey("logfile") + "\"";
            scanMem.StartInfo.WorkingDirectory = ClamAVConfig.ReadClamConfigKey("database");

            scanMem.EnableRaisingEvents = true;
            scanMem.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(scanMem_OutputDataReceived);
            scanMem.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(scanMem_ErrorDataReceived);
            scanMem.Exited += new EventHandler(scanMem_Exited);

            scanMem.Start();
        }

        void scanMem_Exited(object sender, EventArgs e)
        {
            EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan scanning completed", EventLogEntryType.Information);
            pInfo.AddNotification(ClamConfig.Notification.WHSClamScanCompleted, WHS_Notification_Severity.WHS_INFO,
                ClamConfig.Notification.WHSClamScanCompleted, ClamConfig.Notification.WHSClamScanCompleted, "", "", "");
        }

        void scanMem_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void scanMem_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start a Scan with the option of clearing the log file
        /// </summary>
        /// <param name="path">The file path to scan</param>

        private void StartScan(string path)
        {
            string command = ClamAVConfig.ReadClamConfigKey("clamscan");
            StringBuilder options = new StringBuilder();

            options.Append("--database=\"");
            options.Append(ClamAVConfig.ReadClamConfigKey("database"));
            options.Append("\" ");

            options.Append("--log=\"");
            options.Append(ClamAVConfig.ReadClamConfigKey("logfile"));
            options.Append("\" ");

            // Exclude c:\\fs  - remember double \ for string
            options.Append("--exclude-dir=c:\\\\fs ");

            if (ClamAVConfig.ReadClamConfigKey("infectedonly").Trim().Equals("1"))
                options.Append("--infected ");

            if (ClamAVConfig.ReadClamConfigKey("scanrecursive").Trim().Equals("1"))
                options.Append("--recursive=yes ");

            if (ClamAVConfig.ReadClamConfigKey("showprogress").Trim().Equals("1"))
                options.Append("--show-progress ");

            if (ClamAVConfig.ReadClamConfigKey("scanarchives").Trim().Equals("1"))
                options.Append("--scan-archive=yes ");
            else
                options.Append("--scan-archive=no ");

            if (ClamAVConfig.ReadClamConfigKey("enablembox").Trim().Equals("1"))
                options.Append("--scan-mail=yes ");
            else
                options.Append("--scan-mail=no ");

            if (ClamAVConfig.ReadClamConfigKey("scanole2").Trim().Equals("1"))
                options.Append("--scan-ole2=yes ");
            else
                options.Append("--scan-ole2=no ");

            if (ClamAVConfig.ReadClamConfigKey("moveinfected").Trim().Equals("1"))
            {
                options.Append("--move=\"");
                options.Append(ClamAVConfig.ReadClamConfigKey("quarantinedir"));
                options.Append("\" ");
            }

            options.Append("--exclude=\"");
            options.Append(ClamAVConfig.ReadClamConfigKey("excludepatterns"));
            options.Append("\" ");

            if (ClamAVConfig.ReadClamConfigKey("debug").Trim().Equals("1"))
                options.Append("--debug ");

            if (ClamAVConfig.ReadClamConfigKey("removeinfected").Trim().Equals("1"))
                options.Append("--remove=yes ");
            else
                options.Append("--remove=no ");

            options.Append(path);

            System.Diagnostics.Process scanDisk = new System.Diagnostics.Process();
            scanDisk.StartInfo.FileName = command;
            if (ClamAVConfig.ReadClamConfigKey("showprogress").Trim().Equals("1"))
                scanDisk.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            else
                scanDisk.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            scanDisk.StartInfo.Arguments = options.ToString();
            scanDisk.StartInfo.WorkingDirectory = ClamAVConfig.ReadClamConfigKey("database");

            scanDisk.EnableRaisingEvents = true;
            scanDisk.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(scanDisk_OutputDataReceived);
            scanDisk.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(scanDisk_ErrorDataReceived);
            scanDisk.Exited += new EventHandler(scanDisk_Exited);

            scanDisk.Start();

            switch (ClamAVConfig.ReadClamConfigKey("priority"))
            {
                case "Low":
                    scanDisk.PriorityClass = System.Diagnostics.ProcessPriorityClass.BelowNormal;
                    break;

                case "Med":
                    scanDisk.PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;
                    break;

                case "High":
                    scanDisk.PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal;
                    break;

                default:
                    scanDisk.PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;
                    break;
            }
        }

        void scanDisk_Exited(object sender, EventArgs e)
        {
            EventLog.WriteEntry("WHSClamAV Scan", "WHSClamAV Scan scanning completed", EventLogEntryType.Information);
            pInfo.AddNotification(ClamConfig.Notification.WHSClamScanCompleted, WHS_Notification_Severity.WHS_INFO, 
                ClamConfig.Notification.WHSClamScanCompleted, ClamConfig.Notification.WHSClamScanCompleted, "", "", "");
        }

        void scanDisk_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void scanDisk_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #region INotificationCallback Members

        public void BackupStateChanged(WHSBackupState State)
        {
            //throw new NotImplementedException();
        }

        public void Disconnected()
        {
            //throw new NotImplementedException();
        }

        public void NotificationChanged(string UniqueID, WHS_Notification_Type Type, WHS_Notification_Severity Severity, int IsSuppressed, string textHeader, string textDescription, string helpFilename, string helpSection, string helpLinkText)
        {
            switch (UniqueID)
            {
                case ClamConfig.Notification.WHSClamAVScanShare:
                    scanSharePath = textHeader;
                    break;

                default:
                    break;
            }
        }

        public void PhysicalDiskChanged(IDiskInfo pDiskInfo)
        {
            //throw new NotImplementedException();
        }

        public void ReConnected()
        {
            //throw new NotImplementedException();
        }

        public void UserInfoChanged()
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
