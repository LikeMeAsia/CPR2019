//Name: Robert MacGillivray
//File: PerLayerCulling.cs
//Date: Apr.18.2015
//Purpose: To easily give the ability for different far clipping distances to be given to different layers

//Last Updated: Jan.11.2017 by Robert MacGillivray

using UnityEngine;
using System.Collections;

namespace UmbraEvolution
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class PerLayerCulling : MonoBehaviour
    {
        [Tooltip("Set this as the default distance you want culling to occur across the majority of layers.")]
        [GreaterThanFloat(0, false)]
        public float defaultCullDistance;
        [Tooltip("A multiplier applied to all distances you've entered for an easy way to modify performance dynamically")]
        [GreaterThanFloat(0, false)]
        public float distanceMultiplier = 1f;
        private float oldDefaultCullDistance; //used to keep track of the old default so that multiple culling distances can be edited at once
        [Tooltip("In order to work properly, this must always have 32 elements, each corrisponding to the index of your layers. Set each index to set culling distance of a layer. For example: set Element 0 to 1000 and all objects on the default layer will cull at 1000 units from this camera. The layer names should automatically be appropriately assigned for you though, so you don't have to look them up.")]
        public LayerCullInfo[] layerCullInfos = new LayerCullInfo[32];

        public const int NUMBER_OF_UNITY_LAYERS = 32;
        private Camera myCamera;

        void Awake()
        {
            myCamera = GetComponent<Camera>(); //keeps track of the camera component without needing to call GetComponent all the time

            //if we're not playing, and we're in the inspector, we've got some initialization to do
            if (!Application.isPlaying && Application.isEditor)
            {
                if (distanceMultiplier > 0)
                {
                    defaultCullDistance = myCamera.farClipPlane / distanceMultiplier;
                }
                else
                {
                    Debug.LogError("Distance multiplier is less than or equal to 0.");
                }
                oldDefaultCullDistance = defaultCullDistance; //sets up the mass editing of default culling planes
                //fills up layerCullInfos[] with LayerCullInfo objects and sets the layer names appropriately
                for (int index = 0; index < NUMBER_OF_UNITY_LAYERS; index++)
                {
                    if (layerCullInfos[index] == null)
                    {
                        layerCullInfos[index] = new LayerCullInfo();
                        layerCullInfos[index].cullDistance = defaultCullDistance;
                    }

                    if (LayerMask.LayerToName(index) != "")
                    {
                        layerCullInfos[index].layerName = LayerMask.LayerToName(index);
                    }
                    else
                    {
                        layerCullInfos[index].layerName = "Layer Not Defined";
                    }
                }
            }
        }

        void Start()
        {
            //This coroutine will re-assign values to the camera once per second
            if (Application.isPlaying)
            {
                StartCoroutine(AssignUpdatedValues());
            }
        }

        /// <summary>
        /// Makes sure that all values are appropriate and valid.
        /// Called automatically in the editor, and called by the AssignUpdatedValues coroutine at runtime.
        /// </summary>
        void OnValidate()
        {
            if (!myCamera)
            {
                myCamera = GetComponent<Camera>();
            }

            //makes sure there are always the right number of elements in the layerCullInfos array
            if (layerCullInfos.Length != NUMBER_OF_UNITY_LAYERS)
            {
                LayerCullInfo[] newLayerCullInfos = new LayerCullInfo[NUMBER_OF_UNITY_LAYERS]; //when the above isn't true, we need to reset the array, but we want to save as much information as possible, so we create a temporary array

                //store all salvageable data in the temporary array
                for (int index = 0; index < layerCullInfos.Length; index++)
                {
                    newLayerCullInfos[index].cullDistance = layerCullInfos[index].cullDistance;
                }

                //if the array was resized to be smaller than the correct size, fill the remaining slots in the temp array with the default value
                for (int index = layerCullInfos.Length; index < NUMBER_OF_UNITY_LAYERS; index++)
                {
                    newLayerCullInfos[index].cullDistance = defaultCullDistance;
                }

                layerCullInfos = newLayerCullInfos; //copy the temporary array into the regular array so that it now has the right number of elements again
            }

            //have to make sure that the default distance is not less than the near clip plane (since nothing should be culled closer than that)
            if (defaultCullDistance < myCamera.nearClipPlane)
            {
                defaultCullDistance = myCamera.nearClipPlane + 0.01f; //roughly the smallest distance the far clip plane can be
            }

            //makes sure the cull distance for each layer isn't smaller than the near clip plane
            foreach (LayerCullInfo cullInfo in layerCullInfos)
            {
                if (cullInfo.cullDistance < myCamera.nearClipPlane)
                {
                    cullInfo.cullDistance = myCamera.nearClipPlane + 0.01f;
                }
            }

            //Makes sure the distance multiplier won't make any of the cull distances smaller than the near clip plane
            float nearestCullDistance = layerCullInfos[0].cullDistance;
            foreach (LayerCullInfo cullInfo in layerCullInfos)
            {
                if (cullInfo.cullDistance < nearestCullDistance)
                {
                    nearestCullDistance = cullInfo.cullDistance;
                }
            }
            if (nearestCullDistance * distanceMultiplier < (myCamera.nearClipPlane + 0.01f))
            {
                distanceMultiplier = (myCamera.nearClipPlane + 0.01f) / nearestCullDistance;
            }

            //Makes sure that all distances set to the old default are updated if the default has been changed.
            //Used to automatically update the array in any places that are just using the default
            foreach (LayerCullInfo cullInfo in layerCullInfos)
            {
                if (cullInfo.cullDistance == oldDefaultCullDistance)
                {
                    cullInfo.cullDistance = defaultCullDistance;
                }
            }

            //searches the array for the furthest distance
            //culling distances cannot be set to a value larger than the far clip plane on the camera, so we increase the far clip plane to match
            float furthestCullDistance = layerCullInfos[0].cullDistance;
            foreach (LayerCullInfo cullInfo in layerCullInfos)
            {
                if (cullInfo.cullDistance > furthestCullDistance)
                {
                    furthestCullDistance = cullInfo.cullDistance;
                }
            }
            myCamera.farClipPlane = furthestCullDistance * distanceMultiplier;

            oldDefaultCullDistance = defaultCullDistance; //stores the current default for comparison's sake if a change is made
        }

        /// <summary>
        /// Resets all culling distances to the current default
        /// </summary>
        public void ResetDefaults()
        {
            foreach (LayerCullInfo cullDistance in layerCullInfos)
            {
                cullDistance.cullDistance = defaultCullDistance;
            }
        }

        /// <summary>
        /// Makes a call to validate all values, then assigns updated values.
        /// Runs once per second.
        /// </summary>
        private IEnumerator AssignUpdatedValues()
        {
            while (true)
            {
                OnValidate();
                //we can only assign culling plane distances with a float array, so we'll take the float values from the custom class and put them into one after applying our multiplier
                float[] cullFloatArray = new float[NUMBER_OF_UNITY_LAYERS];
                for (int index = 0; index < NUMBER_OF_UNITY_LAYERS; index++)
                {
                    cullFloatArray[index] = layerCullInfos[index].cullDistance * distanceMultiplier;
                }
                myCamera.layerCullDistances = cullFloatArray; //assigns culling distances to all layers
                yield return new WaitForSeconds(1);
            }
        }

        /// <summary>
        /// Enables visual representations of layer culling in the editor
        /// </summary>
        void OnDrawGizmosSelected()
        {
            foreach (LayerCullInfo cullInfo in layerCullInfos)
            {
                if (cullInfo.showGizmo)
                {
                    Gizmos.matrix = transform.localToWorldMatrix; //aligns the gizmo to the local object's transform
                    Gizmos.color = cullInfo.gizmoColor;
                    Gizmos.DrawFrustum(transform.position, myCamera.fieldOfView, cullInfo.cullDistance * distanceMultiplier, myCamera.nearClipPlane, myCamera.aspect);
                }
            }
        }

        /// <summary>
        /// If the first public variable in a serializable class is a string, any public arrays of this class will have
        /// elements renamed in the inspector. This makes it easy to see what layer you're setting culling distances for in the inspector
        /// </summary>
        [System.Serializable]
        public class LayerCullInfo
        {
            [ReadOnlyInInspector]
            public string layerName;
            [GreaterThanFloat(0, false)]
            public float cullDistance;
            public bool showGizmo;
            public Color gizmoColor = Color.cyan;
        }
    }
}
