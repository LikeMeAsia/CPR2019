using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShoulder : MonoBehaviour
{
    public BeatController beatController;
    int countCheckShake;

    public int maxHit;

    // Start is called before the first frame update
    void Start()
    {
        countCheckShake = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            countCheckShake++;
            Debug.Log("Shake!" + countCheckShake + "/"+ maxHit) ;
            if (countCheckShake == maxHit)
            {
                beatController.EnableBeatTutorial();
                gameObject.SetActive(false);
            }
        }

    }
}
