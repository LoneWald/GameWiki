using GameWiki.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameWiki
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void LoginClick(Object sender, EventArgs e)
        {
            var accountApiServises = new AccountApiServises();
            var content = await accountApiServises.AuthenticateUserAsync(LoginForm.Text, PasswordForm.Text);

            if (content != null)
            {
                await Navigation.PushAsync(new LoginSucces());
            }
            else
            {

            }
        }

        async void GoToRegisterPageClick(Object sender, EventArgs e)
        {
                await Navigation.PushAsync(new RegisterPage());
        }
    }
}