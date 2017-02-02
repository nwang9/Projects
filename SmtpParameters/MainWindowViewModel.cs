using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ServiceProcess;
using System.Security.Permissions;
using System.Windows.Input;


namespace SmtpParameters
{
    public class MainWindowViewModel : ObservableObject
    {
        private ServiceBase selectedService;

        public ServiceBase SelectedService
        {
            get { return selectedService; }
            set {
                selectedService = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            UserData = new SmtpDataModel();
            CopyData = new CopyDataModel();
            this.ServiceSelectionClickCommand = new EmailCommandHandler(this);
            this.CopyClickCommand = new CopyCommandHandler(this);
            this.StartClickCommand = new StartStopCommandHandler(this);
            FillUserData();
        }
        System.Collections.ObjectModel.ObservableCollection<ServiceBase> services = new System.Collections.ObjectModel.ObservableCollection<ServiceBase>();
        // Accessors
        public System.Collections.ObjectModel.ObservableCollection<ServiceBase> Services
        {
            get { return services; }
            set
            {
                services = value;
                OnPropertyChanged();
            }
        }
        public SmtpDataModel UserData
        { get; set; }
        public CopyDataModel CopyData
        { get; set; }
        public EmailCommandHandler ServiceSelectionClickCommand { get; set; }
        public StartStopCommandHandler StartClickCommand { get; set; }
        public CopyCommandHandler CopyClickCommand { get; set; }

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

        public void File_Browse()
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
                //Find service type and add serice
                XmlDocument doc = new XmlDocument();
                doc.Load(UserData.XmlFile);
                if (doc.GetElementsByTagName("ServiceType")[0].InnerText == "Email")
                    Services.Add(UserData);
                else if (doc.GetElementsByTagName("ServiceType")[0].InnerText == "Copy")
                    Services.Add(CopyData);
            }
        }

        public void Start_Stop_Click(string serviceType)
        {
            //string ServiceType = serviceType;
            //object serviceObject = Services.Find(x => x.ServiceName.Contains(ServiceType));

            //if (serviceObject.IsServiceStopped == true)
            //{
            //    typeof(MainWindowViewModel).GetMethod("Start_" + "{ServiceType}" + "_Service")();
            //    serviceObject.IsServiceStopped = false;
            //}
            //else
            //{
            //    typeof(MainWindowViewModel).GetMethod("Stop_" + "{ServiceType}" + "_Service")();
            //    serviceObject.IsServiceStopped = true;
            //}
        }

        public void Browse_Source()
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
                CopyData.SourcePath = dlg.FileName;
            }
        }

        public void Browse_Target()
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
                CopyData.TargetPath = dlg.FileName;
            }
        }
        //
        // Start_Copy_Service method
        public void Start_Copy_Service()
        {
            string xmlFile = @"C:\Users\nicowang9\Documents\Visual Studio 2015\Projects\FileCopyService\FileCopyService\copyfiledata.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            FileIOPermission f = new FileIOPermission(FileIOPermissionAccess.Write, xmlFile);

            // Change to new elements
            doc.GetElementsByTagName("SourcePath")[0].InnerText = Convert.ToString(CopyData.SourcePath);
            doc.GetElementsByTagName("TargetPath")[0].InnerText = Convert.ToString(CopyData.TargetPath);
            // Save changes
            doc.Save(xmlFile);

            // Start service after settings are changed
            ServiceController CopyService = new ServiceController("CopyService", Environment.MachineName);
            try
            {
                CopyService.Start();
                CopyService.Refresh();
            }
            catch
            {
                Console.WriteLine("Could not start the Copy service.");
            }
        }
        //End of Start_Copy_Service method

        //Stop_Copy_Service method
        public void Stop_Copy_Service()
        {
            ServiceController CopyService = new ServiceController("CopyService", Environment.MachineName);
            try
            {
                // Stop service or stop on timeout
                TimeSpan timeout = new TimeSpan(0, 5, 0);
                CopyService.Stop();
                CopyService.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                CopyService.Refresh();
            }
            catch
            {
                Console.WriteLine("Could not stop the Copy service.");
            }
        }
        //
    }
}

