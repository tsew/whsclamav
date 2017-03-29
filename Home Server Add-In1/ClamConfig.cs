using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    class ClamConfig
    {
        private static string DefaultClamConfigFile =
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ClamWin\\bin\\ClamWin.conf";
        private static string DefaultClamScanLogFile =
            Environment.GetEnvironmentVariable("AllUsersProfile") + "\\.clamwin\\log\\ClamScanLog.txt";
        private static string DefaultClamUpdateLogFile =
            Environment.GetEnvironmentVariable("AllUsersProfile") + "\\.clamwin\\log\\ClamUpdateLog.txt";
        private static string DefaultClamVersionURI =
            @"http://whsclamav.sourceforge.net/version.php";

        private static string ClamScanBinary = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ClamWin\\bin\\clamscan.exe";

        public static String ClamAVInstallFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\clamav.exe";

        private string _ClamConfigFile;
        private string _ClamScanLogFile;
        private string _ClamUpdateLogFile;
        private string _ClamVersionURI;

        public string ClamConfigFile { get { return _ClamConfigFile; } }
        public string ClamScanLogFile { get { return _ClamScanLogFile; } }
        public string ClamUpdateLogFile { get { return _ClamUpdateLogFile; } }
        public string ClamVersionURI { get { return _ClamVersionURI; } }

        public enum ServiceCommand { noop = 0, update = 249, scanMemory, scanSystem, scanData, scanCustom, scanShare, kill }


        public static class Notification
        {
            public const string WHSClamScanCompleted = @"WHSClamAV-Scan-Completed";
            public const string WHSClamScanStarted = @"WHSClamAV-Scan-Started";
            public const string WHSClamAVScanShare = @"WHSClamAV-Scan-Share";
            public const string WHSClamAVUpdateCompleted = @"WHSClamAV-Update-Completed";
        }

        public static class Services
        {
            public const string Scan = @"WHSClamAV Scan";
            public const string Update = @"WHSClamAV Update";

        }

        public ClamConfig()
        {
            _ClamConfigFile = DefaultClamConfigFile;
            _ClamScanLogFile = DefaultClamScanLogFile;
            _ClamUpdateLogFile = DefaultClamUpdateLogFile;
            _ClamVersionURI = DefaultClamVersionURI;
        }

        public ClamConfig(string ConfigFile)
        {
            _ClamConfigFile = ConfigFile;
            _ClamScanLogFile = DefaultClamScanLogFile;
            _ClamUpdateLogFile = DefaultClamUpdateLogFile;
            _ClamVersionURI = DefaultClamVersionURI;
        }

        public static bool IsInstalled()
        {
            return File.Exists(ClamScanBinary);
        }

        public string VersionAsString()
        {
            StringBuilder verInfo = new StringBuilder();
            string appName = System.Reflection.Assembly.GetAssembly(this.GetType()).Location;
            System.Reflection.AssemblyName assemblyName = System.Reflection.AssemblyName.GetAssemblyName(appName);

            string assemblyShortName = assemblyName.Name.Split('.')[1];

            verInfo.Append(assemblyShortName);
            verInfo.AppendLine(" Version Information");

            verInfo.AppendLine();

            verInfo.Append("Location: ");
            verInfo.AppendLine(appName);

            verInfo.Append("Version: ");
            verInfo.AppendLine(assemblyName.Version.ToString());

            verInfo.Append("Culture: ");
            verInfo.AppendLine(assemblyName.CultureInfo.EnglishName);

            verInfo.AppendLine();
            verInfo.Append("Clam AV Version: ");
            verInfo.AppendLine(this.ReadClamConfigKey("version"));

            return verInfo.ToString();
        }

        public void ClearClamLogFile(string fileName)
        {
            // Create new blank file and insert time stamp and save.
            StringBuilder tempLog = new StringBuilder();

            tempLog.Append("Log File Cleared From ClamAV Add-In Console Operation on ");
            tempLog.AppendLine(DateTime.Now.ToString());
            tempLog.AppendLine("--------------------------------------------------------------------------------------------------");

            try
            {
                TextWriter logFile = new StreamWriter(fileName);
                logFile.Write(tempLog.ToString());
                logFile.Close();
            }
            catch (Exception)
            {
                // ThrowError.Throw(ex.Message);
            }
        }

        public void WriteClamLogFile()
        {
            throw new NotImplementedException();
        }

        public string ReadClamConfigKey(string key)
        {
            string line = string.Empty;

            // If can't open config file return empty string
            if (!File.Exists(_ClamConfigFile))
                return string.Empty;

            using (TextReader configFile = new StreamReader(_ClamConfigFile))
            {
                while ((line = configFile.ReadLine()) != null)
                {
                    // If found return first instance
                    if (line.StartsWith(key))
                        return line.Split('=')[1].Trim();
                }
            }

            // If not found return empty string
            return string.Empty;
        }

        public void WriteClamConfigKey(string key, string value)
        {
            // Read config file up until key into string buffer
            StringBuilder tempConfig = new StringBuilder();
            string line;
            bool needWrite = false;
            // If config file does not exist return
            if (!File.Exists(_ClamConfigFile))
                return;

            try
            {
                using (TextReader configFile = new StreamReader(_ClamConfigFile))
                {
                    while ((line = configFile.ReadLine()) != null)
                    {
                        // If found return first instance
                        if (line.StartsWith(key))
                        {
                            // Check to see if new key is same as old - if so skip write
                            string writeKey = key + " = " + value;
                            if (!line.Equals(writeKey))
                            {
                                tempConfig.AppendLine(writeKey);
                                needWrite = true;
                            }
                        }
                        else
                        {
                            tempConfig.AppendLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowError.Throw(ex.Message);
            }

            if (!needWrite)
                return;

            try
            {
                using (TextWriter newConfigFile = new StreamWriter(_ClamConfigFile))
                {
                    newConfigFile.Write(tempConfig.ToString());
                }
            }
            catch (Exception ex)
            {
                ThrowError.Throw(ex.Message);
            }
        }

        public void GetLogFileLocations()
        {
            // Read the log file for:
            //              logfile         - scan log file     default: C:\Documents and Settings\All Users\.clamwin\log\ClamScanLog.txt
            //              dbupdatelogfile - update log file   default: C:\Documents and Settings\All Users\.clamwin\log\ClamUpdateLog.txt

            string logfile = ReadClamConfigKey("logfile");

            if (string.IsNullOrEmpty(logfile))
                _ClamScanLogFile = DefaultClamScanLogFile;
            else
                _ClamScanLogFile = logfile;

            string updatefile = ReadClamConfigKey("dbupdatelogfile");

            if (string.IsNullOrEmpty(updatefile))
                _ClamUpdateLogFile = DefaultClamUpdateLogFile;
            else
                _ClamUpdateLogFile = updatefile;

            return;
        }

        public String LoadLogFromFile(String filename)
        {
            return LoadLogFromFile(filename, 0);
        }

        public String LoadLogFromFile(String filename, int start)
        {
            return LoadLogFromFile(filename, (long)start);
        }

        public String LoadLogFromFile(String filename, long start)
        {
            // This function will read from a start point - useful when we are updating a long text file

            StringBuilder log = new StringBuilder();
            try
            {
                //TextReader logFile = new StreamReader(filename);

                if (!File.Exists(filename))
                {
                    // If ClamConfig is not installed then return;
                    if (!File.Exists(ClamConfig.DefaultClamConfigFile))
                        return "ClamWin not installed - go to settings and Download then Install ClamWin\r\n";
                    // It does so clear the file - this actually creates a new file and inserts a time stamp
                    ClearClamLogFile(filename);
                }

                FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Write);
                fs.Seek(start, 0);
                for (long i = 0; i < (fs.Length - start); i++)
                    log.Append((char)fs.ReadByte());
                fs.Close();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return log.ToString();
        }

        public static Boolean WaitForProcess(string name)
        {
            // Wait until we detect the thread
            Boolean ProcessFound = WaitForProcessInner(name);
            // Then wait a further 3 seconds
            Thread.Sleep(1000);
            return ProcessFound;
        }

        private static Boolean WaitForProcessInner(string name)
        {
            Boolean ProcessFound = false;
            int DeciSecondsToWait = 15, WaitedTime = 0;

            while (!ProcessFound && WaitedTime < DeciSecondsToWait)
            {
                // Lets wait one second for the process to come alive
                Thread.Sleep(100);
                WaitedTime++;

                //here we're going to get a list of all running processes on
                //the computer
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    //now we're going to see if any of the running processes
                    //match the currently running processes by using the StartsWith Method,
                    //this prevents us from incluing the .EXE for the process we're looking for.
                    //. Be sure to not
                    //add the .exe to the name you provide, i.e: NOTEPAD,
                    //not NOTEPAD.EXE or false is always returned even if
                    //notepad is running
                    if (clsProcess.ProcessName.StartsWith(name))
                    {
                        //since we found the proccess we now need to use the
                        ProcessFound = true;
                    }
                }
            }
            return ProcessFound;
        }

        public static bool FindAndKillProcess(string name)
        {
            return FindProcess(name, true);
        }

        public static bool FindProcess(string name)
        {
            return FindProcess(name, false);
        }

        private static bool FindProcess(string name, bool kill)
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes by using the StartsWith Method,
                //this prevents us from incluing the .EXE for the process we're looking for.
                //. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running
                if (clsProcess.ProcessName.StartsWith(name))
                {
                    //since we found the proccess we now need to use the
                    //Kill Method to kill the process. Remember, if you have
                    //the process running more than once, say IE open 4
                    //times the loop thr way it is now will close all 4,
                    //if you want it to just close the first one it finds
                    //then add a return; after the Kill
                    //process killed, return true
                    if (kill)
                        clsProcess.Kill();
                    return true;
                }
            }
            //process not found, return false
            return false;
        }

        /// <summary>
        /// Remove the startup registry key
        /// </summary>
        /// <returns>Status of removal</returns>
        public static bool RemoveRegistryKeys()
        {
            return RemoveRegistryKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
        }

        /// <summary>
        /// Remove the given registry key
        /// </summary>
        /// <param name="keyName">The key to remove</param>
        /// <returns>Status of removal</returns>
        public static bool RemoveRegistryKey(string keyName)
        {

            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                if (key == null)
                {
                    // Key doesn't exist. Do whatever you want to handle        
                    // this case
                    return false;
                }
                else
                {
                    try
                    {
                        key.DeleteValue("ClamWin");
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    return true;
                }
            }
        }



    }
}
