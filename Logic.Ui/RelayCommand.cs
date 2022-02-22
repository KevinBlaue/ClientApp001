using System;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp001.Logic.Ui
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute;
        private Func<bool> canExecuteEvaluator;

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }
        
        public RelayCommand(Action methodToExecute) : this(methodToExecute, null)
        {
            this.methodToExecute = methodToExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
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
            this.methodToExecute.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}