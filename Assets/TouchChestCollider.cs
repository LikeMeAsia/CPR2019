﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchChestCollider : MonoBehaviour
{
    public bool touchFatherChest=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand Checker"))
        {
            Debug.Log("touchFatherChest = true");
            touchFatherChest = true;
        }
    }
}
