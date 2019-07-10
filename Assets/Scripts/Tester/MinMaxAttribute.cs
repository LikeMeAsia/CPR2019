// NOTE DONT put in an editor folder

using UnityEngine;

public class MinMaxAttribute : PropertyAttribute
{
    public bool Editable;
    public bool ShowDebugValues;
}

[System.Serializable]
public class MinMax {
    public float value;
    public float minValue = 0;
    public float maxValue = 1;
}