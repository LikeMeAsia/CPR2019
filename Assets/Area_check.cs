using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_check : MonoBehaviour
{
    public GameObject Phone_spawn;
    public bool Boundary;


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            transform.position = Phone_spawn.transform.position;

        }
    }
}
