using Microsoft.AspNetCore.Mvc.ApplicationModels;
using SiteConstructor.GenericControllers.Attributes;
using System;
using System.Reflection;

namespace SiteConstructor.GenericControllers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GenericControllerRouteConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                

                var customNameAttribute = genericType.GetCustomAttribute<GeneratedControllerAttribute>();

                if (string.IsNullOrWhiteSpace(customNameAttribute.Name))
                    controller.ControllerName = genericType.Name;
                else controller.ControllerName = customNameAttribute.Name;


                //if (customNameAttribute?.Route != null)
                //{
                //    controller.Selectors.Add(new SelectorModel
                //    {
                //        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route)),
                //    });
                //}
            }
        }
    }
}
