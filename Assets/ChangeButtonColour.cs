using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColour : MonoBehaviour
{
    public Color hoverColor = Color.red;
    public Button restartButton;
    private OVRGrabbable ovrGrabbable;


    // Start is called before the first frame update
    void Start()
    {
        restartButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ovrGrabbable != null && ovrGrabbable.grabbedBy != null)
        {
            OVRInput.Controller grabControllerType = ((CustomOVRGrabber)ovrGrabbable.grabbedBy).GetControllerType();
            if (
                (Player.Instance.l_isPointing && Player.Instance.r_ful && grabControllerType == OVRInput.Controller.RTouch)
                || (Player.Instance.r_isPointing && Player.Instance.l_ful && grabControllerType == OVRInput.Controller.LTouch)
            )
            {
                //Call();
            }
        }
       // restartButton.image.sprite =  ;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        

     
    }

}
