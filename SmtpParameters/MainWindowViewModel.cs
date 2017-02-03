using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            this.ServiceSelectionClickCommand = new ServiceCommandHandler(this);
            this.StartClickCommand = new StartStopCommandHandler(this);
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

        public ServiceCommandHandler ServiceSelectionClickCommand { get; set; }
        public StartStopCommandHandler StartClickCommand { get; set; }

       
        

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
                XmlFile = dlg.FileName;
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


    }
}

