using PrintShop.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.data.Model
{
    public class FinalProduct
    {
        [Key]
        public int FinalProductId { get; set; }
        public DateTime AdoptionDate { get; set; }
        public string ClothesSize { get; set; }
        public string ClothesType { get; set; }
    }
}
