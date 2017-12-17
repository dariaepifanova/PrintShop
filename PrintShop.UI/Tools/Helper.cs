using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace PrintShop.UI.Tools
{
    public static class Helper
    {

        public static BitmapImage GetImageFromResource(string imageName)
        {
            return new BitmapImage(new Uri(@"pack://application:,,,/"
             + Assembly.GetExecutingAssembly().GetName().Name
             + ";component/"
             + imageName, UriKind.Absolute));
        }
    }
}
