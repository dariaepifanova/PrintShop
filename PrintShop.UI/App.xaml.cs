using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrintShop.UI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            /*/
            DefaultObjects.Create();
            Application.Current.Shutdown();
            /*/

            //
            var result = new LoginWindow().ShowDialog();
            if (result.HasValue && result.Value)
            //
            {
                var mainWnd = new MainWindow();
                mainWnd.ShowDialog();
            }
            Application.Current.Shutdown();
        }
    }
}
