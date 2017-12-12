using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectСlothingPrintShop.Domains
{
    public class Client : AuthToken
    {
        public string IdClient { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
