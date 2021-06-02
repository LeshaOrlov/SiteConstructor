using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteConstructor.Framework.Models;
using System.Threading.Tasks;
using SiteConstructor.GenericControllers.Repository;

namespace SiteConstructor.GenericControllers
{
    [GenericControllerRouteConvention]
    public class GenericApiController<TEntity>: ControllerBase
        where TEntity : class, IEntityWithId<int>, new() 
    {
        readonly IGenericRepository<TEntity> _repository;
        readonly IControllerResult _ControllerResult;

        public GenericApiController(IGenericRepository<TEntity> repository, IControllerResult controllerResult = null)
        {
            _repository = repository;

            if (controllerResult == null)
                _ControllerResult = new JsonControllerResult();
            else
                _ControllerResult = controllerResult;
        }

        [HttpGet]
        virtual public IActionResult Get()
        {
            var entity = _repository.Get();

            if (entity == null)
            {
                return _ControllerResult.NotFound();
            }

            return _ControllerResult.View(entity);
        }

        [HttpGet("{id}")]
        virtual public IActionResult Get(int id)
        {
            var entity = _repository.FindById(id);

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
                    _repository.Create(entity);
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
            var entity = _repository.FindById(id);

            if (await TryUpdateModelAsync(entity))
            {
                try
                {
                     _repository.Update(entity);
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
            var testEntity = _repository.FindById(id);

            if (testEntity == null)
            {
                _repository.Remove(testEntity);
                return _ControllerResult.NotFound();
            }

            return _ControllerResult.View(testEntity);
        }

        private bool TestEntityExists(int id)
        {

            var entity = _repository.FindById(id);

            if (entity == null)
            {
                return false;
            }

            return true;
        }
    }
}
