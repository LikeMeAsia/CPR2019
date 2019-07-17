using UnityEngine;
using UnityEngine.UI;

public class Calling : MonoBehaviour
{

    public Player player;
    public GameObject aphone;
    public GameObject phone;
    public GameObject Black_screen;
    public GameObject calling_screen;
    public AudioSource Conversation1;
    public AudioSource Put_Phone_Call_button;
    public GameObject Phone_Activate_Icon;
    public GameObject Put_calling_button;
    public GameObject Lay_Phone_warning;



    public float audio_time;
    public bool Call;
    public bool Phone_Calling;
    public bool Phone_Activate;
    public bool Icon_show;
    public bool warrning_icon;
    public bool Conv_2_check;


    void Start()
    {
        Intilize();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    void Update()
    {


        //Phone_Activate_Function();
        
        Activate_check();
        Icon_check();
        Conversation1_check();
        Timescale();
      


    }

    public void Intilize()
    {
        Phone_Calling = false;
        Call = false;
        Phone_Activate = false;
        Icon_show = true;
        Put_calling_button.SetActive(false);


        audio_time = 2.0f;
        Conversation1.Stop();
        
        Put_Phone_Call_button.Stop();

    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hand") )
        {
            Phone_Activate = true;
        }
        if ( other.CompareTag("hand") && (player.l_isPointing || player.r_isPointing))
        {
            Call = true;
            Phone_Calling = true;
            warrning_icon = true;
            
        }
       
        if (other.gameObject.CompareTag("Phone_area"))
        {
            Lay_Phone_warning.SetActive(false);
            warrning_icon = false;
           

        }

    }



    public void Conversation1_check()
    {
        if (Phone_Calling == true)
        {
            Put_Phone_Call_button.Play();
            Conversation1.PlayDelayed(Put_Phone_Call_button.clip.length);


            Put_calling_button.SetActive(false);

            Icon_show = false;
            Phone_Calling = false;

        }

    }

    /*public void Phone_Activate_Function()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            phone.transform.Translate(0, 1, 0);
            aphone.transform.Rotate(90, 0, 0);
            Phone_Activate = true;
        }


    }*/

    public void Activate_check()
    {
        if (Phone_Activate == true)
        {
            Black_screen.SetActive(false);
            Phone_Activate_Icon.SetActive(false);
            calling_screen.SetActive(true);

        }

    }

    public void Icon_check()
    {
        if (Phone_Activate == true && Icon_show == true)
        {
            Put_calling_button.SetActive(true);
        }


    }

    public void Timescale()
    {
        if (Conversation1.time == Conversation1.clip.length && warrning_icon == true)
        {
            Lay_Phone_warning.SetActive(true);
        }
        else if (warrning_icon == false)
            Lay_Phone_warning.SetActive(false);


    }


}
