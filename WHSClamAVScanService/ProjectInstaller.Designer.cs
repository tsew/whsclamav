namespace WHSClamAVScanService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerWHSClamAVScan = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerWHSClamAVScan = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerWHSClamAVScan
            // 
            this.serviceProcessInstallerWHSClamAVScan.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerWHSClamAVScan.Password = null;
            this.serviceProcessInstallerWHSClamAVScan.Username = null;
            // 
            // serviceInstallerWHSClamAVScan
            // 
            this.serviceInstallerWHSClamAVScan.Description = "Scanning Service for WHSClamAV";
            this.serviceInstallerWHSClamAVScan.DisplayName = "WHSClamAV Scan";
            this.serviceInstallerWHSClamAVScan.ServiceName = "WHSClamAV Scan";
            this.serviceInstallerWHSClamAVScan.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceInstallerWHSClamAVScan.Committed += new System.Configuration.Install.InstallEventHandler(this.serviceInstallerWHSClamAVScan_Committed);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerWHSClamAVScan,
            this.serviceInstallerWHSClamAVScan});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerWHSClamAVScan;
        private System.ServiceProcess.ServiceInstaller serviceInstallerWHSClamAVScan;
    }
}