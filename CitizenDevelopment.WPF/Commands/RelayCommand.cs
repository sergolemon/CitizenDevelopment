using CitizenDevelopment.WPF.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CitizenDevelopment.WPF.Commands
{
    public class RelayCommand : BaseCommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Func<object, Task<object>> _handle;

        public RelayCommand(Func<object, Task<object>> handle, Func<object, bool> canExecute = null)
        {
            _handle = handle;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        protected override async Task<object> Handle(object parameter)
        {
            var result = await _handle(parameter);

            return result;
        }
    }
}
