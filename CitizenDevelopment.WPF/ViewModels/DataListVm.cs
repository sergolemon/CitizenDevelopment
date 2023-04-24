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

namespace CitizenDevelopment.WPF.ViewModels
{
    public class DataListVm : BaseModel
    {
        private readonly DataRepository _dataRepository;
        public ICommand DeleteCommand { get; set; }

        public DataListVm() 
        {
            _dataRepository = new DataRepository();
            Data = new ObservableCollection<DataModel>(_dataRepository.GetDataListAsync().Result);
            DeleteCommand = new DeleteData(this);
        }

        public ObservableCollection<DataModel> Data { get; set; }
    }
}
