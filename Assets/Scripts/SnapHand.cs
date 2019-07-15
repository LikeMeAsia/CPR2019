using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapHand : MonoBehaviour
{
    public bool snaping;
    public bool lockSnap = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("hand") && !lockSnap)
        {
            snaping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hand") && !lockSnap)
        {
            snaping = false;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
