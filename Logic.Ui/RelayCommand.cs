using System;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp001.Logic.Ui
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute;
        private Action<object> parameterMethodToExecute;
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
        
        public RelayCommand(Action<object> methodToExecute) : this(methodToExecute, null) { }

        public RelayCommand(Action<object> methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.parameterMethodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
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
            if (this.methodToExecute != null)
            {
                  this.methodToExecute.Invoke();
            }

            if (parameterMethodToExecute != null)
            {
                this.parameterMethodToExecute.Invoke(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}