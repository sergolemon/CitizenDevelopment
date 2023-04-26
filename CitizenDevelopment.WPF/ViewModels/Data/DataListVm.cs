using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Commands;
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
    internal class DataListVm : BaseModel
    {
        private BaseCommand deleteCommand;
        public BaseCommand DeleteCommand 
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new DeleteDataCommand();
                    deleteCommand.Executed += (commandResult) => 
                    {
                        var parsedResult = (ValueTuple<bool, DataModel>)commandResult;

                        if(parsedResult.Item1)
                            Data.Remove(parsedResult.Item2);
                    };
                }

                return deleteCommand;
            }
        }

        private BaseCommand goUpdateCommand;
        public BaseCommand GoUpdateCommand
        {
            get
            {
                if (goUpdateCommand == null)
                    goUpdateCommand = new RelayCommand(async (parameter) => parameter);

                return goUpdateCommand;
            }
        }

        public ObservableCollection<DataModel> Data { get; set; }

        public DataListVm()
        {
            Data = new ObservableCollection<DataModel>(
                new DataRepository().GetDataListAsync().Result);
        }
    }
}
