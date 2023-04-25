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
    internal class CreateData : BaseCommand
    {
        private readonly DataModel data;

        public CreateData(DataModel data) 
        { 
            this.data = data;
        }

        public override async void Execute(object parameter)
        {
            var repository = new DataRepository();
            var result = await repository.TryCreateDataAsync(data);

            ExecuteCallback?.Invoke(result);
        }
    }
}
