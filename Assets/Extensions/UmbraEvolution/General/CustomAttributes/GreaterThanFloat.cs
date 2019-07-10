//Name: Robert MacGillivray
//File: GreaterThanFloat.cs
//Date: Dec.01.2015
//Purpose: To make a class for my GreaterThanInclusive property drawer to be accessed and to store the appropriate greater than X value

//Last Updated: Dec.01.2015 by Robert MacGillivray

using UnityEngine;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// Accesses the GreaterThanInclusive property which limits a float or integer in the inspector to any value greater or equal to the provided value.
    /// </summary>
    public class GreaterThanFloatAttribute : PropertyAttribute
    {
        public float greaterThanFloat;
        public bool inclusive;

        /// <summary>
        /// Uses a float for the greater than comparison
        /// </summary>
        /// <param name="greaterThanFloat">The float that will be used to limit the value of this variable</param>
        /// <param name="inclusive">If true, a greater than or equal comparison will be used. If false, a non-inclusive greater than comparison will be used.</param>
        public GreaterThanFloatAttribute(float greaterThanFloat, bool inclusive)
        {
            this.greaterThanFloat = greaterThanFloat;
            this.inclusive = inclusive;
        }
    }
}
