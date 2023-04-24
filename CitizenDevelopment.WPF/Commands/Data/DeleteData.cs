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
    internal class DeleteData : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly DataListVm _vm;

        public DeleteData(DataListVm vm)
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
            var itemId = (int)parameter;
            await repository.TryRemoveDataAsync(new Models.DataModel { Id = itemId });
            _vm.Data.Remove(_vm.Data.FirstOrDefault(x => x.Id == itemId));
        }
    }
}
