using PrintShop.data.Iterfaces;
using System.Collections.Generic;
using System.Linq;

namespace PrintShop.data.Repository
{
    internal class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context) { }

        public Order GetTheLastOrder()
        {
            return _context.Order.ToList().Last();
        }
        public int OrdersQuantity()
        {
            return _context.Order.ToList().Count;
        }
    }
}
