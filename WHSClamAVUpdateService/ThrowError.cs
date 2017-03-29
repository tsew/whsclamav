using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    class ThrowError
    {
        public static void Throw (string message)
        {
            EventLog.WriteEntry("WHSClamAV Service", message, EventLogEntryType.Error);
        }

        public static void Throw(string message, string caption)
        {
            EventLog.WriteEntry(caption, message, EventLogEntryType.Error);
        }
    }
}
