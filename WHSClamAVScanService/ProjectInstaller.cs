using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;


namespace WHSClamAVScanService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstallerWHSClamAVScan_Committed(object sender, InstallEventArgs e)
        {
            System.ServiceProcess.ServiceController SC = new System.ServiceProcess.ServiceController("WHSClamAV Scan");
            SC.Start();
        }
    }
}
