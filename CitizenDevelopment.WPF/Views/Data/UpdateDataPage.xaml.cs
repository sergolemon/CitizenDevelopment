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

            var vm = new UpdateDataVm(updatingData);
            vm.UpdateCommand.ExecuteCallback += (result) => 
            {
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

                DoubleAnimation notifyAnimation = new DoubleAnimation();
                notifyAnimation.From = 0;
                notifyAnimation.To = 190;
                notifyAnimation.AutoReverse = true;
                notifyAnimation.Duration = TimeSpan.FromSeconds(1);
                notify.BeginAnimation(TextBlock.WidthProperty, notifyAnimation);
            };

            DataContext = vm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
