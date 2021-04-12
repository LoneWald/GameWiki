using GameWiki.Models.Users;
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
    public partial class LoginSucces : ContentPage
    {
        public LoginSucces()
        {
            InitializeComponent();
            try
            {
                Info_label.Text = "С возвращением, " + CurrentUser.ThisUser.nickname;
            }
            catch
            {

            }
        }
    }
}