using Microsoft.WindowsMobile.PocketOutlook;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Configuration;

namespace prjColetorDadosIntermecCSNet35
{
    class SendMail : IDisposable
    {
        //[System.Runtime.InteropServices.DllImport("coredll.dll")]
        //[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        //static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("coredll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        OutlookSession session;
        public EmailAccount account;
        EmailMessage eMail;
        public String _to = "TheRecipient@intermec.com";
        Attachment attachement;
        Recipient rcp;

        bool _syncImmediately = false;
        public bool syncImmediately
        {
            get { return _syncImmediately; }
            set { _syncImmediately = value; }
        }

        bool _bIsValidAccount = false;
        public bool bIsValidAccount
        {
            get
            {
                return _bIsValidAccount;
            }
        }

        public bool setAccount(string sMailAccount)
        {
            session.Dispose();
            session = new OutlookSession();
            //eMail = new EmailMessage();
            bool bFound = false;
            foreach (Account acc in session.EmailAccounts)
            {
                if (acc.Name == sMailAccount)
                {
                    account = session.EmailAccounts[sMailAccount];
                    bFound = true;
                }
            }
            return bFound;
        }

        public SendMail(string sMailAccount)
        {
            session = new OutlookSession();
            //eMail = new EmailMessage();
            bool bFound = false;
            foreach (Account acc in session.EmailAccounts)
            {
                System.Diagnostics.Debug.WriteLine(acc.Name);
                if (acc.Name == sMailAccount)
                    bFound = true;
            }
            if (bFound)
                account = session.EmailAccounts[sMailAccount];
            else
            {
                if (this.createAccountGoogle())
                    account = session.EmailAccounts[sMailAccount];
            }
            if (account != null)
                _bIsValidAccount = true;
        }

        public SendMail()
        {
            session = new OutlookSession();
            //eMail = new EmailMessage();
            bool bFound = false;
            foreach (Account acc in session.EmailAccounts)
            {
                System.Diagnostics.Debug.WriteLine(acc.Name);
                if (acc.Name == "Google Mail")
                    bFound = true;
            }
            if (bFound)
                account = session.EmailAccounts["Google Mail"];
            else
            {
                if (this.createAccountGoogle())
                    account = session.EmailAccounts["Google Mail"];
            }
            if (account != null)
                _bIsValidAccount = true;
        }

        /// <summary>
        /// sync eMail using send and recv in foreground
        /// </summary>
        public void syncNow()
        {
            if (this.account != null)
                Microsoft.WindowsMobile.PocketOutlook.MessagingApplication.Synchronize(this.account);
        }

        /// <summary>
        /// sync eMail in outlook
        /// </summary>
        /// <param name="pHandle">handle to forground window</param>
        public void syncNow(IntPtr pHandle)
        {
            if (this.account != null)
            {
                Microsoft.WindowsMobile.PocketOutlook.MessagingApplication.Synchronize(this.account);
                SetForegroundWindow(pHandle);
            }
        }

        public bool send(string sImagePath)
        {
            if (account == null)
                return false;
            try
            {
                eMail = new EmailMessage();
                rcp = new Recipient(_to);
                eMail.To.Add(rcp);
                eMail.Subject = "Visitenkarten LogiMAT";
                eMail.BodyText = "LogiMat " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\r\nsent from eMDI2Mail";

                attachement = new Attachment(sImagePath);
                eMail.Attachments.Add(attachement);
                eMail.Send(account);
                //account.Send(eMail);
                if (this._syncImmediately)
                {
                    if (this.account != null)
                        Microsoft.WindowsMobile.PocketOutlook.MessagingApplication.Synchronize(this.account);
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in send(): " + ex.Message);
            }
            return false;
        }

        public void Dispose()
        {
            if (account != null)
                account.Dispose();
            if (session != null)
                session.Dispose();
        }

        //public bool createAccountHotmail()
        //{
        //    ConfigurationManager.AppSettings.XMLConfig.Settings sett = new System.Configuration.ConfigurationManager.AppSettings.XMLConfig.Settings();

        //    return System.Configuration.ConfigurationManager.AppSettings.XMLConfig.DMProcessConfig.ProcessXML(sett.appPath + "hotmail.xml");
        //}

        public bool createAccountGoogle()
        {
            // XMLConfig.Settings sett = new System.Configuration.ConfigurationManager.AppSettings.XMLConfig.Settings();

            // return System.Configuration.ConfigurationManager.AppSettings.XMLConfig.DMProcessConfig.ProcessXML(sett.appPath + "gmail.xml");
            bool bRet = false;
            string strTemp = "";
            strTemp += "<wap-provisioningdoc>\r\n";
            strTemp += "  <characteristic type=\"EMAIL2\" recursive=\"true\">\r\n";
            strTemp += "    <characteristic type=\"{D45D5BE0-B96C-87A5-60B8-A59B69C733E4}\">\r\n";
            strTemp += "      <parm name=\"SERVICENAME\" value=\"Google Mail\" />\r\n";
            strTemp += "      <parm name=\"SERVICETYPE\" value=\"IMAP4\" />\r\n";
            strTemp += "      <parm name=\"INSERVER\" value=\"imap.googlemail.com\" />\r\n";
            strTemp += "      <parm name=\"AUTHNAME\" value=\"hebervaldo@gmail.com\" />\r\n";
            strTemp += "      <parm name=\"DOMAIN\" value=\"\" />\r\n";
            strTemp += "      <parm name=\"OUTSERVER\" value=\"smtp.googlemail.com\" />\r\n";
            strTemp += "      <parm name=\"REPLYADDR\" value=\"hebervaldo@gmail.com\" />\r\n";
            strTemp += "      <parm name=\"SMTPALTAUTHNAME\" value=\"hebervaldo@gmail.com\" />\r\n";
            strTemp += "      <parm name=\"SMTPALTDOMAIN\" value=\"\" />\r\n";
            strTemp += "      <parm name=\"NAME\" value=\"hebervaldo\" />\r\n";
            strTemp += "      <parm name=\"LINGER\" value=\"120\" />\r\n";
            strTemp += "      <parm name=\"RETRIEVE\" value=\"2048\" />\r\n";
            strTemp += "      <parm name=\"KEEPMAX\" value=\"0\" />\r\n";
            strTemp += "      <parm name=\"DWNDAY\" value=\"3\" />\r\n";
            strTemp += "      <parm name=\"FORMAT\" value=\"2\" />\r\n";
            strTemp += "      <parm name=\"AUTHREQUIRED\" value=\"1\" />\r\n";
            strTemp += "      <parm name=\"AUTHSECRET\" value=\"Heber723569\"/>\r\n";
            strTemp += "    </characteristic>\r\n";
            strTemp += "  </characteristic>\r\n";
            strTemp += "</wap-provisioningdoc>";

            return bRet;
        }
    }
}
