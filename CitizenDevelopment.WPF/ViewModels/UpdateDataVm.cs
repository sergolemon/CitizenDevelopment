using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Commands.Data;
using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CitizenDevelopment.WPF.ViewModels
{
    internal class UpdateDataVm : BaseModel
    {
        private readonly DataRepository _dataRepository;

        public ICommand UpdateCommand { get; set; }

        public UpdateDataVm(DataModel updatingData)
        {
            _dataRepository = new DataRepository();
            Data = updatingData;
            UpdateCommand = new UpdateData(this);
        }

        private DataModel data;
        public DataModel Data
        {
            get => data;
            set { data = value; OnPropertyChanged("Data"); }
        }
    }
}
