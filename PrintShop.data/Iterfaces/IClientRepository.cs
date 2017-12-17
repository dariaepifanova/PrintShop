using System.Collections.Generic;

namespace PrintShop.data.Iterfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        IEnumerable<Client> GetClients();
    }
}
