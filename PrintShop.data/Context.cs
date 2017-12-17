using PrintShop.data;
using System.Data.Entity;

namespace PrintShop.data
{
    class Context : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<PrintItem> PrintItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public Context() : base("PrintShop1DB")
        {

        }
    }
}

