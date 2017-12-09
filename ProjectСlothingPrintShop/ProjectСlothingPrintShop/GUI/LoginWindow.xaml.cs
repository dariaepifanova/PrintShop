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
using System.Windows.Shapes;

namespace ProjectСlothingPrintShop.GUI
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            labelMessage.Visibility = Visibility.Hidden;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            string login = txtBoxLogin.Text;
            string password = txtBoxPassword.Password;
            var token = new AuthToken(login, password);
            bool isAuth = UsersManager.IsAuthenticated(token);
            if (!isAuth)
            {
                labelMessage.Visibility = Visibility.Visible;
            }
            else
            {
                this.DialogResult = true;
                this.Hide();
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Hide();
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            labelMessage.Visibility = Visibility.Hidden;
        }
    }
}
