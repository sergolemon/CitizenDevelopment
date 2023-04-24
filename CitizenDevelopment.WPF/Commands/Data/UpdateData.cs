using CitizenDevelopment.WPF.Repositories;
using CitizenDevelopment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CitizenDevelopment.WPF.Commands.Data
{
    internal class UpdateData : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly UpdateDataVm _vm;

        public UpdateData(UpdateDataVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var repository = new DataRepository();
            await repository.TryUpdateDataAsync(_vm.Data);
        }
    }
}
