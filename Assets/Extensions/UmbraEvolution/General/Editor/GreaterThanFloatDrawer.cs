//Name: Robert MacGillivray
//File: GreaterThanFloatDrawer.cs
//Date: Dec.01.2015
//Purpose: A property drawer used by my GreaterThanFloat attribute which limits a public float/int to a value equal to or greater than the one provided

//Last Updated: Dec.01.2015 by Robert MacGillivray

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// A property drawer used by my GreaterThanZero attribute which limits a public float/int to a value no less than zero
    /// </summary>
    [CustomPropertyDrawer(typeof(GreaterThanFloatAttribute))]
    public class GreaterThanFLoatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GreaterThanFloatAttribute greaterThan = (GreaterThanFloatAttribute)attribute;
            if (property.propertyType == SerializedPropertyType.Float)
            {
                if (greaterThan.inclusive)
                {
                    if (property.floatValue < greaterThan.greaterThanFloat)
                    {
                        property.floatValue = greaterThan.greaterThanFloat;
                    }
                }
                else
                {
                    if (property.floatValue <= greaterThan.greaterThanFloat)
                    {
                        property.floatValue = greaterThan.greaterThanFloat + 0.01f;
                    }
                }
                EditorGUI.PropertyField(position, property, label);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use the GreaterThanFloat attribute on floats onlys");
            }
        }
    }
}
