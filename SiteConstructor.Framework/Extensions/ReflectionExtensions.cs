using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SiteConstructor.Framework.Helpers
{
    public static class ReflectionExtensions
    {
            /// <summary>
            /// Возвращает значение атрибута [DisplayName]
            /// </summary>
            public static string GetDisplayName(this MemberInfo memberInfo)
            {
                var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);

                return attr == null ? memberInfo.Name : attr.DisplayName;
            }

            public static T GetAttribute<T>(this MemberInfo member, bool isRequired)
            where T : Attribute
            {
                var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

                if (attribute == null && isRequired)
                {
                    throw new ArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "The {0} attribute must be defined on member {1}",
                            typeof(T).Name,
                            member.Name));
                }

                return (T)attribute;
            }

            public static string GetPropertyDisplayName<T>(Expression<Func<T, object>> propertyExpression)
            {
                var memberInfo = GetPropertyInformation(propertyExpression.Body);
                if (memberInfo == null)
                {
                    throw new ArgumentException(
                        "No property reference expression was found.",
                        "propertyExpression");
                }

                return memberInfo.GetDisplayName();
            }

            public static MemberInfo GetPropertyInformation(Expression propertyExpression)
            {
                Debug.Assert(propertyExpression != null, "propertyExpression != null");
                MemberExpression memberExpr = propertyExpression as MemberExpression;
                if (memberExpr == null)
                {
                    UnaryExpression unaryExpr = propertyExpression as UnaryExpression;
                    if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    {
                        memberExpr = unaryExpr.Operand as MemberExpression;
                    }
                }

                if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                {
                    return memberExpr.Member;
                }

                return null;
            }

            /// <summary>
            /// Получает значение свойства по имени
            /// </summary>
            public static Object GetPropValue(this Object obj, String name)
            {
                foreach (String part in name.Split('.'))
                {
                    if (obj == null) return null;

                    Type type = obj.GetType();
                    PropertyInfo info = type.GetProperty(part);
                    if (info == null) return null;

                    obj = info.GetValue(obj, null);
                }
                return obj;
            }

            /// <summary>
            /// Получает значение свойства с приведением к указанному типу
            /// </summary>
            public static T GetPropValue<T>(this Object obj, String name)
            {
                Object retval = GetPropValue(obj, name);
                if (retval == null) return default(T);

                // throws InvalidCastException if types are incompatible
                return (T)retval;
            }

            /// <summary>
            /// Задает значение свойства объекта по имени
            /// <typeparam name="name">Название свойства</typeparam>
            /// <typeparam name="value">Значение свойства</typeparam> 
            /// </summary>
            public static T1 SetPropValue<T1, T2>(this T1 obj, String name, T2 value) where T1 : class
            {
                if (obj == null) return null;

                PropertyInfo propertyInfo = obj.GetType().GetProperty(name);
                if (propertyInfo == null) return obj;
                if (propertyInfo.PropertyType == value.GetType())
                {
                    propertyInfo.SetValue(obj, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                }
                return obj;
            }
        }
}
