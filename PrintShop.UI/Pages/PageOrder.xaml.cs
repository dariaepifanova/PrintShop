using PrintShop.data;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PrintShop.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOrder.xaml
    /// </summary>
    public partial class PageOrder : Page
    {
        public PageOrder()
        {
            InitializeComponent();
            this.Loaded += PageOrder_Loaded;
        }

        private void PageOrder_Loaded(object sender, RoutedEventArgs e)
        {
            string[] delivery = { "почтой", "курьером", "самовывоз" };
            listBoxDelivery.ItemsSource = delivery;
            var user = UsersManager.CurrentUser;
            productsPanel.ItemsSource = OrdersManager.Orders[user];
        }

        private void BtnDoneClick(object sender, RoutedEventArgs e)
        {
            var user = UsersManager.CurrentUser;
            var orders = OrdersManager.Orders[user];
            if (!datePicker.SelectedDate.HasValue || datePicker.SelectedDate<=DateTime.Now)
            {
                MessageBox.Show("Выберите корректную дату получения");
                return;
            }
            object obj = listBoxDelivery.SelectedItem;
            if (obj == null)
            {
                MessageBox.Show("Выберите способ получения");
                return;
            }
            string delivery = obj.ToString();
            DateTime exportDate = datePicker.SelectedDate.Value;
            orders.ForEach(o => o.ExportDate = exportDate);
            orders.ForEach(o => o.Delivery = delivery);
            
            using (var unitOfWork = new UnitOfWork())
            {
                var clientDb = unitOfWork.Clients.First(o=>o.ClientId==user.ClientId);
                unitOfWork.Prints.GetPrints();
                orders.ForEach(o => o.Client = clientDb);
                Order order = orders[0];
                var itemDb = unitOfWork.Prints.First(o => o.PrintItemId == order.PrintItemId);
                if(unitOfWork.Orders.OrdersQuantity()==0) orders.ForEach(o => o.OrderId = 1);
                else orders.ForEach(o => o.OrderCode = unitOfWork.Orders.GetTheLastOrder().OrderCode + 1);
                foreach (Order newOrder in orders)
                {
                    newOrder.OrderId = unitOfWork.Orders.OrdersQuantity() + 1;
                    unitOfWork.Orders.Add(newOrder);
                    unitOfWork.Complete();
                }
               
            }
            MessageBox.Show("Заказ оформлен");
        }
    }
}
