using SaoDomingos.Dominio.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace SaoDomingos.Dados.EF
{
    public class RepositoryEF<T> : IRepository<T> where T : class
    {
        private AppContexto _ctx = null;
        DbSet<T> _dbSet;

        public RepositoryEF(AppContexto context)
        {
            _ctx = context;
            _dbSet = _ctx.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }
        public void Edit(T entity)
        {
            _dbSet.Attach(entity);
            ((IObjectContextAdapter)_ctx).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }
            return _dbSet.AsEnumerable();
        }
        public T GetBy(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.FirstOrDefault(predicate);
            }
            return _dbSet.FirstOrDefault();
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
