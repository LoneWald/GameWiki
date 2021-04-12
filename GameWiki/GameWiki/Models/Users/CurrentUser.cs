using GameWiki.Models.Login;
using GameWiki.Models.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWiki.Models.Users
{
    class CurrentUser : Account
    {
        protected static CurrentUser _ThisUser;
        public static CurrentUser ThisUser
        {
            get
            {
                if (_ThisUser == null)
                    _ThisUser = new CurrentUser();
                return _ThisUser;
            }
        }

        public CurrentUser()
            : base()
        {
            _ThisUser = this;
        }

        public CurrentUser(RegisterApiResponseModel user)
            :base(user)
        {
            _ThisUser = this;
        }

        public CurrentUser(LoginApiResponseModel user)
            : base(user)
        {
            _ThisUser = this;
        }
    }
}
