using IdraakApp.Views;
using Syncfusion.Licensing;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdraakApp
{
    public partial class App : Application
    {
        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzExMjM0QDMxMzgyZTMyMmUzMGJNZUF1RytQcUFUbFJuWEhoMWlLWi96eTh5U25IVEpuRVJWMWNtbGozU0E9");
            InitializeComponent();

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
