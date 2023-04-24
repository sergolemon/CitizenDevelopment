using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenDevelopment.WPF.ViewModels
{
    internal class UpdateDataVm : BaseModel
    {
        private readonly DataRepository _dataRepository;

        public UpdateDataVm(DataModel updatingData)
        {
            _dataRepository = new DataRepository();
            Data = updatingData;
        }

        private DataModel data;
        public DataModel Data
        {
            get => data;
            set { data = value; OnPropertyChanged("Data"); }
        }
    }
}
