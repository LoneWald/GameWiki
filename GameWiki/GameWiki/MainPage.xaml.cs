using GameWiki.Servises;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameWiki
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void RegisterClick(Object sender, EventArgs e)
        {

            var content = await ApiServises.ServiceClientInstance.RegisterUserAsync(EmailForm.Text, LoginForm.Text, PasswordForm.Text, NicknameForm.Text);

            if(content != null)
            {
                await Navigation.PushAsync(new Dashboardpage());
            }
            else
            {
                await Navigation.PushAsync(new DashPage());
            }
        }

        async void SingInClick(Object sender, EventArgs e)
        {

            var content = await ApiServises.ServiceClientInstance.AuthenticateUserAsync(LoginForm.Text, PasswordForm.Text);

            if (content != null)
            {
                label_123.Text = content;
            }
            else
            {
                label_123.Text = "Не пашет!";
            }
        }
    }
}
