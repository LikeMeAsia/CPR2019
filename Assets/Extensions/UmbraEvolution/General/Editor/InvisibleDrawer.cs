/* Note that this script must be in a folder in your project called "Editor" */

//Name: Robert MacGillivray
//File: InvisibleDrawer.cs
//Date: Jun.11.2015
//Purpose: To create a property drawer for my InvisisbleInInspector attribute

//Last Updated: Nov.24.2015 by Robert MacGillivray

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// A property drawer used by my ReadOnlyInInspector attribute which makes a public property visible, but not editable in the inspector
    /// </summary>
    [CustomPropertyDrawer(typeof(InvisibleInInspectorAttribute))]
    public class InvisibleDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false; //disables elements in the gui
            EditorGUI.PropertyField(new Rect(), property); //creates an empty rectangle for the property so it is in essence invisible, even if you need to make it public for serialization purposes
            GUI.enabled = true; //re-enables the gui so that not all properties are greyed out
        }
    }
}
