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
        public event Action<object> Executed;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public virtual bool CanExecute(object parameter) => true;

        protected abstract Task<object> Handle(object parameter);

        public async void Execute(object parameter)
        {
            var result = await Handle(parameter);

            Executed?.Invoke(result);
        }
    }
}
