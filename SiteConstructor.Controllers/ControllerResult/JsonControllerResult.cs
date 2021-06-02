using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteConstructor.GenericControllers
{
    public class JsonControllerResult : IControllerResult
    {
        public ActionResult NotFound()
        {
            var result = new JsonResult(new { })
            {
                StatusCode = 404
            };
            return result;
        }

        public ActionResult Error()
        {
            var result = new JsonResult(new { })
            {
                StatusCode = 400
            };
            return result;
        }

        public ActionResult Created()
        {
            var result = new JsonResult(new { })
            {
                StatusCode = 201
            };
            return result;
        }

        public ActionResult View(object obj)
        {
            var result = new JsonResult(obj)
            {
                StatusCode = 200
            };
            return result;
        }
        public ActionResult Deleted()
        {
            var result = new JsonResult(new { })
            {
                StatusCode = 201
            };
            return result;
        }

    }
}
