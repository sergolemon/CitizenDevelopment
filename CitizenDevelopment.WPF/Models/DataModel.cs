using CitizenDevelopment.WPF.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CitizenDevelopment.WPF.Models
{
    public class DataModel : BaseModel
    {
        private int id;
        private string userName, applicationName, comment = string.Empty;

        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string UserName
        {
            get => userName;
            set { userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        public string ApplicationName
        {
            get => applicationName;
            set { applicationName = value; OnPropertyChanged(nameof(ApplicationName)); }
        }

        public string Comment
        {
            get => comment;
            set { comment = value; OnPropertyChanged(nameof(Comment)); }
        }
    }
}
