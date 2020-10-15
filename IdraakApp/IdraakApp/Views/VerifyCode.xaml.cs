using IdraakApp.Resources.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdraakApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifyCode : ContentPage
    {
        public VerifyCode()
        {
            InitializeComponent();

            CultureInfo language = CultureInfo.InstalledUICulture;

            if (language.Name == "en")
                FlowDirection = FlowDirection.LeftToRight;
            else if (language.Name == "ar")
                FlowDirection = FlowDirection.RightToLeft;
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

                App.Current.MainPage = new NavigationPage(new VerifyCode());
            }
        }

        private async void Sign_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        private void TextChangePin1(object sender, TextChangedEventArgs e)
        {
            if (txtPin1.Text.Length >= 1)
            {
                txtPin2.Focus();
            }
        }

        private void TextChangePin2(object sender, TextChangedEventArgs e)
        {
            if (txtPin2.Text.Length >= 1)
            {
                txtPin3.Focus();
            }

            if (txtPin2.Text.Length < 1)
            {
                txtPin1.Focus();
            }
        }

        private void TextChangePin3(object sender, TextChangedEventArgs e)
        {
            if (txtPin3.Text.Length >= 1)
            {
                txtPin4.Focus();
            }

            if (txtPin3.Text.Length < 1)
            {
                txtPin2.Focus();
            }
        }

        private void TextChangePin4(object sender, TextChangedEventArgs e)
        {
            if (txtPin4.Text.Length < 1)
            {
                txtPin3.Focus();
            }
        }
    }
}