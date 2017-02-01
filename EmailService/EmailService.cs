using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net;
using System.Net.Mail;
using System.Xml;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;


namespace EmailService
{
    public partial class EmailService : ServiceBase
    {
        private int eventId;
        public EmailService()
        {
            InitializeComponent();
            MailServiceEventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            MailServiceEventLog.Source = "MySource";
            MailServiceEventLog.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            MailServiceEventLog.WriteEntry("In OnStart");
            
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        // Protect the connectionStrings section.
        private static void ProtectConfiguration()
        {

            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Define the Rsa provider name.
            string provider =
                "RsaProtectedConfigurationProvider";

            // Get the section to protect.
            ConfigurationSection connStrings =
                config.ConnectionStrings;
            //string toProtectString = Properties.Settings.Default.Password;
            if (connStrings != null)
            {
                if (!connStrings.SectionInformation.IsProtected)
                {
                    if (!connStrings.ElementInformation.IsLocked)
                    {
                        // Protect the section.
                        connStrings.SectionInformation.ProtectSection(provider);

                        connStrings.SectionInformation.ForceSave = true;
                        config.Save(ConfigurationSaveMode.Full);

                        Console.WriteLine("Section {0} is now protected by {1}",
                            connStrings.SectionInformation.Name,
                            connStrings.SectionInformation.ProtectionProvider.Name);

                    }
                    else
                        Console.WriteLine(
                             "Can't protect, section {0} is locked",
                             connStrings.SectionInformation.Name);
                }
                else
                    Console.WriteLine(
                        "Section {0} is already protected by {1}",
                        connStrings.SectionInformation.Name,
                        connStrings.SectionInformation.ProtectionProvider.Name);

            }
            else
                Console.WriteLine("Can't get the section {0}",
                    connStrings.SectionInformation.Name);
        }

        // Unprotect the connectionStrings section.
        private static void UnProtectConfiguration()
        {

            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section to unprotect.
            ConfigurationSection connStrings =
                config.ConnectionStrings;

            if (connStrings != null)
            {
                if (connStrings.SectionInformation.IsProtected)
                {
                    if (!connStrings.ElementInformation.IsLocked)
                    {
                        // Unprotect the section.
                        connStrings.SectionInformation.UnprotectSection();

                        connStrings.SectionInformation.ForceSave = true;
                        config.Save(ConfigurationSaveMode.Full);

                        Console.WriteLine("Section {0} is now unprotected.",
                            connStrings.SectionInformation.Name);

                    }
                    else
                        Console.WriteLine(
                             "Can't unprotect, section {0} is locked",
                             connStrings.SectionInformation.Name);
                }
                else
                    Console.WriteLine(
                        "Section {0} is already unprotected.",
                        connStrings.SectionInformation.Name);

            }
            else
                Console.WriteLine("Can't get the section {0}",
                    connStrings.SectionInformation.Name);
        }
        ////// Encryption string
        //public static string Encrypt(string clearText)
        //{
        //    string EncryptionKey = "abc123";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}
        ////Decrypt method
        //public static string Decrypt(string cipherText)
        //{
        //    string EncryptionKey = "abc123";
        //    cipherText = cipherText.Replace(" ", "+");
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}

        // onstop
        protected override void OnStop()
        {
            MailServiceEventLog.WriteEntry("In onStop.");
            ProtectConfiguration();
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            MailServiceEventLog.WriteEntry("In OnContinue.");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            MailServiceEventLog.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
            // Read emails from List
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\nicowang9\Documents\Visual Studio 2015\Projects\EmailService\EmailService\emails.xml");
            List<string> emails = new List<string>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                emails.Add(node.InnerText);
            }
            // Smtp Client
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };
            string my_email = "nicowang9@gmail.com";

            // Unprotect
            UnProtectConfiguration();
            // Mail setup

            smtp.Credentials = new NetworkCredential(
                 my_email,Convert.ToString(ConfigurationManager.ConnectionStrings["Password"]));
            foreach (string email in emails)
            {
                MailAddress from = new MailAddress(my_email);
                MailAddress to = new MailAddress(email);
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "test";
                mail.Body = "body";
                try
                {
                    smtp.Send(mail);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in CreateTestMessage(): {0}",
                                ex.ToString());
                }
            }
        }
    }
}
