using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using SiteConstructor.GenericControllers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SiteConstructor.GenericControllers
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GenericControllerFeatureProvider).Assembly;
            foreach(var part in parts)
            {
                var assembly = part as AssemblyPart;
                if (assembly == null) continue;

                var candidates = assembly.Assembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

                foreach (var candidate in candidates)
                {
                    var genericControllerType = candidate.GetCustomAttributes<GeneratedControllerAttribute>().FirstOrDefault()?.Controller as Type;
                    if (genericControllerType == null) continue;

                    var controllerType = genericControllerType.MakeGenericType(candidate).GetTypeInfo();

                    feature.Controllers.Add(controllerType);
                }
            }
            
        }
    }
}
