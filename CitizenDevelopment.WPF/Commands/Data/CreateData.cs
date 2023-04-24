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
    internal class CreateData : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly CreateDataVm _vm; 

        public CreateData(CreateDataVm vm)
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
            await repository.TryCreateDataAsync(_vm.Data);
            _vm.Data = new Models.DataModel();
        }
    }
}
