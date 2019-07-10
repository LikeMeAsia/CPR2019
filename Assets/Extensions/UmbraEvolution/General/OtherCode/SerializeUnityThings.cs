//Name: Robert MacGillivray
//Date: Mar.12.2015
//File: SerializeUnityThings.cs
//Purpose: To convert some Unity datatypes into float arrays for use during saving and then to turn them back during loading

//Last Updated: Nov.24.2015 by Robert MacGillivray

using UnityEngine;
using System;
using System.Collections;

namespace UmbraEvolution
{
    public static class SerializeUnityThings
    {

        /// <summary>
        /// Converts a Vector2 into a float array
        /// </summary>
        /// <returns>The converted Vector2</returns>
        /// <param name="vectorToConvert">The Vector2 to convert</param>
        internal static float[] VectorConversion(Vector2 vectorToConvert)
        {
            float[] vector2 = new float[2];
            vector2[0] = vectorToConvert.x;
            vector2[1] = vectorToConvert.y;
            return vector2;
        }

        /// <summary>
        /// Converts a float array into a Vector2
        /// </summary>
        /// <returns>The converted float array</returns>
        /// <param name="vectorToConvert">The float array to convert</param>
        internal static Vector2 BackToVector2(float[] convertedVector2)
        {
            Vector2 rebuiltVector2;
            rebuiltVector2.x = convertedVector2[0];
            rebuiltVector2.y = convertedVector2[1];
            return rebuiltVector2;
        }

        /// <summary>
        /// Converts a Vector3 into a float array
        /// </summary>
        /// <returns>The converted Vector3</returns>
        /// <param name="vectorToConvert">The Vector3 to convert</param>
        internal static float[] VectorConversion(Vector3 vectorToConvert)
        {
            float[] vector3 = new float[3];
            vector3[0] = vectorToConvert.x;
            vector3[1] = vectorToConvert.y;
            vector3[2] = vectorToConvert.z;
            return vector3;
        }

        /// <summary>
        /// Converts a float array into a Vector3
        /// </summary>
        /// <returns>The converted float array</returns>
        /// <param name="vectorToConvert">The float array to convert</param>
        internal static Vector3 BackToVector3(float[] convertedVector3)
        {
            Vector3 rebuiltVector3;
            rebuiltVector3.x = convertedVector3[0];
            rebuiltVector3.y = convertedVector3[1];
            rebuiltVector3.z = convertedVector3[2];
            return rebuiltVector3;
        }

        /// <summary>
        /// Converts a Vector4 into a float array
        /// </summary>
        /// <returns>The converted Vector4</returns>
        /// <param name="vectorToConvert">The Vector4 to convert</param>
        internal static float[] VectorConversion(Vector4 vectorToConvert)
        {
            float[] vector4 = new float[4];
            vector4[0] = vectorToConvert.x;
            vector4[1] = vectorToConvert.y;
            vector4[2] = vectorToConvert.z;
            vector4[3] = vectorToConvert.w;
            return vector4;
        }

        /// <summary>
        /// Converts a float array into a Vector4
        /// </summary>
        /// <returns>The float array to convert</returns>
        /// <param name="vectorToConvert">The converted float array</param>
        internal static Vector4 BackToVector4(float[] convertedVector4)
        {
            Vector4 rebuiltVector4;
            rebuiltVector4.x = convertedVector4[0];
            rebuiltVector4.y = convertedVector4[1];
            rebuiltVector4.z = convertedVector4[2];
            rebuiltVector4.w = convertedVector4[3];
            return rebuiltVector4;
        }

        /// <summary>
        /// Converts a scale into a float array
        /// </summary>
        /// <returns>The conversion.</returns>
        /// <param name="scaleToConvert">Scale to convert.</param>
        internal static float[] ScaleConversion(Vector3 scaleToConvert)
        {
            float[] scale = new float[3];
            scale[0] = scaleToConvert.x;
            scale[1] = scaleToConvert.y;
            scale[2] = scaleToConvert.z;
            return scale;
        }

        /// <summary>
        /// Converts a float array into a scale
        /// </summary>
        /// <returns>The to scale.</returns>
        /// <param name="convertedScale">Converted scale.</param>
        internal static Vector3 BackToScale(float[] convertedScale)
        {
            Vector3 rebuiltScale;
            rebuiltScale.x = convertedScale[0];
            rebuiltScale.y = convertedScale[1];
            rebuiltScale.z = convertedScale[2];
            return rebuiltScale;
        }

        /// <summary>
        /// Converts a quaternion into a float array
        /// </summary>
        /// <returns>The conversion.</returns>
        /// <param name="quaternionToConvert">Quaternion to convert.</param>
        internal static float[] QuaternionConversion(Quaternion quaternionToConvert)
        {
            float[] quaternion = new float[4];
            quaternion[0] = quaternionToConvert.x;
            quaternion[1] = quaternionToConvert.y;
            quaternion[2] = quaternionToConvert.z;
            quaternion[3] = quaternionToConvert.w;
            return quaternion;
        }

        /// <summary>
        /// Converts a float array into a quaternion
        /// </summary>
        /// <returns>The to quaternion.</returns>
        /// <param name="convertedQuaternion">Converted quaternion.</param>
        internal static Quaternion BackToQuaternion(float[] convertedQuaternion)
        {
            Quaternion rebuiltQuaternion;
            rebuiltQuaternion.x = convertedQuaternion[0];
            rebuiltQuaternion.y = convertedQuaternion[1];
            rebuiltQuaternion.z = convertedQuaternion[2];
            rebuiltQuaternion.w = convertedQuaternion[3];
            return rebuiltQuaternion;
        }

        /// <summary>
        /// Converts a transform into a float array
        /// </summary>
        /// <returns>The conversion.</returns>
        /// <param name="transformToConvert">Transform to convert.</param>
        internal static float[] TransformConversion(Transform transformToConvert)
        {
            float[] transform = new float[10];
            transform[0] = transformToConvert.position.x;
            transform[1] = transformToConvert.position.y;
            transform[2] = transformToConvert.position.z;
            transform[3] = transformToConvert.rotation.x;
            transform[4] = transformToConvert.rotation.y;
            transform[5] = transformToConvert.rotation.z;
            transform[6] = transformToConvert.rotation.w;
            transform[7] = transformToConvert.localScale.x;
            transform[8] = transformToConvert.localScale.y;
            transform[9] = transformToConvert.localScale.z;
            return transform;
        }

        /// <summary>
        /// Converts a float array back into a Transform
        /// </summary>
        /// <returns>The to transform.</returns>
        /// <param name="convertedTransform">Converted transform.</param>
        internal static Transform BackToTransform(float[] convertedTransform)
        {
            Transform rebuiltTransform = new GameObject().transform;
            rebuiltTransform.position = new Vector3(convertedTransform[0], convertedTransform[1], convertedTransform[2]);
            rebuiltTransform.rotation = new Quaternion(convertedTransform[3], convertedTransform[4], convertedTransform[5], convertedTransform[6]);
            rebuiltTransform.localScale = new Vector3(convertedTransform[7], convertedTransform[8], convertedTransform[9]);
            return rebuiltTransform;
        }
    }
}
