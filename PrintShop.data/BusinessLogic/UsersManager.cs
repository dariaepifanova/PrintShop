using System.Collections.Generic;
using System.Linq;

namespace PrintShop.data
{
    public class UsersManager
    {
        static private IEnumerable<Client> clients;

        static public Client CurrentUser { get; set; }

        static UsersManager()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                clients = unitOfWork.Clients.GetClients();
                unitOfWork.Dispose();
            }
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
