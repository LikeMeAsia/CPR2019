using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomOVRGrabber : OVRGrabber
{
    public OVRInput.Controller GetControllerType() {
        return m_controller;
    }
}
