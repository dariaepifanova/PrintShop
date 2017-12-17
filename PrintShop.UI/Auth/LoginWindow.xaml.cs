using PrintShop.data;
using System.Windows;

namespace PrintShop.UI
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
