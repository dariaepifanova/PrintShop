using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.data
{
    public static class OrdersManager
    {
        public static bool IsNewOrder;
        public static Order CurrentOrder { get; set; }
        public static Dictionary<Client, List<Order>> Orders { get; set; }

        public static void AddNewOrder()
        {
            CurrentOrder = new Order();
            IsNewOrder = false;
            var user = UsersManager.CurrentUser;
            if (!Orders.ContainsKey(user))
            {
                Orders.Add(user, new List<Order>());
            }
            Orders[user].Add(CurrentOrder);
        }

        static OrdersManager()
        {
            IsNewOrder = true;
            Orders = new Dictionary<Client, List<Order>>();
        }
        public static bool CheckDuplocateOrders()
        {
            bool state = false;
            int i=0;
            foreach (Order order in Orders[UsersManager.CurrentUser])
            {
                if (order.PrintItemId == CurrentOrder.PrintItemId
                   && order.ClothesSize == CurrentOrder.ClothesSize
                   && order.ClothesType == CurrentOrder.ClothesType) i++;
            }
            if (i > 1) state = true;
            return state;                  
        }
    }
}
