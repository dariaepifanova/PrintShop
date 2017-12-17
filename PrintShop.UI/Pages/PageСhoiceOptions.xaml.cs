using PrintShop.data;
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

namespace PrintShop.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageСhoiceOptions.xaml
    /// </summary>
    public partial class PageСhoiceOptions : Page
    {
        public PageСhoiceOptions()
        {
            InitializeComponent();
            this.Loaded += PageСhoiceOptions_Loaded;
        }

        private void PageСhoiceOptions_Loaded(object sender, RoutedEventArgs e)
        {
            string[] clothesTypes = { "толстовка", "кепка", "футболка", "шорты" };
            string[] clothesSizes = { "XS", "S", "M", "L", "XL", "XXL" };
            int[] clothesQuantity = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listBoxClothesTypes.ItemsSource = clothesTypes;
            listBoxClothesSize.ItemsSource = clothesSizes;
            comboBoxClothesQuantity.ItemsSource = clothesQuantity;
            //labelPrint.Content = $" Вы выбрали - {OrdersManager.CurrentOrder.PrintItem.Title}";
            //String stringPath = OrdersManager.CurrentOrder.PrintItem.ImageName;
            //Uri imageUri = new Uri(stringPath, UriKind.Relative);
            //BitmapImage imageBitmap = new BitmapImage(imageUri);
            //Image myImage = new Image();
            //imagePrint.Source = imageBitmap;
        }

        private bool IsSelectionsDone()
        {
            object obj = listBoxClothesTypes.SelectedItem;
            if (obj == null)
            {
                MessageBox.Show("Выберите тип одежды!");
                return false;
            }
            string clothesType = obj.ToString();
            obj = listBoxClothesSize.SelectedItem;
            if (obj == null)
            {
                MessageBox.Show("Выберите размер одежды!");
                return false;
            }
            string clothesSize = obj.ToString();
            obj = comboBoxClothesQuantity.SelectedItem;
            if (obj == null)
            {
                MessageBox.Show("Выберите количество!");
                return false;
            }
            int clothesQuantity = int.Parse(obj.ToString());

            OrdersManager.CurrentOrder.ClothesSize = clothesSize;
            OrdersManager.CurrentOrder.ClothesType = clothesType;
            OrdersManager.CurrentOrder.Quantity = clothesQuantity;
            var currentOrder = OrdersManager.CurrentOrder;
            if(OrdersManager.CheckDuplocateOrders())
            {
                MessageBox.Show("Вы уже добавили данный продукт");
                return false;
            }
            return true;
        }

        private void BtnDoneClick(object sender, RoutedEventArgs e)
        {
            if (!IsSelectionsDone()) return;
            NavigationService.Navigate(new Uri("Pages/PageOrder.xaml", UriKind.Relative));
        }

        private void BtnShopingClick(object sender, RoutedEventArgs e)
        {
            if (!IsSelectionsDone()) return;
            if (MessageBox.Show("Вы не сможете изменить добавленные товары после нажатия OK", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                OrdersManager.IsNewOrder = true;
                NavigationService.Navigate(new Uri("Pages/PagePrints.xaml", UriKind.Relative));
            }
        }
    }
}
