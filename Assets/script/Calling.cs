using UnityEngine;
using UnityEngine.UI;

public class Calling : MonoBehaviour
{

    public GameObject aphone;
    public GameObject phone;
    public GameObject Black_screen;
    public GameObject calling_screen;
    public AudioSource Phone_speaker;
    public AudioSource Put_Phone_Call_button;
    public GameObject Phone_Activate_Icon;
    public GameObject Put_calling_button;
    public GameObject Lay_Phone_warning;

    public bool Phone_Calling;
    public bool Phone_Activate;
    public bool Icon_show;


    void Start()
    {
        Intilize();
       
    }

   
    void Update()
    {

        if(Phone_Calling==false)
        {
            Lay_Phone_warning.SetActive(false);
        }
        Phone_Activate_Function();
        Activate_check();
        Icon_check();
        Call_Check();
        Debug.Log(Phone_Calling);


    }

    public void Intilize()
    {
        Phone_Calling = false;
        Phone_Activate = false;
        Icon_show = true;
        Put_calling_button.SetActive(false);
       
        Phone_speaker.Stop();
        Put_Phone_Call_button.Stop();
       
    }

   /* public bool phone_active_check()
    {
        return Phone_Calling;
    }*/

   private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            Phone_Calling = true;
        }

    }

    public void Call_Check()// Phone_cl is Phone_Calling
    {
        if(Phone_Calling == true)
        {
            Put_Phone_Call_button.Play();
            Phone_speaker.Play();
            Put_calling_button.SetActive(false);
           
            Icon_show = false;
            Phone_Calling =false;
        
        }
       
    }

    public void Phone_Activate_Function()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            phone.transform.Translate(0, 1, 0);
            aphone.transform.Rotate(90, 0, 0);
            Phone_Activate = true;
        }

       
    }

    public void Activate_check()
    {
        if(Phone_Activate == true)
        {
            Black_screen.SetActive(false);
            Phone_Activate_Icon.SetActive(false);
            calling_screen.SetActive(true);

        }
        
    }

    public void Icon_check()
    {
        if(Phone_Activate == true && Icon_show==true)
        {
            Put_calling_button.SetActive(true);
        }
        
        
    }

    public void Laydown_phone_Function()
    {




    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Phone_area"))
        {
            Lay_Phone_warning.SetActive(false);
        }
    }


}
