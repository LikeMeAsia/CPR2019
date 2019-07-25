using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posture_check : MonoBehaviour
{
    public GameObject Posture_check_Ui;
    public GameObject Lay_phone_area;

    public bool posture_check;
    public bool Ui_Timing_checker;

    // Start is called before the first frame update
    void Start()
    {
        Lay_phone_area.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ui_Timing_check();
        Phone_lay_spot();
    }
    
    public void Phone_lay_spot()
    {
        if(Ui_Timing_checker==true)
        {
            Lay_phone_area.SetActive(true);

        }
        else
            Lay_phone_area.SetActive(false);

    }
    public void Ui_Timing_check()
    {
      /*  if (Conversation1_check.time == Conversation1_check.clip.length)
        {
            Ui_Timing_checker = true;
            Debug.Log("Call_1_End");
        }*/
    }
}
