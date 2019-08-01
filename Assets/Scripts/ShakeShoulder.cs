using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShoulder : MonoBehaviour
{
    public GameObject shoulderModel;
    public GameObject layPhoneUI;
    public BeatController beatController;
    int countCheckShake;
    public static bool shakeEnd;
    public Calling calling;

    public int maxHit;

    // Start is called before the first frame update
    void Start()
    {
        countCheckShake = 0;
        shakeEnd = false;
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
                ScenarioControl.Instance.shoulderCanvas.GetComponent<Animator>().SetBool("disable", true);
            }
        }

    }
}
