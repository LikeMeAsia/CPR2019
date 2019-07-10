//Name: Robert MacGillivray
//File: LessThanFloat.cs
//Date: Dec.01.2015
//Purpose: To make a class for my LessThanInclusive property drawer to be accessed and to store the appropriate less than X value

//Last Updated: Dec.01.2015 by Robert MacGillivray

using UnityEngine;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// Accesses the LessThanInclusive property which limits a float or integer in the inspector to any value less or equal to the provided value.
    /// </summary>
    public class LessThanFloatAttribute : PropertyAttribute
    {
        public float lessThanFloat;
        public bool inclusive;

        /// <summary>
        /// Uses a float for the less than comparison
        /// </summary>
        /// <param name="lessThanFloat">The float that will be used to limit the value of this variable</param>
        /// <param name="inclusive">If true, a less than or equal comparison will be used. If false, a non-inclusive less than comparison will be used.</param>
        public LessThanFloatAttribute(float lessThanFloat, bool inclusive)
        {
            this.lessThanFloat = lessThanFloat;
            this.inclusive = inclusive;
        }
    }
}
