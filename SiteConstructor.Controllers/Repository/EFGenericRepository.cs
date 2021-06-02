using Microsoft.EntityFrameworkCore;
using SiteConstructor.Framework.Models;
using SiteConstructor.GenericControllers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteConstructor.Framework.Repository
{
    public class EFGenericRepository<TEntity, TDbContext> : IGenericRepository<TEntity>
         where TEntity : class, IEntityWithId<int>, new()
         where TDbContext : DbContext, new()
    {
        protected TDbContext _context = new TDbContext();
        protected DbSet<TEntity> _dbSet ;

        public EFGenericRepository(TDbContext context)
        {
            DbSet<TEntity> _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

    }
}
