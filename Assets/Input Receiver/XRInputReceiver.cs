using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRInputReceiver : MonoBehaviour
{
    #region parameters
    public enum KEY { PrimaryButton, SecondaryButton, PrimaryTouch, SecondaryTouch, Trigger, Grip, ThumbStick, Menu}

    public InputDeviceCharacteristics controllerCharacteristics;

    private InputDevice targetDevice;
    private Dictionary<KEY, bool> keyValue;
    private Dictionary<KEY, bool> prevKeyValue;

    private readonly bool callLog = false;
    #endregion

    #region public function
    public bool GetKey(KEY key)
    {
        return keyValue[key];
    }

    public bool GetKeyDown(KEY key)
    {
        return prevKeyValue[key] == false && keyValue[key] == true;
    }

    public bool GetKeyUp(KEY key)
    {
        return prevKeyValue[key] == true && keyValue[key] == false;
    }

    public float GetTriggerValue()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            Log("Press Trigger value : " + triggerValue);
            return triggerValue;
        }
        return 0;
    }

    public float GetGripValue()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
        {
            Log("Press Grip value : " + gripValue);
            return gripValue;
        }
        return 0;
    }

    public Vector2 GetPrimary2DAxis()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue)
            && primary2DAxisValue != Vector2.zero)
        {
            Log("Primary Touchpad : " + primary2DAxisValue);
            return primary2DAxisValue;
        }
        return Vector2.zero;
    }

    #endregion

    #region MonoBehaviour function
    void Start()
    {
        keyValue = new Dictionary<KEY, bool>();
        prevKeyValue = new Dictionary<KEY, bool>();
        TryInitialize();
    }
    
    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else {
            WatchAllKeys();
        }
    }
    #endregion

    #region private function
    private void TryInitialize()
    {
        foreach (KEY key in (KEY[])Enum.GetValues(typeof(KEY)))
        {
            keyValue[key] = false;
            prevKeyValue[key] = false;
        }
        
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (InputDevice item in devices)
        {
            Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    private void WatchAllKeys() {
        foreach (KEY key in (KEY[])Enum.GetValues(typeof(KEY)))
        {
            WatchKey(key);
        }
    }

    private void WatchKey(KEY key) {
        prevKeyValue[key] = keyValue[key];
        if (TryGetBoolFeature(key, out bool rbf))
        {
            keyValue[key] = rbf;
        }
        else if (TryGetFloatFeature(key, out bool rff))
        {
            keyValue[key] = rff;
        }
        else if (TryGetVector2Feature(key, out bool rv2f))
        {
            keyValue[key] = rv2f;
        }
        else {
            keyValue[key] = false;
            prevKeyValue[key] = false;
        }
    }

    private bool TryGetBoolFeature(KEY key, out bool result)
    {
        result = false;
        InputFeatureUsage<bool> boolFeature;
        bool foundFeature = true;
        switch (key)
        {
            case KEY.Menu:
                boolFeature = CommonUsages.menuButton;
                break;
            case KEY.PrimaryButton:
                boolFeature = CommonUsages.primaryButton;
                break;
            case KEY.SecondaryButton:
                boolFeature = CommonUsages.secondaryButton;
                break;
            case KEY.PrimaryTouch:
                boolFeature = CommonUsages.primaryTouch;
                break;
            case KEY.SecondaryTouch:
                boolFeature = CommonUsages.secondaryTouch;
                break;
            case KEY.Grip:
                boolFeature = CommonUsages.gripButton;
                break;
            case KEY.Trigger:
                boolFeature = CommonUsages.triggerButton;
                break;
            default:
                foundFeature = false;
                break;
        }
        if (foundFeature && targetDevice.TryGetFeatureValue(boolFeature, out bool value))
        {
            result = value;
            return true;
        }
        return false;
    }

    private bool TryGetFloatFeature(KEY key, out bool result) {
        result = false;
        InputFeatureUsage<float> floatFeature;
        bool foundFeature = true;
        switch (key)
        {
            case KEY.Grip:
                floatFeature = CommonUsages.grip;
                break;
            case KEY.Trigger:
                floatFeature = CommonUsages.trigger;
                break;
            default:
                foundFeature = false;
                break;
        }
        if (foundFeature && targetDevice.TryGetFeatureValue(floatFeature, out float value))
        {
            result = (value > 0);
            return true;
        }
        return false;
    }

    private bool TryGetVector2Feature(KEY key, out bool result)
    {
        result = false;
        InputFeatureUsage<Vector2> vector2Feature;
        bool foundFeature = true;
        switch (key)
        {
            case KEY.ThumbStick:
                vector2Feature = CommonUsages.primary2DAxis;
                break;
            default:
                foundFeature = false;
                break;
        }
        if (foundFeature && targetDevice.TryGetFeatureValue(vector2Feature, out Vector2 value))
        {
            result = (value != Vector2.zero);
            return true;
        }
        return false;
    }
    #endregion

    #region log debug
    private void Log(string msg)
    {
        if (callLog) Debug.Log("[" + name + "] " + msg);
    }
    private void LogError(string msg)
    {
        if (callLog) Debug.LogError("[" + name + "] " + msg);
    }
    #endregion
}
