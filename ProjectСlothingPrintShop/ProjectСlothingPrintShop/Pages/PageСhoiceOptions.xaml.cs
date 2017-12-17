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
            listBoxClothesTypes.ItemsSource = Config.Repository.ReadClothesTypes();
            listBoxClothesSize.ItemsSource = Config.Repository.ReadClothesSizes();
            labelPrint.Content = OrdersManager.CurrentOrder.PrintItem.Title;
            String stringPath = OrdersManager.CurrentOrder.PrintItem.ImageName;
            Uri imageUri = new Uri(stringPath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            imagePrint.Source = imageBitmap;
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
            OrdersManager.CurrentOrder.ClothesSize = clothesSize;
            OrdersManager.CurrentOrder.ClothesType = clothesType;
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
            OrdersManager.IsNewOrder = true;
            NavigationService.Navigate(new Uri("Pages/PagePrints.xaml", UriKind.Relative));
        }
    }
}
