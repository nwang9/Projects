using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpParameters
{
    public class ViewDataModel : ObservableObject
    {
        public bool emailServiceVisible;
        public bool copyServiceVisible;
        public string selectedGrid;

        public ViewDataModel()
        {
            EmailServiceVisible = false;
            CopyServiceVisible = false;  
            SelectedGrid = "";        
        }

        public string SelectedGrid
        {
            get
            {
                return selectedGrid;
            }
            set
            {
                selectedGrid = value;
                OnPropertyChanged();
                if (selectedGrid == "Email Service")
                {
                    EmailServiceVisible = true;
                    OnPropertyChanged(Convert.ToString(EmailServiceVisible));
                    CopyServiceVisible = false;
                    OnPropertyChanged(Convert.ToString(CopyServiceVisible));
                }
                else if (selectedGrid == "Copy Service")
                {
                    CopyServiceVisible = true;
                    OnPropertyChanged(Convert.ToString(CopyServiceVisible));
                    EmailServiceVisible = false;
                    OnPropertyChanged(Convert.ToString(EmailServiceVisible));
                }
            }
        }       
        
        public bool EmailServiceVisible
        {
            get
            {
                return emailServiceVisible;
            }
            set
            {
                emailServiceVisible = value;
                OnPropertyChanged();
            }
        }   

        public bool CopyServiceVisible
        {
            get
            {
                return copyServiceVisible;
            }
            set
            {
                copyServiceVisible = value;
                OnPropertyChanged();
            }
        }
        //  
    }
}
