using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShoulder : MonoBehaviour
{
    public GameObject shoulderModel;
    public GameObject layPhoneUI;
    public BeatController beatController;
    int countCheckShake;
    public AudioSource Seq_2Conversation1,Seq_2Conversation2;
    public AudioSource Seq_3Conversation1, Seq_3Conversation2, Seq_3Conversation3, Seq_3Conversation4, Seq_3Conversation5, Seq_3Conversation6;
    public bool Calling_End;
    public static bool shakeEnd;
    public Calling calling;

    public int maxHit;

    // Start is called before the first frame update
    void Start()
    {
        countCheckShake = 0;
        Calling_End = false;
        shakeEnd = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            countCheckShake++;
            Debug.Log("Shake!" + countCheckShake + "/"+ maxHit) ;
            if (countCheckShake == maxHit)
            {
                shakeEnd = true;
                calling.StartTeachCprCall();
                shoulderModel.SetActive(false);
                layPhoneUI.SetActive(false);
            }
        }

    }

    

}
