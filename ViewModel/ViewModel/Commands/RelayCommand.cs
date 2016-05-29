using System;
using System.Windows.Input;

// TODO Delete this class if not used
namespace ViewModel.Commands
{
    /// <summary>
    /// Source: http://docs.telerik.com/data-access/quick-start-scenarios/wpf/quickstart-wpf-viewmodelbase-and-relaycommand
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action methodToExecute;
        private readonly Func<bool> canExecuteEvaluator;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }

        public void Execute(object parameter)
        {
            methodToExecute.Invoke();
        }
    }
}
