using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.Repositories;
using CitizenDevelopment.WPF.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CitizenDevelopment.WPF.Commands.Data
{
    internal class UpdateData : BaseCommand
    {
        private readonly DataModel data;

        public UpdateData(DataModel data)
        {
            this.data = data;
        }

        public override async void Execute(object parameter)
        {
            var repository = new DataRepository();
            var result = await repository.TryUpdateDataAsync(data);

            ExecuteCallback?.Invoke(result);
        }
    }
}
