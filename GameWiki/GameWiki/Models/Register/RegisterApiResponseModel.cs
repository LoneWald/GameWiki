using System;
using System.Collections.Generic;
using System.Text;

namespace GameWiki.Models.Register
{

    public class RegisterApiResponseModel
    {

        public int id { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string nickname { get; set; }
        public bool isModerator { get; set; }
        public List<string> characters { get; set; }

    }
}
