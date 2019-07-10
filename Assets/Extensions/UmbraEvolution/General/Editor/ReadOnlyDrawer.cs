/* Note that this script must be in a folder in the root of your project called "Editor" */

//Name: Robert MacGillivray
//File: ReadOnlyDrawer.cs
//Date: Apr.21.2015
//Purpose: To create a property drawer for my read only attribute

//Last Updated: Nov.24.2015 by Robert MacGillivray

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// A property drawer used by my ReadOnlyInInspector attribute which makes a public property visible, but not editable in the inspector
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnlyInInspectorAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false; //disables elements in the gui
            EditorGUI.PropertyField(position, property, label, true); //creates the property, which will be disabled because of the above line
            GUI.enabled = true; //re-enables the gui so that not all properties are greyed out
        }
    }
}
