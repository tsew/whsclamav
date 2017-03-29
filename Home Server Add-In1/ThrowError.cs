using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    class ThrowError
    {
        public static void Throw (string message)
        {
            MessageBox.Show(message, "Clam AV Add-In");
        }

        public static void Throw(string message, string caption)
        {
            MessageBox.Show(message, caption);
        }
    }
}
