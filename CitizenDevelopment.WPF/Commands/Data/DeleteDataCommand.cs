using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenDevelopment.WPF.Commands.Data
{
    public class DeleteDataCommand : BaseCommand
    {
        protected override async Task<object> Handle(object parameter)
        {
            var data = (DataModel)parameter;

            var dataRepository = new DataRepository();
            var result = await dataRepository.TryRemoveDataAsync(data);

            return (result, data);
        }
    }
}
