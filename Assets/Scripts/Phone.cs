using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public bool phoneIsPickedUp;
    public GameObject hand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hand") && (other.GetComponentInParent<Player>().l_ful && other.GetComponentInParent<Player>().r_ful))
        {
            phoneIsPickedUp = true;
            hand = other.gameObject;
        }
    }
}
