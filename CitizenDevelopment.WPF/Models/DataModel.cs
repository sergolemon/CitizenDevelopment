using CitizenDevelopment.WPF.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenDevelopment.WPF.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string ApplicationName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
    }
}
