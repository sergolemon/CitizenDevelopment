using CitizenDevelopment.WPF.Abstract;
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
    public class DeleteData : BaseCommand
    {
        protected override async Task<object> ExecuteCommandAsync(object parameter)
        {
            var repository = new DataRepository();
            var itemId = (int)parameter;
            var result = await repository.TryRemoveDataAsync(new Models.DataModel { Id = itemId });

            return (itemId, result);
        }
    }
}
