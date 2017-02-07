using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmtpParameters
{
    public class ServiceCommandHandler : ICommand
    {
        public MainWindowViewModel ViewModel;
        // constructor
        public ServiceCommandHandler(MainWindowViewModel viewModel)
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
                return clickCommand ?? (clickCommand = new ServiceCommandHandler(() => MyAction(), canExecute));
            }
        }
        public void MyAction()
        {

        }
        // Command Handler
        private Action _action;
        public ServiceCommandHandler(Action action, bool canExecute)
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
            this.ViewModel.File_Browse();
        }
    }
}
