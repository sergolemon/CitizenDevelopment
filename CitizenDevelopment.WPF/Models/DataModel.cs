using CitizenDevelopment.WPF.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenDevelopment.WPF.Models
{
    public class DataModel : BaseModel
    {
        int id;
        string applicationName, userName, comment = string.Empty;

        public int Id 
        { 
            get => id; 
            set { id = value; OnPropertyChanged("Id"); } 
        }
        public string ApplicationName 
        { 
            get => applicationName; 
            set { applicationName = value; OnPropertyChanged("ApplicationName"); } 
        }
        public string UserName 
        { 
            get => userName; 
            set { userName = value; OnPropertyChanged("UserName"); } 
        }
        public string Comment 
        { 
            get => comment; 
            set { comment = value; OnPropertyChanged("Comment"); } 
        }
    }
}
