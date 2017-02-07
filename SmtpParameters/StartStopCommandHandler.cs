using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmtpParameters
{
    public class StartStopCommandHandler : ICommand
    {
        public MainWindowViewModel ViewModel;
        // constructor
        public StartStopCommandHandler(MainWindowViewModel viewModel)
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
                return clickCommand ?? (clickCommand = new StartStopCommandHandler(() => MyAction(), canExecute));
            }
        }
        public void MyAction()
        {

        }
        // Command Handler
        private Action _action;
        public StartStopCommandHandler(Action action, bool canExecute)
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
            this.ViewModel.Start_Stop_Click(Convert.ToString(parameter));
        }
    }
}
