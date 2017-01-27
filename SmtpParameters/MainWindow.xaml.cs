using System.Windows;
using System.ServiceProcess;
using System.Security.Permissions;
using System;
using System.Xml;
using System.Linq;
using System.Timers;
using System.Windows.Interactivity;
using System.Windows.Forms;
using System.IO;

namespace SmtpParameters
{

    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }  
}
