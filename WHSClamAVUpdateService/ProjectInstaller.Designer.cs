namespace WHSClamAVUpdateService
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
            this.serviceProcessInstallerWHSClamAVUpdate = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerWHSClamAVUpdate = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerWHSClamAVUpdate
            // 
            this.serviceProcessInstallerWHSClamAVUpdate.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerWHSClamAVUpdate.Password = null;
            this.serviceProcessInstallerWHSClamAVUpdate.Username = null;
            // 
            // serviceInstallerWHSClamAVUpdate
            // 
            this.serviceInstallerWHSClamAVUpdate.Description = "Update Service for WHSClamAV";
            this.serviceInstallerWHSClamAVUpdate.DisplayName = "WHSClamAV Update";
            this.serviceInstallerWHSClamAVUpdate.ServiceName = "WHSClamAV Update";
            this.serviceInstallerWHSClamAVUpdate.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceInstallerWHSClamAVUpdate.Committed += new System.Configuration.Install.InstallEventHandler(this.serviceInstallerWHSClamAVUpdate_Committed);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerWHSClamAVUpdate,
            this.serviceInstallerWHSClamAVUpdate});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerWHSClamAVUpdate;
        private System.ServiceProcess.ServiceInstaller serviceInstallerWHSClamAVUpdate;
    }
}