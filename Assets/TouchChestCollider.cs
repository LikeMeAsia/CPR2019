using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchChestCollider : MonoBehaviour
{
    public bool touchFatherChest=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand Checker"))
        {
            //Debug.Log("touchFatherChest = true");
            touchFatherChest = true;
        }
    }
}
