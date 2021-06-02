using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteConstructor.Framework.Models;
using SiteConstructor.Framework.Repository;
using SiteConstructor.GenericControllers.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace SiteConstructor.GenericControllers
{
    [GenericControllerRouteConvention]
    public class EFGenericApiController<TEntity, TDbContext> : ControllerBase
        where TEntity : class, IEntityWithId<int>, new()
        where TDbContext : DbContext
    {
        readonly TDbContext _context;
        readonly IControllerResult _ControllerResult;
        readonly DbSet<TEntity> _dbSet;

        public EFGenericApiController(TDbContext context)
        {
            _context = context;
            _ControllerResult = new JsonControllerResult();
            DbSet<TEntity> _dbSet = _context.Set<TEntity>();
        }

        [HttpGet]
        virtual public IActionResult Get()
        {
            var entity = _dbSet.AsNoTracking().ToList();

            if (entity == null)
            {
                return _ControllerResult.NotFound();
            }

            return _ControllerResult.View(entity);
        }

        [HttpGet("{id}")]
        virtual public IActionResult Get(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                return _ControllerResult.NotFound();
            }

            return _ControllerResult.View(entity);
        }

        [HttpPost]
        virtual public IActionResult Post(TEntity entity)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _dbSet.Add(entity);
                    _context.SaveChanges();
                    //return _ControllerResult.Created();
                    return CreatedAtAction("Get", new { id = entity.Id }, entity);

                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            return _ControllerResult.View(entity);
        }

        [HttpPut("{id}")]
        virtual public async Task<IActionResult> Put(int id)
        {
            var entity = _dbSet.Find(id);

            if (await TryUpdateModelAsync(entity))
            {
                try
                {
                    _context.Update(entity);
                    return _ControllerResult.Created();

                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                }

            }
            return _ControllerResult.View(entity);
        }

        // Delete
        [HttpDelete("{id}")]
        virtual public IActionResult Delete(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                _context.Remove(entity);
                return _ControllerResult.NotFound();
            }

            return _ControllerResult.View(entity);
        }

        private bool TestEntityExists(int id)
        {

            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                return false;
            }

            return true;
        }
    }


}
