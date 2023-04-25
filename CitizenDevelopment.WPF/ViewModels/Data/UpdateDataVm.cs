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

namespace CitizenDevelopment.WPF.ViewModels.Data
{
    internal class UpdateDataVm : BaseViewModel
    {
        public BaseCommand UpdateCommand { get; }

        private DataModel data;

        public UpdateDataVm(DataModel updatingData)
        {
            data = updatingData;
            UpdateCommand = new UpdateData(data);
        }

        public string UserName
        {
            get => data.UserName;
            set { data.UserName = value; OnPropertyChanged("UserName"); }
        }

        public string ApplicationName
        {
            get => data.ApplicationName;
            set { data.ApplicationName = value; OnPropertyChanged("ApplicationName"); }
        }

        public string Comment
        {
            get => data.Comment;
            set { data.Comment = value; OnPropertyChanged("Comment"); }
        }
    }
}
