using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomPropertyDrawer(typeof(LayerAttribute))]
public class LayerAttributeEditor : PropertyDrawer
{
    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
        EditorGUI.BeginProperty(pos, label, prop);
        prop.intValue = EditorGUI.MaskField(pos, prop.displayName, prop.intValue, InternalEditorUtility.layers);
        EditorGUI.EndProperty();
    }
}