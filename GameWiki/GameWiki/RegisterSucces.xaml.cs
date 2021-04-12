using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameWiki.Models.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameWiki
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterSucces : ContentPage
    {
        public RegisterSucces()
        {
            InitializeComponent();
            try
            {
                Info_label.Text = "Приветствую тебя, " + CurrentUser.ThisUser.nickname;
            }
            catch
            {

            }
        }
    }
}