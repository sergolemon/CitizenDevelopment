using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Commands;
using CitizenDevelopment.WPF.Commands.Data;
using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CitizenDevelopment.WPF.ViewModels.Data
{
    internal class UpdateDataVm : BaseModel
    {
        private BaseCommand updateCommand;
        public BaseCommand UpdateCommand
        {
            get
            {
                if(updateCommand == null)
                    updateCommand = new UpdateDataCommand();

                return updateCommand;
            }
        }

        public UpdateDataVm(DataModel updatingData)
        {
            Data = updatingData;
        }

        private DataModel data;

        public DataModel Data
        {
            get => data;
            set { data = value; OnPropertyChanged(nameof(Data)); }
        }
    }
}
