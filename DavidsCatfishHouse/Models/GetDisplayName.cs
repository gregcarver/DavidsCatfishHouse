using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using DavidsCatfishHouse.Models;

namespace DavidsCatfishHouse.Models
{
    public static class EnumHelper
    {
        //public static string GetDisplayName(this Enum enumValue)
        //{
        //    var enumMember = enumValue.GetType()
        //                    .GetMember(enumValue.ToString());

        //    DisplayAttribute displayAttrib = null;
        //    if (enumMember.Any())
        //    {
        //        displayAttrib = enumMember
        //                    .First()
        //                    .GetCustomAttribute<DisplayAttribute>();
        //    }

        //    string name = null;
        //    Type resource = null;

        //    if (displayAttrib != null)
        //    {
        //        name = displayAttrib.Name;
        //        resource = displayAttrib.ResourceType;
        //    }

        //    return String.IsNullOrEmpty(name) ? enumValue.ToString()
        //        : resource == null ? name
        //        : new ResourceManager(resource).GetString(name);
        //}
        //public static string GetDisplayName(this Enum enumValue)
        //{
        //    return enumValue.GetType()
        //                    .GetMember(enumValue.ToString())
        //                    .First()
        //                    .GetCustomAttribute<DisplayAttribute>()
        //                    .GetName();
        //}

        //public static string GetDescription(this Enum value)
        //{
        //    return ((DescriptionAttribute)Attribute.GetCustomAttribute(
        //        value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
        //            .Single(x => x.GetValue(null).Equals(value)),
        //        typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        //}

    }
}
