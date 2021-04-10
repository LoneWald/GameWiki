using System;
using System.Collections.Generic;
using System.Text;

namespace GameWiki.Models.Register
{
    public class RegisterApiRequestModel
    {

        public RegisterApiRequestModel()
        {

        }

        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
    }
}
