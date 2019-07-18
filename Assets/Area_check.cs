using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_check : MonoBehaviour
{
    public GameObject Phone_spawn;
    public GameObject Phone;
    public bool Boundaly;

    
    void Update()
    {

       

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Phone.transform.position = Phone_spawn.transform.position;

        }
    }
   /* public void Phone_move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Phone.transform.Translate(0.1f, 0, 0);
        }

    }*/
}
