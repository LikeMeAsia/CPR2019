//Name: Robert MacGillivray
//File: LessThanInt.cs
//Date: Nov.23.2015
//Purpose: To make a class for my LessThanIntInclusive property drawer to be accessed and to store the appropriate less than X integer value

//Last Updated: Dec.01.2015 by Robert MacGillivray

using UnityEngine;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// Accesses the LessThanInclusive property which limits a float or integer in the inspector to any value less or equal to the provided value.
    /// </summary>
    public class LessThanIntAttribute : PropertyAttribute
    {
        public int lessThanInteger;
        public bool inclusive;

        /// <summary>
        /// Uses an int for the less than comparison
        /// </summary>
        /// <param name="lessThanInt">The integer that will be used to limit the value of this variable</param>
        /// <param name="inclusive">If true, a less than or equal comparison will be used. If false, a non-inclusive less than comparison will be used.</param>
        public LessThanIntAttribute(int lessThanInteger, bool inclusive)
        {
            this.lessThanInteger = lessThanInteger;
            this.inclusive = inclusive;
        }
    }
}
