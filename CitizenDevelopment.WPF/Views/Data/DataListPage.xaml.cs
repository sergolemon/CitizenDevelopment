using CitizenDevelopment.WPF.Extensions;
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
using System.Windows.Media.Animation;
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

            var vm = new DataListVm();
            vm.DeleteCommand.ExecuteCallback += (result) => 
            {
                var notify = ((MainWindow)Window.GetWindow(this)).Notify;

                if (((ValueTuple<int, bool>)result).Item2)
                {
                    notify.Text = "Success deleted";
                    notify.Background = new SolidColorBrush(Color.FromRgb(90, 230, 90));
                }
                else
                {
                    notify.Text = "Failed deleted";
                    notify.Background = new SolidColorBrush(Color.FromRgb(250, 90, 90));
                }

                notify.BeginAnimation(TextBlock.WidthProperty, this.GetNotifyStandartAnimation());
            };

            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateDataPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var itemId = (int)((Button)sender).DataContext;
            var item = ((DataListVm)DataContext).Data.FirstOrDefault(x => x.Id == itemId);
            NavigationService.Navigate(new UpdateDataPage(item));
        }
    }
}
