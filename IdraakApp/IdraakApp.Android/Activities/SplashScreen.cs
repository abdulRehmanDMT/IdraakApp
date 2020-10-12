using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IdraakApp.Droid.Activities
{
    [Activity(Theme = "@style/AppTheme", Icon = "@drawable/logo", Label = "Idraak", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, NoHistory = true)]

    public class SplashScreen : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreen);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window window = Window;
                window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

                View view = Window.DecorView;
                view.SystemUiVisibility = StatusBarVisibility.Hidden;
                view.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.HideNavigation;

                GC.Collect();
            }

            await Task.Delay(2500);


            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}