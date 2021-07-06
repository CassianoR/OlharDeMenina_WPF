using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LojaOlharDeMenina_WPF.Core
{
    public class Command : ICommand
    {
        public Command(Func<object, bool> methodCanExecute, Action<object> methodExecute)
        {
            MethodCanExecute = methodCanExecute;
            MethodExecute = methodExecute;
        }

        private Action<object> MethodExecute;
        private Func<object, bool> MethodCanExecute;

        public bool CanExecute(object parameter)
        {
            return MethodExecute != null && MethodCanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            MethodExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
