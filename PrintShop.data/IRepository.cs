using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VT.data.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        T First(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        void Modified(T item);
    }
}

