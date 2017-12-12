using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectСlothingPrintShop.Domains
{
    public class AuthToken
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public AuthToken(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public AuthToken()
        {

        }
    }
}
