using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpParameters
{
    public class SmtpDataModel : ObservableObject
    {
        public string host;
        public int port;
        public bool enableSs1;
        public bool useDefaultCredentials;
        public bool isEmailServiceStopped;
        public string contactsFile;

        public SmtpDataModel()
        { 
            Host = "smtp.gmail.com";
            Port = 587;
            EnableSs1 = true;
            UseDefaultCredentials = false;
            IsEmailServiceStopped = true;
            contactsFile = @"C:\Users\nicowang9\Documents\Visual Studio 2015\Projects\EmailService\EmailService\emails.xml";
        }

        public bool IsEmailServiceStopped
        {
            get
            {
                return isEmailServiceStopped;
            }
            set
            {
                isEmailServiceStopped = value;
                OnPropertyChanged();
            }
        }

        public string ContactsFile
        {
            get
            {
                return contactsFile;
            }
            set
            {
                contactsFile = value;
                OnPropertyChanged();
            }
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
