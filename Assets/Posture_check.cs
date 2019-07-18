using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posture_check : MonoBehaviour
{
    public GameObject Player_Head;
    public GameObject Posture_check_Ui;
    public GameObject Lay_phone_area;
    public AudioSource Conversation1_check;

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
        Posture_Check();
        Ui_Timing_check();
        Posture_Set();
        Check_Posture();
    }

    public void Posture_Check()
    {

        if (Player_Head.transform.position.y > 3 && Ui_Timing_checker == true)
        {
            Posture_check_Ui.SetActive(true);
            posture_check = false;
        }
        else if (Player_Head.transform.position.y < 3 && Ui_Timing_checker == true)
        {
            Posture_check_Ui.SetActive(false);
            posture_check = true;
        }


    }

    public void Posture_Set()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Player_Head.transform.Translate(0, 3.5f, 0);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Player_Head.transform.Translate(0, -3.5f, 0);
        }

    }

    public void Check_Posture()
    {
        if (posture_check == true)
        {
            Lay_phone_area.SetActive(true);
        }
        else
            Lay_phone_area.SetActive(false);

    }

    public void Ui_Timing_check()
    {
        if (Conversation1_check.time == Conversation1_check.clip.length)
        {
            Ui_Timing_checker = true;
        }
    }
}
