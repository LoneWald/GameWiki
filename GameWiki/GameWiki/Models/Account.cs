using System;
using System.Collections.Generic;
using System.Text;
using GameWiki.Models.Login;
using GameWiki.Models.Register;

namespace GameWiki.Models
{
    public class Account
    {
        public int id { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string nickname { get; set; }
        public bool? isModerator { get; set; }
        public List<string> characters { get; set; }

        public Account()
        {
            id = 0;
            email = null;
            login = null;
            password = null;
            nickname = null;
            isModerator = null;
            characters = null;
        }

        public Account(RegisterApiResponseModel user)
        {
            id = user.id;
            email = user.email;
            login = user.login;
            password = user.password;
            nickname = user.nickname;
            isModerator = user.isModerator;
            characters = user.characters;
        }

        public Account(LoginApiResponseModel user)
        {
            id = user.id;
            email = user.email;
            login = user.login;
            password = user.password;
            nickname = user.nickname;
            isModerator = user.isModerator;
            characters = user.characters;
        }
    }


}
