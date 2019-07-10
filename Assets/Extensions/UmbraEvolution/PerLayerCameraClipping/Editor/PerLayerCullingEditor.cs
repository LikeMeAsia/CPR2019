//Name: Robert MacGillivray
//File: PerLayerCullingEditor.cs
//Date: Jun.01.2015
//Purpose: To add a reset button to the PerLayerCulling inspector

//Last Updated: Nov.05.2016 by Robert MacGillivray

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UmbraEvolution
{
    [CustomEditor(typeof(PerLayerCulling))]
    public class PerLayerCullingEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector(); //draws the default inspector that would be generated
            
            PerLayerCulling cullingScript = (PerLayerCulling)target; //specifies the script to to be affected

            //Keeps the inspector organized by providing layer names
            for (int index = 0; index < PerLayerCulling.NUMBER_OF_UNITY_LAYERS; index++)
            {
                if (LayerMask.LayerToName(index) != "")
                {
                    cullingScript.layerCullInfos[index].layerName = LayerMask.LayerToName(index);
                }
                else
                {
                    cullingScript.layerCullInfos[index].layerName = "Layer Not Defined";
                }
            }

            //creates a button with a label as well as a tooltip that, when pressed, triggers a method in the script that resets all layers to the current default
            GUIContent resetDefaultsButton = new GUIContent("Reset All to Default", "Press this button to reset all layers to the default culling distance");
            if (GUILayout.Button(resetDefaultsButton))
            {
                cullingScript.ResetDefaults();
            }
        }
    }
}
