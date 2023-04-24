using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenDevelopment.WPF.ViewModels
{
    internal class DataListVm : BaseModel
    {
        private readonly DataRepository _dataRepository;

        public DataListVm() 
        {
            _dataRepository = new DataRepository();
            Data = new ObservableCollection<DataModel>(_dataRepository.GetDataListAsync().Result);
        }

        public ObservableCollection<DataModel> Data { get; set; }
    }
}
