using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpParameters
{
    public class ServiceBase : ObservableObject
    {
        public string xmlFile;
        public string serviceName;
        public string serviceType;
        public int serviceInterval;
        public bool isServiceStopped;

        //public override string ToString()
        //{
        //    return ServiceName.ToString();
        //}

        public ServiceBase()
        {
            XmlFile = "";
            ServiceName = "";
            ServiceType = "";

        }

        public string XmlFile
        {
            get
            {
                return xmlFile;
            }
            set
            {
                xmlFile = value;
                OnPropertyChanged();
            }
        }

        public int ServiceInterval
        {
            get
            {
                return serviceInterval;
            }
            set
            {
                serviceInterval = value;
                OnPropertyChanged();
            }
        }

        public bool IsServiceStopped
        {
            get
            {
                return isServiceStopped;
            }
            set
            {
                isServiceStopped = value;
                OnPropertyChanged();
            }
        }



        public string ServiceName
        {
            get
            {
                return serviceName;
            }
            set
            {
                serviceName = value;
                OnPropertyChanged();
            }
        }

        public string ServiceType
        {
            get
            {
                return serviceType;
            }
            set
            {
                serviceType = value;
                OnPropertyChanged();
            }
        }

    }
}
