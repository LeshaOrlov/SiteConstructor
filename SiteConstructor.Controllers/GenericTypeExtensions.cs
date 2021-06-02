using System;
using System.Collections.Generic;
using System.Text;

namespace SiteConstructor.GenericControllers
{
    static public class GenericTypeExtensions
    {
        static public Type AddGenericType(this Type genericType, int index, Type typeArgument)
        {
            if (!genericType.IsGenericType)
                throw new ArgumentException($"{genericType.Name} is not generic type");
            Type[] args = genericType.GetGenericArguments();
                if (args.Length <= index && index < 0)
                        throw new ArgumentException($"index = {index} out of range argument");
                args[index] = typeArgument;
                Type resultType = genericType.MakeGenericType(args);
                return resultType;
        }
        
    }
}
