using System;
using PrintShop.data;
using PrintShop.data.Iterfaces;
using PrintShop.data.Repository;

namespace PrintShop.data
{
    public class UnitOfWork : IDisposable
    {
        Context _context = new Context();

        public IClientRepository Clients { get; }
        public IPrintItemRepository Prints { get; }
        public IOrderRepository Orders { get; }

        public UnitOfWork()
        {
            Clients = new ClientRepository(_context);
            Prints = new PrintItemRepository(_context);
            Orders = new OrderRepository(_context);
        }
        
        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        } 
    }
}

