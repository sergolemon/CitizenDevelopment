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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace CitizenDevelopment.WPF.ViewModels.Data
{
    internal class CreateDataVm : BaseModel
    {
        private BaseCommand createCommand;
        public BaseCommand CreateCommand
        {
            get
            {
                if (createCommand == null)
                {
                    createCommand = new CreateDataCommand();
                    createCommand.Executed += (commandResult) => 
                    {
                        if ((bool)commandResult)
                            Data = new DataModel();
                    };
                }

                return createCommand;
            }
        }

        public CreateDataVm()
        {
            Data = new DataModel();
        }

        private DataModel data;

        public DataModel Data 
        {
            get => data;
            set { data = value; OnPropertyChanged(nameof(Data)); }
        }
    }
}
