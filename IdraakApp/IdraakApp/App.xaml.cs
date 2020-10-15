
using IdraakApp.Resources.MultiLanguage;
using IdraakApp.Views;
using Syncfusion.Licensing;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace IdraakApp
{
    public partial class App : Application
    {
        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzMzNDM4QDMxMzgyZTMzMmUzMFQxMHhYVm5ZNnJpbGVwcVgrVDArYlVHU3ZHNnRxdjVZbWZUdHlvMFM0aW89");
            InitializeComponent();

            bool isLanguageExist = Application.Current.Properties.ContainsKey("Language");

            if (isLanguageExist)
            {
                string language = Application.Current.Properties["Language"] + "";

                if (language == "English")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    AppResources.Culture = Thread.CurrentThread.CurrentUICulture;
                }
                else if (language == "Arabic")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
                    AppResources.Culture = Thread.CurrentThread.CurrentUICulture;
                }
            }

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
