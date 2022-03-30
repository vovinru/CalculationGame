using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculationGame2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinalPage : ContentPage
    {
        FinalPageViewModel _viewModel;

        public FinalPage(FinalPageViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;

            NavigationPage.SetHasNavigationBar(this, false);

        }

        private void ButtonOneMore_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new GamePage());
        }

        private void ButtonMainPage_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}