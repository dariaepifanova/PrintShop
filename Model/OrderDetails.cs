using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectСlothingPrintShop.Domains
{
    public class OrderDetails
    {
        public DateTime AdoptionDate { get; set; }
        public DateTime ExportDate { get; set; }
        public string ClothesSize { get; set; }
        public string ClothesType { get; set; }
        public PrintItem PrintItem { get; set; }
        public string Delivery { get; set; }
    }
}
