using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteConstructor.GenericControllers.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        //public string Route { get; set; }

        public System.Object Controller { get; set; }

        public string Name { get; set; }

    }

}
