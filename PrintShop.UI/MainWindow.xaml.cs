using PrintShop.data;
using System.Windows;

namespace PrintShop.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Greetings(UsersManager.CurrentUser);
        }

        private void Greetings(Client user)
        {
            if (user == null) return;
            labelGreetings.Content = $"Вы вошли как: {user.Name} {user.Lastname}";
        }

    }
}
