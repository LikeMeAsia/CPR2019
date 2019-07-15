using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class put : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Finger;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            {
            Finger.transform.Translate(0,0, 0.3f);
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Finger.transform.Translate(0, 0, -0.3f);
        }
    }
}
