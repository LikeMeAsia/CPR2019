//Name: Robert MacGillivray
//File: GreaterThanIntDrawer.cs
//Date: Dec.01.2015
//Purpose: A property drawer used by my GreaterThanInt attribute which limits a public float/int to a value equal to or greater than the one provided

//Last Updated: Dec.01.2015 by Robert MacGillivray

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// A property drawer used by my GreaterThanZero attribute which limits a public float/int to a value no less than zero
    /// </summary>
    [CustomPropertyDrawer(typeof(GreaterThanIntAttribute))]
    public class GreaterThanIntDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GreaterThanIntAttribute greaterThan = (GreaterThanIntAttribute)attribute;
            if (property.propertyType == SerializedPropertyType.Integer)
            {
                if (greaterThan.inclusive)
                {
                    if (property.intValue < greaterThan.greaterThanInteger)
                    {
                        property.intValue = greaterThan.greaterThanInteger;
                    }
                }
                else
                {
                    if (property.intValue <= greaterThan.greaterThanInteger)
                    {
                        property.intValue = greaterThan.greaterThanInteger + 1;
                    }
                }
                EditorGUI.PropertyField(position, property, label);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use the GreaterThanInt attribute on integers only");
            }
        }
    }
}
