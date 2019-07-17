using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShoulder : MonoBehaviour
{
    public BeatController beatController;
    int countCheckShake;
    public AudioSource Conversation2;
    public AudioSource Conversation3;
    public bool Calling_End;

    public int maxHit;

    // Start is called before the first frame update
    void Start()
    {
        countCheckShake = 0;
        Calling_End = false;
    }

    void Update()
    {
        Calling_End_check();
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
                Conversation2.PlayDelayed(0.5f);
                Conversation3.PlayDelayed(Conversation2.clip.length + 0.5f);
            }
        }

    }

    public void Calling_End_check()
    {
        if(Conversation3.time==Conversation3.clip.length)
        {
            Calling_End = true;
        }

    }
}
