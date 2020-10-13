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
            SyncfusionLicenseProvider.RegisterLicense("MzMzNDM4QDMxMzgyZTMzMmUzMFQxMHhYVm5ZNnJpbGVwcVgrVDArYlVHU3ZHNnRxdjVZbWZUdHlvMFM0aW89");
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
