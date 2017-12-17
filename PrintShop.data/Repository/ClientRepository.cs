using PrintShop.data.Iterfaces;
using System.Collections.Generic;
using System.Linq;

namespace PrintShop.data.Repository
{
    internal class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(Context context) : base(context) {}

        public IEnumerable<Client> GetClients()
        {
            return _context.Client.ToList();
        }
    }
}
