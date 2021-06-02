using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteConstructor.GenericControllers
{
    public class ActionControllerResult : IControllerResult
    {
        Controller _controller;
        public ActionControllerResult(Controller controller)
        {
            _controller = controller;
        }
        public ActionResult NotFound()
        {
            return _controller.NotFound();
        }

        public ActionResult Error()
        {
            return _controller.NotFound();
        }

        public ActionResult Created()
        {
            return _controller.RedirectToAction("Index");
        }

        public ActionResult Deleted()
        {
            return _controller.RedirectToAction("Index");
        }

        public ActionResult View(object obj)
        {
            return _controller.View(obj);
        }
    }
}
