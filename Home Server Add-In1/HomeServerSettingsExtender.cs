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
                static WebProxy myProxy = null;

        static ClamConfig ClamWinConfig = new ClamConfig();

        static string ClamWinExe = "https://downloads.sourceforge.net/project/clamwin/clamwin/0.99.1/clamwin-0.99.1-setup.exe?use_mirror=switch";
        static string ClamWinExeVer = "0.99.1";

        /// <summary>
        /// This performs the download of ClamWin
        /// </summary>

        public static WebClient client;
        public static void DoDownload(ProgressBar progress)
        {
            client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);


            string filename = "clamwin.exe";
            client.DownloadFileAsync(new Uri(ClamWinExe), filename);
            //DownloadButton.Text = "Download";
            //DownloadButton.Enabled = true;
            //DownloadProgressBar.Visible = false;

            //DownloadProgressBar.Visible = true;
            //DownloadProgressBar.Value = 0;

            //DownloadButton.Text = "Downloading";
            //DownloadButton.Enabled = false;
            //UpdateInstallLabel("Downloading ClamAV (Starting)   ");


            // Set the min and max values for the progress bar to 0 and size of download
            //DownloadProgressBar.Minimum = 0;
            //DownloadProgressBar.Maximum = (int)(wbr.ContentLength / 1024);
            //DownloadProgressBar.Style = ProgressBarStyle.Blocks;


            //UpdateInstallLabel("Downloading ClamAV (Complete)   ");
            // Close files

            //CheckStatus();
        }

        static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            long bytesIn = e.BytesReceived;
            long totalBytes = e.TotalBytesToReceive;
            int percentage = e.ProgressPercentage;
        }

        static void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
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
