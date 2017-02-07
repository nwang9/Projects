using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmtpParameters
{

    public partial class EmailControl : UserControl
    {
        //    public static DependencyProperty UserDataProperty = DependencyProperty.Register
        //        (
        //             "UserData",
        //             typeof(MainWindowViewModel),
        //             typeof(EmailControl)
        //        );

        //    public MainWindowViewModel UserData
        //    {
        //        get { return (MainWindowViewModel)GetValue(UserDataProperty); }
        //        set { SetValue(UserDataProperty, value); }
        //    }

        public EmailControl()
        {
            InitializeComponent();  
        }
    }
}
