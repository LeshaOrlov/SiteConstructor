using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SiteConstructor.GenericControllers.HtmlHelpers
{
    public static class FieldHelper
    {
        public static HtmlString CreateInputField(this IHtmlHelper html, object Model)
        {
            string result = String.Empty;
            var props = Model.GetType().GetProperties();

            foreach(var prop in props)
            {
                result += new PropertyHelper(prop, Model).GetForm();
            }

            return new HtmlString(result);
        }
    }
}
