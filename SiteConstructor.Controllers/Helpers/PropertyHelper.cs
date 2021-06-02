using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SiteConstructor.GenericControllers
{
    public class PropertyHelper
    {
        HiddenInputAttribute hiddenAttr;
        DisplayAttribute displayAttr;
        KeyAttribute keyAttr;
        DataTypeAttribute dataAttr;
        object obj;

        bindValue bind = new bindValue();

        class bindValue
        {
            public string name;
            public string typeInput;
            public string textLabel;
            public bool hiddenInput;
            public object value;
        }

        public PropertyHelper(PropertyInfo prop, object obj)
        {
            hiddenAttr = prop.GetCustomAttribute<HiddenInputAttribute>();
            displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
            keyAttr = prop.GetCustomAttribute<KeyAttribute>();
            dataAttr = prop.GetCustomAttribute<DataTypeAttribute>();
            this.obj = obj;

            bind.name = prop.Name;
            bind.hiddenInput = (hiddenAttr != null && !hiddenAttr.DisplayValue) ? true : false;
            bind.typeInput = (dataAttr != null && bind.hiddenInput == false) ? nameof(dataAttr.DataType) : "text";
            bind.textLabel = (displayAttr != null && !string.IsNullOrWhiteSpace(displayAttr.GetName())) ? displayAttr.GetName() : prop.Name;
            bind.value = prop.GetValue(obj);

        }

        public string GetForm()
        {
            if (bind.hiddenInput)
                return $"<input id = '{bind.name}' type = 'hidden' value = '{bind.value}' />";
            return $"<div class='form-group'><label>{bind.textLabel}</label><br/><input id = '{bind.name}' type = '{bind.typeInput}' value = '{bind.value}' /></div>";
        }
    }
    
}
