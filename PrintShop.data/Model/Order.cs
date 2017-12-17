using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrintShop.data;

namespace PrintShop.data
{
    public class Order 
    {
        [Key]
        public int OrderId { get; set; }
        [NotMapped]
        public int OrderCode { get; set; }

        public int ClientId { get; set; }
        public int PrintItemId { get; set; }

        public Client Client { get; set; }
        public PrintItem PrintItem { get; set; }
        [NotMapped]
        public string PrintTitle { get; set; }
        [NotMapped]
        public string PrintImageName { get; set; }
        public string ClothesSize { get; set; }

        public string ClothesType { get; set; }

        public int Quantity { get; set; }

        public DateTime AdoptionDate { get; set; }

        public DateTime ExportDate { get; set; }

        public string Delivery { get; set; }





    }
}
