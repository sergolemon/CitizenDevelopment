using CitizenDevelopment.WPF.Extensions;
using CitizenDevelopment.WPF.Models;
using CitizenDevelopment.WPF.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class UpdateDataPage : Page
    {
        public UpdateDataPage(DataModel updatingData)
        {
            InitializeComponent();

            var vm = new UpdateDataVm(updatingData);
            vm.UpdateCommand.ExecuteCallback += (result) => 
            {
                var notify = ((MainWindow)Window.GetWindow(this)).Notify;

                if((bool)result)
                {
                    notify.Text = "Success updated";
                    notify.Background = new SolidColorBrush(Color.FromRgb(90, 230, 90));
                }
                else
                {
                    notify.Text = "Failed updated";
                    notify.Background = new SolidColorBrush(Color.FromRgb(250, 90, 90));
                }

                notify.BeginAnimation(TextBlock.WidthProperty, this.GetNotifyStandartAnimation());
            };

            DataContext = vm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
