using ProjectСlothingPrintShop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectСlothingPrintShop.DAL
{
    public interface IRepository
    {
        IEnumerable<Client> ReadClients();
        IEnumerable<PrintItem> ReadPrints();

        IEnumerable<string> ReadClothesTypes();

        IEnumerable<string> ReadClothesSizes();

        IEnumerable<string> ReadPrintsImages();

        IEnumerable<string> ReadDeliveryOptions();

        void SaveOrders(List<OrderDetails> orders);
    }
}
