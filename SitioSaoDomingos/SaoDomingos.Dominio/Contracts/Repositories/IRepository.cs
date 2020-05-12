using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SaoDomingos.Dominio.Contracts.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T GetBy(Expression<Func<T, bool>> predicate = null);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Edit(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
