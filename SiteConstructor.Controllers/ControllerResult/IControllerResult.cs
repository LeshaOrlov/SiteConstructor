using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteConstructor.GenericControllers
{
    public interface IControllerResult
    {
        ActionResult NotFound();
        ActionResult View(object obj);

        ActionResult Created();

        ActionResult Deleted();

        ActionResult Error();

    }
}
