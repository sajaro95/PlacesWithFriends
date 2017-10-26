namespace PWF.Data.Repository
{
    using System;
    using Interface;
    using System.Linq;
    using PWF.Data.Context;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal IPWFContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(IPWFContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Isnert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
