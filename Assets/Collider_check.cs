using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_check : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Box")
        {
            Debug.Log("Box destroyyyyyyyy");
            Destroy(other.gameObject);
        }
    }
}
