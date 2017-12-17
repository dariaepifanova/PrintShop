using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PrintShop.data
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        protected Context _context;
        public Repository(Context context)
        {
            _context = context;
        }
        public void Add(T item)
        {
            //_context.Set<T>().Add(item);
            _context.Entry(item).State = EntityState.Added;
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public T Last(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().LastOrDefault(predicate);
        }

        public void Remove(T item)
        {
            //_context.Set<T>().Remove(item);
            _context.Entry(item).State = EntityState.Deleted;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public void Modified(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}

