using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShoulder : MonoBehaviour
{
    public BeatController beatController;
    int countCheckShake;
    public AudioSource Seq_2Conversation1,Seq_2Conversation2;
    public AudioSource Seq_3Conversation1, Seq_3Conversation2, Seq_3Conversation3, Seq_3Conversation4, Seq_3Conversation5, Seq_3Conversation6;
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
                ScenarioControl.Instance.cprCanvas.SetActive(true);
                beatController.EnableBeatTutorial();
                gameObject.SetActive(false);
                Seq_2Conversation1.PlayDelayed(0.5f);
                Seq_2Conversation2.PlayDelayed(Seq_2Conversation1.clip.length + 0.5f);
                Seq_3Conversation1.PlayDelayed(Seq_2Conversation1.clip.length + Seq_2Conversation2.clip.length+1.0f);
                Seq_3Conversation2.PlayDelayed(Seq_2Conversation1.clip.length + Seq_2Conversation2.clip.length + Seq_3Conversation1.clip.length + 1.0f);
                Seq_3Conversation3.PlayDelayed(Seq_2Conversation1.clip.length + Seq_2Conversation2.clip.length + Seq_3Conversation1.clip.length + Seq_3Conversation2.clip.length + 1.0f);
                Seq_3Conversation4.PlayDelayed(Seq_2Conversation1.clip.length + Seq_2Conversation2.clip.length + Seq_3Conversation1.clip.length + Seq_3Conversation2.clip.length + Seq_3Conversation3.clip.length + 1.0f);
                Seq_3Conversation5.PlayDelayed(Seq_2Conversation1.clip.length + Seq_2Conversation2.clip.length + Seq_3Conversation1.clip.length + Seq_3Conversation2.clip.length + Seq_3Conversation3.clip.length + Seq_3Conversation4.clip.length + 1.0f);
                Seq_3Conversation6.PlayDelayed(Seq_2Conversation1.clip.length + Seq_2Conversation2.clip.length + Seq_3Conversation1.clip.length + Seq_3Conversation2.clip.length + Seq_3Conversation3.clip.length + Seq_3Conversation4.clip.length + Seq_3Conversation5.clip.length + 1.0f);

            }
        }

    }

    public void Calling_End_check()
    {
        if(Seq_3Conversation6.time== Seq_3Conversation6.clip.length)
        {
            Calling_End = true;
        }
        

    }
    

}
