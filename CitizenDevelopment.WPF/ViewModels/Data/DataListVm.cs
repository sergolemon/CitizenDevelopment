using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Commands.Data;
using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CitizenDevelopment.WPF.ViewModels.Data
{
    public class DataListVm : BaseViewModel
    {
        public BaseCommand DeleteCommand { get; }

        public ObservableCollection<DataModel> Data { get; set; }

        public DataListVm()
        {
            Data = new ObservableCollection<DataModel>(
                new DataRepository().GetDataListAsync().Result);

            DeleteCommand = new DeleteData();
            DeleteCommand.ExecuteCallback += (result) =>
            {
                var parsedResult = (ValueTuple<int, bool>)result;

                if(parsedResult.Item2)
                    Data.Remove(Data.FirstOrDefault(x => x.Id == parsedResult.Item1));
            };
        }
    }
}
