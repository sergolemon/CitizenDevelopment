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
    internal class CreateDataVm : BaseModel
    {
        private readonly DataRepository _dataRepository;

        public ICommand CreateCommand { get; set; }

        public CreateDataVm()
        {
            CreateCommand = new CreateData(this);
            Data = new DataModel();
        }

        private DataModel data;
        public DataModel Data 
        {
            get => data;
            set { data = value; OnPropertyChanged("Data"); }
        }
    }
}
