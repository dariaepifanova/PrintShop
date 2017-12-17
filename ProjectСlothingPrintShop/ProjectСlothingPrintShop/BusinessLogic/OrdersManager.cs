using ProjectСlothingPrintShop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectСlothingPrintShop.BusinessLogic
{
    public static class OrdersManager
    {
        public static bool IsNewOrder;
        public static OrderDetails CurrentOrder { get; set; }
        public static Dictionary<Client, List<OrderDetails>> Orders { get; set; }

        public static void AddNewOrder()
        {
            CurrentOrder = new OrderDetails();
            IsNewOrder = false;
            var user = UsersManager.CurrentUser;
            if (!Orders.ContainsKey(user))
            {
                Orders.Add(user, new List<OrderDetails>());
            }
            Orders[user].Add(CurrentOrder);
        }

        static OrdersManager()
        {
            IsNewOrder = true;
            Orders = new Dictionary<Client, List<OrderDetails>>();
        }
    }
}
