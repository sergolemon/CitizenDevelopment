using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CitizenDevelopment.WPF.Views.Data
{
    /// <summary>
    /// Interaction logic for DataList.xaml
    /// </summary>
    public partial class DataListPage : Page
    {
        public DataListPage()
        {
            InitializeComponent();
            DataContext = new DataListVm();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateDataPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //update
            var itemId = (int)((Button)sender).DataContext;
            var item = ((DataListVm)DataContext).Data.FirstOrDefault(x => x.Id == itemId);
            NavigationService.Navigate(new UpdateDataPage(item));
        }
    }
}
