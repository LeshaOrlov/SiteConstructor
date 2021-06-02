using SiteConstructor.Framework.Models;
using SiteConstructor.GenericControllers.Repository;
using System;
using System.Collections.Generic;

namespace SiteConstructor.Framework.Repository
{
    public class TestGenericRepository<TEntity, TDbContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntityWithId<int>, new()
    {

        public TestGenericRepository(TDbContext context)
        {

        }

        public IEnumerable<TEntity> Get()
        {
            return new List<TEntity>();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return new List<TEntity>();
        }

        public TEntity FindById(int id)
        {
            return new TEntity();
        }

        public void Create(TEntity item)
        {

        }
        public void Update(TEntity item)
        {

        }
        public void Remove(TEntity item)
        {

        }

    }
}
