using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmtpParameters
{
    public class EmailCommandHandler : ICommand
    {
        public MainWindowViewModel ViewModel;
        // constructor
        public EmailCommandHandler(MainWindowViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

       
        private bool canExecute = true;
        private ICommand clickCommand;
        //setter
        public ICommand ClickCommand
        {
            get
            {
                return clickCommand ?? (clickCommand = new EmailCommandHandler(() => MyAction(), canExecute));
            }
        }
        public void MyAction()
        {

        }
       // Command Handler
        private Action _action;
        public EmailCommandHandler(Action action, bool canExecute)
        {
            action = _action;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (Convert.ToString(parameter) == "Browse")
                this.ViewModel.Email_Browse();
            else if (Convert.ToString(parameter) == "Browse Files")
                this.ViewModel.File_Browse();
            else
                this.ViewModel.Email_Click();          
        }
    }
}
