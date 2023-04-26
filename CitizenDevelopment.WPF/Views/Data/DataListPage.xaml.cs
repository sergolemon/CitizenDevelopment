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
            vm.DeleteCommand.Executed += OnDeleteCommand;
            vm.GoUpdateCommand.Executed += OnGoUpdateCommand;

            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateDataPage());
        }

        private void OnGoUpdateCommand(object commandResult)
        {
            NavigationService.Navigate(new UpdateDataPage((DataModel)commandResult));
        }

        private void OnDeleteCommand(object commandResult)
        {
            var parsedResult = (ValueTuple<bool, DataModel>)commandResult;

            if (parsedResult.Item1)
            {
                this.ShowSuccessNotifyStandartAnimation("Success deleted.");
            }
            else
            {
                this.ShowFailureNotifyStandartAnimation("Failure deleted.");
            }
        }
    }
}
