using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculationGame2
{

    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;

        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
