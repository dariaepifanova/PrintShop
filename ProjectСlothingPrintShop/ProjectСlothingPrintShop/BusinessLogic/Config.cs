using ProjectСlothingPrintShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectСlothingPrintShop.BusinessLogic
{
    public static class Config
    {
        public static IRepository Repository { get; set; }

        static Config()
        {
            Repository = new FileRepository();
        }
    }
}
