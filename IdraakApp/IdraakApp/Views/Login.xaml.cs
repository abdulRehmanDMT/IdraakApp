using IdraakApp.Services;
using IdraakApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdraakApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        HttpRequests httpRequests;
        Response response;

        public Login()
        {
            InitializeComponent();

            httpRequests = new HttpRequests();
            response = new Response();

            Device.BeginInvokeOnMainThread(async () => 
            {
                ShowActivityIndicator();
                await FetchAndBindData();
                HideActivityIndicator();
            });
        }

        private async Task FetchAndBindData()
        {
            response = await httpRequests.GetLocationByIp();

            if(response.Status == ResponseStatus.OK)
            {
                IPCountryVM iPCountryVM = JsonConvert.DeserializeObject<IPCountryVM>(response.ResultData.ToString());

                response = await httpRequests.GetCountryDetailByCountryCode(iPCountryVM.Country);

                CountryDetailVM countryDetailVM = JsonConvert.DeserializeObject<CountryDetailVM>(response.ResultData.ToString());

                MainContainer.IsVisible = true;

                lbl_CountryCode.Text = countryDetailVM.CountryCode;
                MaskedBehavior.Mask = countryDetailVM.MobileMask;
            }
        }

        private async void Sign_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerifyCode());
        }

        private void ShowActivityIndicator()
        {
            ActivityIndicator.IsVisible = true;
            ActivityIndicator.IsRunning = true;
        }

        private void HideActivityIndicator()
        {
            ActivityIndicator.IsRunning = false;
            ActivityIndicator.IsVisible = false;
        }
    }
}