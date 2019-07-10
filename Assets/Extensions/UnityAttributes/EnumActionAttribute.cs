using System;
using UnityEngine;

/// <summary>
/// Mark a method with an integer argument with this to display the argument as an enum popup in the UnityEvent
/// drawer. Use: [EnumAction(typeof(SomeEnumType))]
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class EnumActionAttribute : PropertyAttribute
{
    public Type enumType;

    public EnumActionAttribute(Type enumType)
    {
        this.enumType = enumType;
    }
}