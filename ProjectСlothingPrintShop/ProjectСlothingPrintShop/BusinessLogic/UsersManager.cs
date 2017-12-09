using ProjectСlothingPrintShop.DAL;
using ProjectСlothingPrintShop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectСlothingPrintShop.BusinessLogic
{
    public class UsersManager
    {
        static private List<Client> clients;

        static public Client CurrentUser { get; set; }

        static UsersManager()
        {
            clients = Config.Repository.ReadClients().ToList();
        }

        static public bool IsAuthenticated(AuthToken token)
        {
            if (clients == null) return false;
            var person = clients.FirstOrDefault(x => x.Login == token.Login);
            CurrentUser = person;
            return person != null ? person.Password == token.Password : false;
        }
    }
}
