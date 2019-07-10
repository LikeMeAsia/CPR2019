using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShoulder : MonoBehaviour
{

    public GameObject CircleBump;

    int countCheckShake;

    public int CountStart;

    // Start is called before the first frame update
    void Start()
    {
        countCheckShake = 0;
        CircleBump.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (countCheckShake == CountStart)
        {
            CircleBump.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            countCheckShake++;
            Debug.Log("Shake!");
        }
    }
}
