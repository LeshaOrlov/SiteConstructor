using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiteConstructor.GenericControllers.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Create(TEntity item);

        void Remove(TEntity item);
        void Update(TEntity item);

    }
}
