﻿using CitizenDevelopment.WPF.Abstract;
using CitizenDevelopment.WPF.Extensions;
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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class CreateDataPage : Page
    {
        public CreateDataPage()
        {
            InitializeComponent();

            var vm = new CreateDataVm();
            vm.CreateCommand.Executed += OnCreateCommand;

            DataContext = vm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OnCreateCommand(object commandResult)
        {
            var parsedResult = (bool)commandResult;

            if (parsedResult)
            {
                this.ShowSuccessNotifyStandartAnimation("Success created.");
            }
            else
            {
                this.ShowFailureNotifyStandartAnimation("Failure created.");
            }
        }
    }
}
