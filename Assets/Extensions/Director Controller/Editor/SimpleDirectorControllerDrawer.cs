using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(SimpleDirectorController))]
[CanEditMultipleObjects]
public class SimpleDirectorControllerDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();
        EditorGUI.BeginChangeCheck();

        DrawDefaultInspector();
        SimpleDirectorController directorController = (SimpleDirectorController)target;
        if (directorController.pause && GUILayout.Button("Play")){
                directorController.pause = false;
        }else if (!directorController.pause && GUILayout.Button("Pause")) {
            directorController.pause = true;
        }

        if (GUILayout.Button("Skip to End Track"))
        {
            directorController.SkipToEndTrack();
        }
        if (GUILayout.Button("Skip to Next Track"))
        {
            directorController.SkipTrack();
        }

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }

}
