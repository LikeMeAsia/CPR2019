//Name: Robert MacGillivray
//File: ReadOnlyInInspector.cs
//Date: Apr.21.2015
//Purpose: To make a class for my ReadOnlyInInspector attribute to be called

//Last Updated: Nov.24.2015 by Robert MacGillivray

using UnityEngine;
using System.Collections;

namespace UmbraEvolution
{
    /// <summary>
    /// Accesses a property drawer that allows a public, serializable property to be visible, but not editible in the inspector. Usefull when you want a property to be serialized, but do not want people to be able to mess around with it.
    /// </summary>
    public class ReadOnlyInInspectorAttribute : PropertyAttribute
    {
        //this class has no special properties, it is just used to access a property drawer
    }
}
