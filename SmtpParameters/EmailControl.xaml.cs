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
    /// <summary>
    /// Interaction logic for ServiceControl.xaml
    /// </summary>
    public partial class EmailControl : UserControl
    {
        //public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register
        //    (
        //         "EmailViewModel",
        //         typeof(MainWindowViewModel),
        //         typeof(EmailControl)
        //    );

        //public MainWindowViewModel ViewModel
        //{
        //    get { return (MainWindowViewModel)GetValue(ViewModelProperty); }
        //    set { SetValue(ViewModelProperty, value); }
        //}

        public EmailControl()
        {
            InitializeComponent();

            //Loaded += (sender, args) =>
            //{
            //    MainWindowViewModel vm = new MainWindowViewModel(ViewModel);
            //    this.DataContext = vm;
            //};
        }
    }
}
