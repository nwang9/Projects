using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmtpParameters
{
    public class VisibilityCommandHandler : ICommand
    {
        public MainWindowViewModel ViewModel;
        // constructor
        public VisibilityCommandHandler(MainWindowViewModel viewModel)
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
                return clickCommand ?? (clickCommand = new VisibilityCommandHandler(() => MyAction(), canExecute));
            }
        }
        public void MyAction()
        {

        }
        // Command Handler
        private Action _action;
        public VisibilityCommandHandler(Action action, bool canExecute)
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
            View(parameter);
        }
    }
}
