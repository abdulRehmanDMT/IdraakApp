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
    public partial class SignUp : ContentPage
    {
        public SignUp()
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

                App.Current.MainPage = new NavigationPage(new SignUp());
            }
        }
    }
}