using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpParameters
{
    class CopyDataModel : ObservableObject
    {
        string sourcepath;
        string targetpath;
        bool isCopyServiceStopped;

        public CopyDataModel()
        {
            SourcePath = "";
            TargetPath = "";
            isCopyServiceStopped = true;
        }

        public bool IsCopyServiceStopped
        {
            get
            {
                return isCopyServiceStopped;
            }
            set
            {
                isCopyServiceStopped = value;
                OnPropertyChanged();
            }
        }

        public bool SourcePath
        {
            get
            {
                return sourcepath;
            }
            set
            {
                sourcepath = value;
                OnPropertyChanged();
            }
        }

        public bool TargetPath
        {
            get
            {
                return targetpath;
            }
            set
            {
                targetpath = value;
                OnPropertyChanged();
            }
        }

    }
}
