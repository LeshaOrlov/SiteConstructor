using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SiteConstructor.GenericControllers.Attributes
{
    //[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    //public class GenericControllerNameConvention : Attribute, IControllerModelConvention
    //{

    //    public void Apply(ControllerModel controller)
    //    {
    //        // Not a GenericController, ignore.
    //        if (!controller.ControllerType.IsGenericType && controller.ControllerType.GenericTypeArguments.Length != 1) return;
    //        var genericType = controller.ControllerType.GenericTypeArguments[0];


    //            var customNameAttribute = genericType.GetCustomAttribute<GeneratedControllerAttribute>();

    //            if (string.IsNullOrWhiteSpace(customNameAttribute.Name))
    //                controller.ControllerName = genericType.Name;
    //            else controller.ControllerName = customNameAttribute.Name;


    //            if (customNameAttribute?.Route != null)
    //            {
    //                controller.Selectors.Add(new SelectorModel
    //                {
    //                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route)),
    //                });
    //            }
            
    //    }
    //}
}
