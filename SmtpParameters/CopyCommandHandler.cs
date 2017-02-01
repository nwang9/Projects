using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmtpParameters
{
    public class CopyCommandHandler : ICommand
    {
        public MainWindowViewModel ViewModel;
        // constructor
        public CopyCommandHandler(MainWindowViewModel viewModel)
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
                return clickCommand ?? (clickCommand = new CopyCommandHandler(() => MyAction(), canExecute));
            }
        }
        public void MyAction()
        {

        }
        // Command Handler
        private Action _action;
        public CopyCommandHandler(Action action, bool canExecute)
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
            if (Convert.ToString(parameter) == "Browse_Source")
                this.ViewModel.Browse_Source();
            else if (Convert.ToString(parameter) == "Browse_Target")
                this.ViewModel.Browse_Target();
            else
                this.ViewModel.Copy_Click();
        }
    }
}
