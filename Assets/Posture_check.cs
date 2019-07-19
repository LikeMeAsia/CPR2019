using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posture_check : MonoBehaviour
{
    public Player player;
    public GameObject Posture_check_Ui;
    public GameObject Lay_phone_area;
    public AudioSource Conversation1_check;

    public bool posture_check;
    public bool Ui_Timing_checker;
    // Start is called before the first frame update
    void Start()
    {
        Lay_phone_area.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //Posture_Check();
        Ui_Timing_check();
        Phone_lay_spot();
       // Check_Posture();
    }

    /*public void Posture_Check()
    {
        
        if (!player.playerSit && Ui_Timing_checker == true)
        {
            Posture_check_Ui.SetActive(true);
            posture_check = false;
        }
        else if (player.playerSit && Ui_Timing_checker == true)
        {
            Posture_check_Ui.SetActive(false);
            posture_check = true;
        }

    
    }/*

    

    /*public void Check_Posture()
    {
        if (posture_check == true)
        {
            Lay_phone_area.SetActive(true);
        }
        else
            Lay_phone_area.SetActive(false);

    }*/
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
        if (Conversation1_check.time == Conversation1_check.clip.length)
        {
            Ui_Timing_checker = true;
        }
    }
}
