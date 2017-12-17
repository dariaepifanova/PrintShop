using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.data.Iterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetTheLastOrder();
        int OrdersQuantity();
    }
}
