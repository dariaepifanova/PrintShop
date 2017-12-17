using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProjectСlothingPrintShop.Tools
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
