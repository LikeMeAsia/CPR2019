using UnityEngine;
using System;

// Hide or Disable Fields based on user input
// How to use; use like Header attribute, defualt condition is false
// 1. [ConditionalHide("EnableAutoAim", true)]]
/**
        [Header("Auto Aim")]
        public bool EnableAutoAim = false;
 
        [ConditionalHide("EnableAutoAim", true)]
        public float Range = 0.0f;
**/
// 2. [ConditionalHide("ConsumeResources")]
/**
        [Header("Resources")]
        public bool ConsumeResources = true;
 
        [ConditionalHide("ConsumeResources")]
        public bool DestroyOnResourcesDepleted = true;
**/
// credit: brechtos
// source: http://www.brechtos.com/hiding-or-disabling-inspector-properties-using-propertydrawers-within-unity-5/

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute
{
    //The name of the bool field that will be in control
    public string ConditionalSourceField = "";
    //TRUE = Hide in inspector / FALSE = Disable in inspector 
    public bool HideInInspector = false;

    public ConditionalHideAttribute(string conditionalSourceField)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = false;
    }

    public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
    }
}