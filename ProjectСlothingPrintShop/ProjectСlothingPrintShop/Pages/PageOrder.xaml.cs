using ProjectСlothingPrintShop.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectСlothingPrintShop.Pages
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
            listBoxDelivery.ItemsSource = Config.Repository.ReadDeliveryOptions();
            var user = UsersManager.CurrentUser;
            productsPanel.ItemsSource = OrdersManager.Orders[user];
        }

        private void BtnDoneClick(object sender, RoutedEventArgs e)
        {
            var user = UsersManager.CurrentUser;
            var orders = OrdersManager.Orders[user];
            if (!datePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Выберите дату получения");
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
            Config.Repository.SaveOrders(orders);
            MessageBox.Show("Заказ оформлен (файл orders.xml)");
        }
    }
}
