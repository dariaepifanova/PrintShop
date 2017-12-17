using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrintShop.data
{
    public class PrintItem
    {
        [Key]
        public int PrintItemId { get; set; }

        public string Title { get; set; }
        public string ImageName { get; set; }
    }
}
