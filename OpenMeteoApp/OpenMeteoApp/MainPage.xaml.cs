using OpenMeteoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenMeteoApp
{
    public partial class MainPage : ContentPage
    {
        MainViewModel mainViewModel; 
        public MainPage()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;
        }

        private async void SearchButton_ClickedAsync(object sender, EventArgs e)
        {
            await mainViewModel.SearchGeolocationAsync(search.Text);
        }

        private async void DetectButton_ClickedAsync(object sender, EventArgs e)
        {
            await mainViewModel.GetWeatherForGeolocationAsync();
        }
    }
}
