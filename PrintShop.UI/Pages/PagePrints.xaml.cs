using PrintShop.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PrintShop.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePrints.xaml
    /// </summary>
    public partial class PagePrints : Page
    {
        public PagePrints()
        {
            InitializeComponent();
            this.Loaded += PagePrints_Loaded;
        }

        private void PagePrints_Loaded(object sender, RoutedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var prints = unitOfWork.Prints.GetPrints();
                prints.ForEach(p => p.ImageName = "../" + p.ImageName);
                productsPanel.ItemsSource = prints;
                unitOfWork.Dispose();
            }
        }

        private List<PrintItem> GenerateItems(IEnumerable<string> names)
        {
            var items = new List<PrintItem>();
            foreach (var name in names)
            {
                var item = new PrintItem()
                {
                    Title = name.Replace("images/", "").Replace(".jpg", ""),
                    ImageName = "../" + name
                };
                items.Add(item);
            }
            return items;
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            int Id = (int)btn.Tag;

            if (OrdersManager.IsNewOrder)
            {
                OrdersManager.AddNewOrder();
            }
            using (var unitOfWork = new UnitOfWork())
            {
                var item = unitOfWork.Prints.First(x => x.PrintItemId == Id);
                var itemIdDb = item.PrintItemId;
                OrdersManager.CurrentOrder.PrintItemId = itemIdDb;
                unitOfWork.Dispose();
            }
            OrdersManager.CurrentOrder.AdoptionDate = DateTime.Today;
            NavigationService.Navigate(new Uri("Pages/PageСhoiceOptions.xaml", UriKind.Relative));
        }
    }
}
