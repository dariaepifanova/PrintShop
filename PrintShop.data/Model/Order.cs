using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrintShop.data;

namespace PrintShop.data
{
    public class Order 
    {

        [Key, Column(Order = 0)]
        public int OrderId { get; set; }

        [Key, Column(Order = 1)]
        public int ClientId { get; set; }

        [Key, Column(Order = 2)]
        public DateTime AdoptionDate { get; set; }

        [Key, Column(Order = 3)]
        public int PrintItemId { get; set; }

        public Client Client { get; set; }

        public PrintItem PrintItem { get; set; }

        public DateTime ExportDate { get; set; }

        public string Delivery { get; set; }

        public int Quantity { get; set; }

        public string ClothesSize { get; set; }

        public string ClothesType { get; set; }

    }
}
