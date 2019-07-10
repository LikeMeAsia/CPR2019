using UnityEngine;
using System;

public class LabelArrayAttribute : PropertyAttribute
{
    public enum LabelType { Rename, FieldName}
    public string TargetName { get; private set; }
    public LabelType Type { get; private set; }

    public LabelArrayAttribute(string name)
    {
        TargetName = name;
        Type = LabelType.Rename;
    }

    public LabelArrayAttribute(string name, LabelType type)
    {
        TargetName = name;
        Type = type;
    }
}