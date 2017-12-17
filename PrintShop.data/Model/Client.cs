using System.ComponentModel.DataAnnotations;

namespace PrintShop.data
{
    public class Client : AuthToken
    {
        [Key]
        public int ClientId { get; set; }

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

    }
}
