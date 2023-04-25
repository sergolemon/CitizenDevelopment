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

            var notify = new TextBlock();
            notify.Width = 0;
            notify.TextWrapping = TextWrapping.NoWrap;
            notify.Height = double.NaN;
            notify.Padding = new Thickness(5, 5, 5, 5);
            notify.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            notify.FontSize = 15;
            notify.FontWeight = FontWeights.Bold;
            notify.Margin = new Thickness(5, 5, 5, 5);
            notify.HorizontalAlignment = HorizontalAlignment.Right;
            notify.VerticalAlignment = VerticalAlignment.Top;
            notify.Visibility = Visibility.Visible;

            Grid.Children.Add(notify);

            var vm = new DataListVm();
            vm.DeleteCommand.ExecuteCallback += (result) => 
            {
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

                DoubleAnimation notifyAnimation = new DoubleAnimation();
                notifyAnimation.From = 0;
                notifyAnimation.To = 190;
                notifyAnimation.AutoReverse = true;
                notifyAnimation.Duration = TimeSpan.FromSeconds(1);
                notify.BeginAnimation(TextBlock.WidthProperty, notifyAnimation);
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
