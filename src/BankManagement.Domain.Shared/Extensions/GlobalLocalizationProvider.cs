using System;
using System.ComponentModel;
using System.Reflection;
using BankManagement.Localization;
using Microsoft.Extensions.Localization;

namespace BankManagement.Extensions;

public static class GlobalLocalizationProvider
{
    public static IStringLocalizer<BankManagementResource> _StringLocalizer;
    
    public static string GetDescription(this Enum value)
    {
        Type type = value.GetType();
        string? name = Enum.GetName(type, value);
        if (name != null)
        {
            FieldInfo? field = type.GetField(name);
            if (field != null && Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attr)
            {
                return _StringLocalizer[$"Enum.{attr.Description}"];
            }
        }
        return string.Empty;
    }
    
    public static void SetLocalizer(IStringLocalizer<BankManagementResource> stringLocalizer)
    {
        _StringLocalizer = stringLocalizer;
    }
}