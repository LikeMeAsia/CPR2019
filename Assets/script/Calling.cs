
using UnityEngine;
using UnityEngine.UI;

public class Calling : MonoBehaviour
{

    public GameObject aphone;
    public GameObject Black_screen;
    public GameObject calling_screen;
    public AudioSource Phone_speaker;
    public GameObject Phone_Activate_Icon;

    public bool Phone_Calling;
    public bool Phone_Activate;

    void Start()
    {
        Phone_Calling = false;
        Phone_Activate = false;
        Phone_speaker.Stop();
    }

   
    void Update()
    {
        //Call_Check();
        Phone_Activate_Function();
        
        if(Phone_Activate==true)
        {
            Debug.Log(phone_active_check());
            Check();
            
        }
        
        //Check();
        //Calling_Function();

    }

    public bool phone_active_check()
    {
        return Phone_Calling;
    }

   /* public void Calling_Function()
    {
        if (Phone_Calling == true)
        {
            Phone_speaker.Play();
            //Debug.Log("conversation Go");
            Phone_Calling = false;
        }
        else
            Phone_speaker.Stop();
            //Debug.Log("conversation Stop");
    }*/



    /*public void Call_Check()
    {
        if (Input.anyKey)
        {
            Phone_Calling = true;
            Debug.Log("Call_Check is working and Phone call is true");
        }
    }*/

   private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            Debug.Log("put button");
            Phone_Calling = true;
        }

    }


    public void Check()
    {
        if(Phone_Calling == true)
        {
            Phone_speaker.Play();
            Phone_Calling = false;
        }
    }

    public void Phone_Activate_Function()
    {
        if(aphone.transform.position.y>1)
        {

            //Debug.Log("Phone_Activate_Function is Working");
            Phone_Activate = true;
            Black_screen.SetActive(false);
            Phone_Activate_Icon.SetActive(false);
            calling_screen.SetActive(true);
        }
    }

   

}
