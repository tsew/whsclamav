using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;

using System.Diagnostics;

namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    class Fetch
    {
        static WebProxy myProxy = null;

        static ClamConfig ClamWinConfig = new ClamConfig();

        static string ClamWinExe = "https://downloads.sourceforge.net/project/clamwin/clamwin/0.99.1/clamwin-0.99.1-setup.exe?use_mirror=switch";
        static string ClamWinExeVer = "0.99.1";

        // Version 0.97
        //static string ClamWinExe = "http://downloads.sourceforge.net/project/clamwin/clamwin/0.97/clamwin-0.97-setup.exe";

        // Version 0.96.5
        //static string ClamWinExe = "http://downloads.sourceforge.net/project/clamwin/clamwin/0.96.5/clamwin-0.96.5-setup.exe?use_mirror=switch";
        //static string ClamWinExeVer = "0.96.5";

        // Version 0.96.4
        //static string ClamAVExe = "http://downloads.sourceforge.net/project/clamwin/clamwin/0.96.4/clamwin-0.96.4-setup.exe?use_mirror=switch";

        // Version 0.96.1
        // static string ClamAVExe = "http://downloads.sourceforge.net/project/clamwin/clamwin/0.96.1/clamwin-0.96.1-setup.exe?use_mirror=switch";

        // Version 0.96
        //static string ClamAVExe = "http://downloads.sourceforge.net/project/clamwin/clamwin/0.96/clamwin-0.96-setup.exe?use_mirror=switch";

        // Version 0.95.3
        //static string ClamAVExe = "http://downloads.sourceforge.net/project/clamwin/clamwin/0.95.3/clamwin-0.95.3-setup.exe?use_mirror=switch";

        // Version 0.95.1
        //static String ClamAVExe = "http://heanet.dl.sourceforge.net/sourceforge/clamwin/clamwin-0.95.1-setup.exe";


        //static String ClamAVInstallFile = "D:\\shares\\Software\\Add-Ins\\" + "clamav.exe";

        /// <summary>
        /// This performs the download of ClamWin
        /// </summary>
        public static void DoDownload()
        {
            WebRequest wreq = (HttpWebRequest)WebRequest.Create(GetClamWinURL());

            WebClient wcl = new WebClient();

            SetProxy(ref wreq, ref wcl);

            WebResponse wbr;

            //UpdateInstallLabel("Downloading ClamAV (Acquiring)   ");
            try
            {
                wbr = (HttpWebResponse)wreq.GetResponse();
            }
            catch (Exception ex)
            {
                if (ex is System.Net.WebException)
                {
                    ThrowError.Throw(ex.Message + Environment.NewLine + ex.InnerException.Message, "Fatal Error in WebRequest.GetResponse()");
                }
                //DownloadButton.Text = "Download";
                //DownloadButton.Enabled = true;
                //DownloadProgressBar.Visible = false;
                return;
            }

            //DownloadProgressBar.Visible = true;
            //DownloadProgressBar.Value = 0;

            //DownloadButton.Text = "Downloading";
            //DownloadButton.Enabled = false;
            //UpdateInstallLabel("Downloading ClamAV (Starting)   ");

            Stream strm;

            try
            {
                strm = wcl.OpenRead(GetClamWinURL());
            }
            catch (Exception ex)
            {
                if (ex is System.Net.WebException)
                {
                    ThrowError.Throw(ex.Message, "Fatal Error in WebClient.OpenRead()");
                }
                //DownloadButton.Text = "Download";
                //DownloadButton.Enabled = true;
                //DownloadProgressBar.Visible = false;
                return;
            }

            byte[] buffer = new byte[32768];
            String tempFile = ClamConfig.ClamAVInstallFile;
            FileStream fstrm = new FileStream(tempFile, System.IO.FileMode.Create);

            // Set the min and max values for the progress bar to 0 and size of download
            //DownloadProgressBar.Minimum = 0;
            //DownloadProgressBar.Maximum = (int)(wbr.ContentLength / 1024);
            //DownloadProgressBar.Style = ProgressBarStyle.Blocks;

            int bytesRead;
            long totalBytesRead = 0;

            while ((bytesRead = strm.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
                // Update download progress with current position of the strm
                //this.Invoke(new UpdateProgessCallback(this.UpdateProgress), new object[] { (int)(totalBytesRead / 1024), DownloadProgressBar.Maximum });
                fstrm.Write(buffer, 0, bytesRead);
            }

            //UpdateInstallLabel("Downloading ClamAV (Complete)   ");
            // Close files
            fstrm.Close();
            strm.Close();

            if (totalBytesRead == GetContentLength())
            {
                // Then all downloaded okay.
            }

            //CheckStatus();
        }

        /// <summary>
        /// Get content length
        /// </summary>
        /// <returns>return length in bytes or -1 (failed)</returns>
        public static long GetContentLength()
        {
            System.Net.WebRequest req = System.Net.HttpWebRequest.Create(ClamWinExe);
            SetProxy(ref req);
            req.Method = "HEAD";
            System.Net.WebResponse resp = req.GetResponse();
            long ContentLength;
            if (long.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
            {
                return ContentLength;
            }
            else
                return -1;
        }

        /// <summary>
        /// This Function attempts to retrieve the latest ClamWin Version from the internet
        /// </summary>
        /// <returns>URL For ClamWin Download</returns>
        public static string GetClamWinVersion()
        {
            // try to get version xml file from internet
            try
            {
                XmlDocument vXML = GetVersion();
                String clamWinVer = vXML.SelectNodes("/WHSClamAV/PlugIn/Version").Item(0).InnerText;
                return clamWinVer;
            }
            catch (Exception)
            {
                // if we failed then return the hard coded value
                return ClamWinExeVer;
            }
        }

        /// <summary>
        /// This Function attempts to retrieve the latest ClamWin Downlaod URL from the internet
        /// </summary>
        /// <returns>URL For ClamWin Download</returns>
        public static string GetClamWinURL()
        {
         /*   // try to get version xml file from internet
            try
            {
                XmlDocument vXML = GetVersion();
                String clamWinURL = vXML.SelectNodes("/WHSClamAV/PlugIn/Download").Item(0).InnerText;
                ThrowError.Throw(clamWinURL, "GetClamWinURL()");
                return clamWinURL;
            }
            catch (Exception)
            {
                // if we failed then return the hard coded value
                ThrowError.Throw("Using Default Value", "GetClamWinURL()");
          */ 
                return ClamWinExe;
            //}
        }

        /// <summary>
        /// Get an XML File with Version Information
        /// </summary>
        /// <returns>The XML File as String</returns>
        public static XmlDocument GetVersion()
        {
            SetProxy();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(ClamWinConfig.ClamVersionURI);
            return xDoc;
        }

        /// <summary>
        /// Generic File Download 
        /// </summary>
        public static void GetFile()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set Proxy on WebRequest - should hold for all subsequent webrequests
        /// </summary>
        public static void SetProxy()
        {
            SetProxyHost();
            if (myProxy != null)
            {
                NetworkCredential credentials = new NetworkCredential(ClamWinConfig.ReadClamConfigKey("user"), ClamWinConfig.ReadClamConfigKey("password"));
                WebRequest.DefaultWebProxy = myProxy;
                WebRequest.DefaultWebProxy.Credentials = credentials;
            }
        }

        /// <summary>
        /// SetProxy for webrequest, we can handle all webrequests without anything being set by referencing null
        /// </summary>
        /// <param name="wreq">The WebRequest</param>
        /// <param name="wcl">The WebClient</param>
        public static void SetProxy(ref WebRequest wreq, ref WebClient wcl)
        {
            SetProxyHost();

            // UpdateInstallLabel("Downloading ClamAV (Proxy Test)   ");
            if (myProxy != null)
                if (myProxy.Address != null)
                {
                    NetworkCredential credentials = new NetworkCredential(ClamWinConfig.ReadClamConfigKey("user"), ClamWinConfig.ReadClamConfigKey("password"));
                    wcl.Proxy = myProxy;
                    wcl.Proxy.Credentials = credentials;

                    wreq.Proxy = myProxy;
                    wreq.Proxy.Credentials = wcl.Proxy.Credentials;
                }

        }

        /// <summary>
        /// SetProxy for webrequest, we can handle all webrequests without anything being set by referencing null
        /// </summary>
        /// <param name="wreq">The WebRequest</param>
        public static void SetProxy(ref WebRequest wreq)
        {
            SetProxyHost();

            // UpdateInstallLabel("Downloading ClamAV (Proxy Test)   ");
            if (myProxy != null)
                if (myProxy.Address != null)
                {
                    NetworkCredential credentials = new NetworkCredential(ClamWinConfig.ReadClamConfigKey("user"), ClamWinConfig.ReadClamConfigKey("password"));

                    wreq.Proxy = myProxy;
                    wreq.Proxy.Credentials = credentials;
                }
        }

        /// <summary>
        /// Set the Proxy Host and Port
        /// </summary>
        public static void SetProxyHost()
        {
            // Check to see if port is defined
            if (!String.IsNullOrEmpty(ClamWinConfig.ReadClamConfigKey("port")))
            {
                if (!String.IsNullOrEmpty(ClamWinConfig.ReadClamConfigKey("host")))
                {
                    try
                    {
                        myProxy = new WebProxy(ClamWinConfig.ReadClamConfigKey("host"), Int32.Parse(ClamWinConfig.ReadClamConfigKey("port")));
                    }
                    catch (Exception ex)
                    {
                        ThrowError.Throw(ex.Message, "Proxy Definition Error");
                    }
                }
            }
        }
    }
}
