using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(LabelArrayAttribute))]
public class LabelArrayDrawer : PropertyDrawer
{

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (GetCustomDrawer(property.type, out PropertyDrawer drawer))
        {
            return drawer.GetPropertyHeight(property, label);
        }
        return EditorGUI.GetPropertyHeight(property, true);
    }

     public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
     {
         try
         {
            LabelArrayAttribute labelAtt = (LabelArrayAttribute)attribute;
            if (labelAtt.Type == LabelArrayAttribute.LabelType.Rename) {
                DrawRename(rect, property, labelAtt.TargetName);
            } else if (labelAtt.Type == LabelArrayAttribute.LabelType.FieldName) {
                DrawFieldName(rect, property, labelAtt.TargetName);
            }
         }
         catch
         {
             EditorGUI.PropertyField(rect, property, label, true);
         }
     }

    public void DrawRename(Rect rect, SerializedProperty property, string labelName) {
        var path = property.propertyPath;
        string[] pathSplit = property.propertyPath.Split('[', ']');
        string pos = pathSplit[pathSplit.Length - 2];
        if (GetCustomDrawer(property.type, out PropertyDrawer drawer))
        {
            drawer.OnGUI(rect, property, new GUIContent(labelName + " [" + pos + "]"));
        }
        else
        {
            EditorGUI.PropertyField(rect, property, new GUIContent(labelName + " [" + pos + "]"), true);
        }
    }

    public void DrawFieldName(Rect rect, SerializedProperty property, string fieldName) {
        var path = property.propertyPath;
        string[] pathSplit = property.propertyPath.Split('[', ']');
        string pos = pathSplit[pathSplit.Length - 2];
        SerializedProperty fieldProp = property.FindPropertyRelative(fieldName);
        if (fieldProp == null) {
            EditorGUI.PropertyField(rect, property, new GUIContent("[" + pos + "] " + fieldName), true);
            return;
        }
        if (fieldProp.objectReferenceValue == null)
        {
            EditorGUI.PropertyField(rect, property, new GUIContent("[" + pos + "] " + "Unassigned: " + fieldProp.displayName), true);
            return;
        }
        
        if (GetCustomDrawer(property.type, out PropertyDrawer drawer))
        {
            drawer.OnGUI(rect, property, new GUIContent("[" + pos + "] " + fieldProp.objectReferenceValue.name));
        }
        else
        {
            EditorGUI.PropertyField(rect, property, new GUIContent("[" + pos + "] " + fieldProp.objectReferenceValue.name), true);
        }
    }

    public bool GetCustomDrawer(string type, out PropertyDrawer propertyDrawer) {
        propertyDrawer = null;
        return false;
    }
}