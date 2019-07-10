//Name: Robert MacGillivray
//File: LessThanIntDrawer.cs
//Date: Dec.01.2015
//Purpose: A property drawer used by my LessThanInt attribute which limits a public float/int to a value equal to or less than the one provided

//Last Updated: Dec.01.2015 by Robert MacGillivray

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// A property drawer used by my LessThanZero attribute which limits a public float/int to a value no less than zero
    /// </summary>
    [CustomPropertyDrawer(typeof(LessThanIntAttribute))]
    public class LessThanIntDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LessThanIntAttribute lessThan = (LessThanIntAttribute)attribute;
            if (property.propertyType == SerializedPropertyType.Integer)
            {
                if (lessThan.inclusive)
                {
                    if (property.intValue > lessThan.lessThanInteger)
                    {
                        property.intValue = lessThan.lessThanInteger;
                    }
                }
                else
                {
                    if (property.intValue >= lessThan.lessThanInteger)
                    {
                        property.intValue = lessThan.lessThanInteger - 1;
                    }
                }
                EditorGUI.PropertyField(position, property, label);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use the LessThanInt attribute on integers only");
            }
        }
    }
}
