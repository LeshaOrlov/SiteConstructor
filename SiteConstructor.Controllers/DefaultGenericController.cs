using Microsoft.AspNetCore.Mvc;
using SiteConstructor.Framework.Repository;
using Microsoft.EntityFrameworkCore;
using SiteConstructor.Framework.Models;
using System.Threading.Tasks;

namespace SiteConstructor.GenericControllers
{
    public class DefaultGenericController<TEntity> : Controller
        where TEntity : class, IEntityWithId<int>, new()
    {
        readonly protected DbContext _repository;
        readonly IControllerResult _ControllerResult;

        public DefaultGenericController(DbContext repository)
        {
            _repository = repository;
            _ControllerResult = new ActionControllerResult(this);
        }

        // Details
        virtual public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return _ControllerResult.NotFound();
            }

            var entity = _repository.Find<TEntity>(id.Value);

            if (entity == null)
            {
                return _ControllerResult.NotFound();
            }

            return _ControllerResult.View(entity);
        }

        [HttpGet]
        virtual public IActionResult Create()
        {
            return _ControllerResult.View(new TEntity());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        virtual public IActionResult Create(TEntity entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(entity);
                    _repository.SaveChanges();
                    return _ControllerResult.Created();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return _ControllerResult.View(entity);
        }

        [HttpGet]
        virtual public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return _ControllerResult.NotFound();
            }

            var entity = _repository.Find<TEntity>(id);

            if (entity == null)
            {
                return _ControllerResult.NotFound();
            }

            return _ControllerResult.View(entity);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        virtual public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return _ControllerResult.NotFound();
            }

            var entity = _repository.Find<TEntity>(id.Value);

            if (TryUpdateModelAsync(entity).Result)
            {
                try
                {
                    _repository.Update(entity);
                    _repository.SaveChanges();
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
        virtual public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return _ControllerResult.NotFound();
            }

            var testEntity = _repository.Find<TEntity>(id.Value);

            if (testEntity == null)
            {
                return _ControllerResult.NotFound();
            }

            _repository.Remove(testEntity);
            _repository.SaveChanges();

            return _ControllerResult.Deleted();
        }

    }
}
