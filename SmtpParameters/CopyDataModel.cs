using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpParameters
{
    public class CopyDataModel : ServiceBase
    {
        public string sourcepath;
        public string targetpath;

        public CopyDataModel()
        {
            SourcePath = "";
            TargetPath = "";
            ServiceName = "Copy Service";
            IsServiceStopped = true;
        }

        public string SourcePath
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

        public string TargetPath
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
