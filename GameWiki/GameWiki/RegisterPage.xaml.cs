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
            if (EmailForm.Text == null || LoginForm.Text == null || PasswordForm.Text == null || NicknameForm.Text == null)
            {
                var toastmessage = "Need to fill everything";
                DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
            }
            else
            {
                var accountApiServises = new AccountApiServises();
                var content = await accountApiServises.RegisterUserAsync(EmailForm.Text, LoginForm.Text, PasswordForm.Text, NicknameForm.Text);

                if (content != null)
                {
                    await Navigation.PushAsync(new RegisterSucces());
                }
                else
                {
                    var toastmessage = "Failed to create";
                    DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
                }
            }
        }
    }
}