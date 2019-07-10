using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handclasp : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject twoHand;

    void Start()
    {
        twoHand.SetActive(false);
    }

   
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HandClasp"))
        {
            twoHand.SetActive(true);
            leftHand.SetActive(false);
            rightHand.SetActive(false);
            Debug.Log("HandClasp!");
        }
    }
}
