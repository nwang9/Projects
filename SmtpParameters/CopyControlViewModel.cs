using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Security.Permissions;
using System.Xml;

namespace SmtpParameters
{
    public class CopyControlViewModel : ObservableObject
    {
        public CopyControlViewModel()
        {
            CopyData = new CopyDataModel();
            this.CopyClickCommand = new CopyCommandHandler(this);
        }

        public CopyDataModel CopyData
        { get; set; }
        public CopyCommandHandler CopyClickCommand { get; set; }

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
