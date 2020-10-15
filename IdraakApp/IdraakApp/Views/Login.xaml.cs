using IdraakApp.Resources.MultiLanguage;
using IdraakApp.Services;
using IdraakApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Threading;
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

            CultureInfo language = CultureInfo.InstalledUICulture;

            if (language.Name == "en")
                FlowDirection = FlowDirection.LeftToRight;
            else if (language.Name == "ar")
                FlowDirection = FlowDirection.RightToLeft;

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

                txt_PhoneNumber.Placeholder = countryDetailVM.MobileMask;
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

        private async void Btn_Language(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet(AppResources.SelectLanguage, AppResources.Cancel, null, "English", "Arabic");

            CultureInfo currentLanguage = CultureInfo.InstalledUICulture;

            if (!string.IsNullOrWhiteSpace(action) && action != AppResources.Cancel && currentLanguage.EnglishName != action)
            {
                if (action == "English")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    AppResources.Culture = Thread.CurrentThread.CurrentUICulture;
                }
                else if (action == "Arabic")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
                    AppResources.Culture = Thread.CurrentThread.CurrentUICulture;
                }

                Application.Current.Properties["Language"] = action;
                await Application.Current.SavePropertiesAsync();

                App.Current.MainPage = new NavigationPage(new Login());
            }
        }
    }
}