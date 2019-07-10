//Name: Robert MacGillivray
//File: LessThanFloatDrawer.cs
//Date: Dec.01.2015
//Purpose: A property drawer used by my LessThanFloat attribute which limits a public float/int to a value equal to or less than the one provided

//Last Updated: Dec.01.2015 by Robert MacGillivray

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// A property drawer used by my LessThanZero attribute which limits a public float/int to a value no less than zero
    /// </summary>
    [CustomPropertyDrawer(typeof(LessThanFloatAttribute))]
    public class LessThanFLoatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LessThanFloatAttribute lessThan = (LessThanFloatAttribute)attribute;
            if (property.propertyType == SerializedPropertyType.Float)
            {
                if (lessThan.inclusive)
                {
                    if (property.floatValue > lessThan.lessThanFloat)
                    {
                        property.floatValue = lessThan.lessThanFloat;
                    }
                }
                else
                {
                    if (property.floatValue >= lessThan.lessThanFloat)
                    {
                        property.floatValue = lessThan.lessThanFloat - 0.01f;
                    }
                }
                EditorGUI.PropertyField(position, property, label);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use the LessThanFloat attribute on floats onlys");
            }
        }
    }
}
