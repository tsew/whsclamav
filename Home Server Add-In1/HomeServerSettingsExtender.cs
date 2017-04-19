using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.HomeServer.Extensibility;
using System.Net;
using System.Xml;

namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    public class HomeServerSettingsExtender : ISettingsTab
    {
        private IConsoleServices consoleServices;
        private SettingsTabUserControl tabControl;

        public HomeServerSettingsExtender(int width, int height, IConsoleServices consoleServices)
        {
            this.consoleServices = consoleServices;

            tabControl = new SettingsTabUserControl(width, height, consoleServices);

            //Additional setup code here
        }

        public Guid SettingsGuid
        {
            get
            {
                return new Guid("032775ff-f451-40d7-997b-7ebbff56e136");
            }
        }

        public Control TabControl
        {
            get
            {
                return tabControl;
            }
        }

        public Bitmap TabImage
        {
            get
            {
                return Properties.Resources.ClamAV;
            }
        }

        public string TabText
        {
            get
            {
                return "WHS ClamAV";
            }
        }

        public bool Commit()
        {
            return false;
        }

        public bool GetHelp()
        {
            return false;
        }

    }

}
