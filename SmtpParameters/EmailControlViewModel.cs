﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceProcess;
using System.Security.Permissions;


namespace SmtpParameters
{
    public class EmailControlViewModel : ObservableObject
    {
        public EmailControlViewModel()
        {
            this.EmailClickCommand = new EmailCommandHandler(this);
            UserData = new SmtpDataModel();
            FillUserData();
        }

        public EmailCommandHandler EmailClickCommand { get; set; }
        public SmtpDataModel UserData { get; set; }

        //Fill_User_Data method
        public void FillUserData()
        {
            string xmlFile = UserData.XmlFile;
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            FileIOPermission f = new FileIOPermission(FileIOPermissionAccess.Write, xmlFile);

            // Change to new elements
            UserData.Host = doc.GetElementsByTagName("Host")[0].InnerText;
            UserData.Port = Convert.ToInt32(doc.GetElementsByTagName("Port")[0].InnerText);
            UserData.UseDefaultCredentials = Convert.ToBoolean(doc.GetElementsByTagName("UseDefaultCredentials")[0].InnerText);
            UserData.EnableSs1 = Convert.ToBoolean(doc.GetElementsByTagName("EnableSs1")[0].InnerText);
        }
        //End of Fill_User_Data

        // Start_Email_Service method
        public void Start_Email_Service()
        {
            string xmlFile = UserData.XmlFile;
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            FileIOPermission f = new FileIOPermission(FileIOPermissionAccess.Write, xmlFile);

            // Change to new elements
            doc.GetElementsByTagName("Host")[0].InnerText = Convert.ToString(UserData.Host);
            doc.GetElementsByTagName("Port")[0].InnerText = Convert.ToString(UserData.Port);
            doc.GetElementsByTagName("UseDefaultCredentials")[0].InnerText = Convert.ToString(UserData.UseDefaultCredentials);
            doc.GetElementsByTagName("EnableSs1")[0].InnerText = Convert.ToString(UserData.EnableSs1);
            // Save changes
            doc.Save(xmlFile);

            // Start service after settings are changed
            ServiceController EmailService = new ServiceController("EmailService", Environment.MachineName);
            try
            {
                EmailService.Start();
                EmailService.Refresh();
            }
            catch
            {
                Console.WriteLine("Could not start the Email service.");
                // IsServiceStopped = true;
            }
        }
        //End of Start_Email_Service method

        //Stop_Email_Service method
        public void Stop_Email_Service()
        {
            ServiceController EmailService = new ServiceController("EmailService", Environment.MachineName);
            try
            {
                // Stop service or stop on timeout
                TimeSpan timeout = new TimeSpan(0, 5, 0);
                EmailService.Stop();
                EmailService.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                EmailService.Refresh();
            }
            catch
            {
                Console.WriteLine("Could not stop the Email service.");
                //IsServiceStopped = false;
            }
        }
        //End of Stop_Email_Service

        public void Email_Browse()
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "XML Files (.xml)|*.xml| Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                UserData.XmlFile = dlg.FileName;
            }
        }
        //end of Email_browse click function
    }
}
