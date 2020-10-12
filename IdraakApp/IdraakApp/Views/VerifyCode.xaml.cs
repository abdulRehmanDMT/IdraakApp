using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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