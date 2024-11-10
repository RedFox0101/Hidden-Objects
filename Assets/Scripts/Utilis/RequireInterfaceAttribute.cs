using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class RequireInterfaceAttribute : PropertyAttribute
{
    public Type RequiredType;
    public RequireInterfaceAttribute(Type type)
    {
        RequiredType = type;
    }
}