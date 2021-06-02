using Microsoft.AspNetCore.Mvc;
using SiteConstructor.GenericControllers;
using SiteConstructor.WebApp.Models;
using System.Linq;

namespace SiteConstructor.WebApp.Controllers
{
    public class TestController : GenericController<TestEntity>
    {
        
        public TestController(TestContext db): base(db)
        {
            
        }

        public IActionResult Index()
        {
            var list = ((TestContext)_repository).TestEntities.ToList();
            return View(list);
        }

    }
}
