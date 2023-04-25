using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CitizenDevelopment.WPF.Abstract
{
    public abstract class BaseCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;

        public BaseCommand(Func<object, bool> canExecute = null)
        {
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<object> ExecuteCallback;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public async void Execute(object parameter) 
        {
            var commandResult = await ExecuteCommandAsync(parameter);

            ExecuteCallback?.Invoke(commandResult);
        }

        protected abstract Task<object> ExecuteCommandAsync(object parameter);
    }
}
