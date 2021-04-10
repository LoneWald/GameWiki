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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void RegisterClick(Object sender, EventArgs e)
        {
            var accountApiServises = new AccountApiServises();
            var content = await accountApiServises.RegisterUserAsync(EmailForm.Text, LoginForm.Text, PasswordForm.Text, NicknameForm.Text);

            if (content != null)
            {
                await Navigation.PushAsync(new RegisterSucces());
            }
            else
            {

            }
        }
    }
}