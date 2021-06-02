using Microsoft.AspNetCore.Mvc;
using SiteConstructor.GenericControllers;

namespace SiteConstructor.WebApp
{
    [GenericControllerRouteConvention]
    public class GController<T>: Controller
    {
        public IActionResult Index()
        {
            return Content($"Hello from a generic {typeof(T).Name} controller.");
        }

        public IActionResult Create()
        {
            return Content($"Hello from a create method of generic {typeof(T).Name} controller.");
        }
    }
   
}
