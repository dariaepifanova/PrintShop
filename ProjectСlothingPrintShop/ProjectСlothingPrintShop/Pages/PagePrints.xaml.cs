using ProjectСlothingPrintShop.BusinessLogic;
using ProjectСlothingPrintShop.Domains;
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
            var prints = Config.Repository.ReadPrints().ToList();
            prints.ForEach(p => p.ImageName = "../" + p.ImageName);
            productsPanel.ItemsSource = prints;
        }

        private List<PrintItem> GenerateItems(IEnumerable<string> names)
        {
            var items = new List<PrintItem>();
            foreach (var name in names)
            {
                var item = new PrintItem()
                {
                    Title = name.Replace("images/", "").Replace(".jpg", ""),
                    ImageName = "../"+name
                };
                items.Add(item);
            }
            return items;
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            int Id = (int) btn.Tag;
            var item = Config.Repository.ReadPrints().FirstOrDefault(x => x.Id == Id);
            if (OrdersManager.IsNewOrder)
            {
                OrdersManager.AddNewOrder();
            }
            OrdersManager.CurrentOrder.PrintItem = item;
            OrdersManager.CurrentOrder.AdoptionDate = DateTime.Today;
            NavigationService.Navigate(new Uri("Pages/PageСhoiceOptions.xaml", UriKind.Relative));
        }
    }
}
