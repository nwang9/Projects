using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpParameters
{
    public class SmtpDataModel : ServiceBase
    {
        public string host;
        public int port;
        public bool enableSs1;
        public bool useDefaultCredentials;

        public SmtpDataModel()
        { 
            Host = "smtp.gmail.com";
            Port = 587;
            EnableSs1 = true;
            UseDefaultCredentials = false;
            IsServiceStopped = true;
            XmlFile = @"C:\Users\nicowang9\Documents\Visual Studio 2015\Projects\EmailService\EmailService\emails.xml";
            ServiceName = "Email Service";
            IsVisible = false;
        }

        public string Host
        {
            get { return host; }
            set
            {
                host = value;
                OnPropertyChanged();
            }
        }

        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                OnPropertyChanged();
            }
        }

        public bool EnableSs1
        {
            get { return enableSs1; }
            set
            {
                enableSs1 = value;
                OnPropertyChanged();
            }
        }

        public bool UseDefaultCredentials
        {
            get { return useDefaultCredentials; }
            set
            {
                useDefaultCredentials = value;
                OnPropertyChanged();
            }
        }
    }
}
