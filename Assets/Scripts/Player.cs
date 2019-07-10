using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Left hand")]
    public Transform l_hand;
    [SerializeField] private OVRInput.Controller l_controller;
    public bool l_isPointing = false;
    public bool l_isGivingThumbsUp = false;
    public bool l_palm = false;
    public bool l_ful = false;

    [Header("Right hand")]
    public Transform r_hand;
    [SerializeField] private OVRInput.Controller r_controller;
    public bool r_isPointing = false;
    public bool r_isGivingThumbsUp = false;
    public bool r_palm = false;
    public bool r_ful = false;

    [Header("CPR Hand")]
    public SnapHand snapHand;
    public Vector3 centerPoint;
    public GameObject cprHand;

    [Header("Controller")]
    public List<GameObject> controller;
    public GameObject l_controllerMesh;
    public GameObject l_controllerMesh_button01;
    public GameObject l_controllerMesh_button02;
    public GameObject l_controllerMesh_button03;
    public GameObject l_controllerMesh_hold;
    public GameObject l_controllerMesh_stick;
    public GameObject l_controllerMesh_trigger;
    public GameObject r_controllerMesh;
    public GameObject r_controllerMesh_button01;
    public GameObject r_controllerMesh_button02;
    public GameObject r_controllerMesh_button03;
    public GameObject r_controllerMesh_hold;
    public GameObject r_controllerMesh_stick;
    public GameObject r_controllerMesh_trigger;

    public bool l_handIsUnder;
    public bool r_handIsUnder;

    void Start()
    {
        //yield return new WaitForSeconds(1f);
        

    }

    void Update()
    {
        #region FindHandAndController
        if (l_hand == null)
            l_hand = GameObject.Find("hand_left_renderPart_0").GetComponent<Transform>();
        if (r_hand == null)
            r_hand = GameObject.Find("hand_right_renderPart_0").GetComponent<Transform>();

        if (l_controllerMesh == null)
        {
            l_controllerMesh = GameObject.Find("lctrl:left_touch_controller_world");
            //l_controllerMesh.AddComponent<Outline>();
        }
        if (l_controllerMesh_button01 == null)
        {
            l_controllerMesh_button01 = GameObject.Find("lctrl:b_button01");
            //l_controllerMesh_button01.AddComponent<Outline>();
        }
        if (l_controllerMesh_button02 == null)
            l_controllerMesh_button02 = GameObject.Find("lctrl:b_button02");
        if (l_controllerMesh_button03 == null)
            l_controllerMesh_button03 = GameObject.Find("lctrl:b_button03");
        if (l_controllerMesh_hold == null)
            l_controllerMesh_hold = GameObject.Find("lctrl:b_hold");
        if (l_controllerMesh_stick == null)
            l_controllerMesh_stick = GameObject.Find("lctrl:b_stick");
        if (l_controllerMesh_trigger == null)
            l_controllerMesh_trigger = GameObject.Find("lctrl:b_trigger");

        if (r_controllerMesh == null)
            r_controllerMesh = GameObject.Find("rctrl:right_touch_controller_world");
        if (r_controllerMesh_button01 == null)
            r_controllerMesh_button01 = GameObject.Find("rctrl:b_button01");
        if (r_controllerMesh_button02 == null)
            r_controllerMesh_button02 = GameObject.Find("rctrl:b_button02");
        if (r_controllerMesh_button03 == null)
            r_controllerMesh_button03 = GameObject.Find("rctrl:b_button03");
        if (r_controllerMesh_hold == null)
            r_controllerMesh_hold = GameObject.Find("rctrl:b_hold");
        if (r_controllerMesh_stick == null)
            r_controllerMesh_stick = GameObject.Find("rctrl:b_stick");
        if (r_controllerMesh_trigger == null)
            r_controllerMesh_trigger = GameObject.Find("rctrl:b_trigger");
        #endregion
        UpdateCapTouchStates();
        CheckUnderController();
        SnapHandTogether();
    }

    private void UpdateCapTouchStates()
    {
        l_isPointing        = !OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, l_controller) && 
                               OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, l_controller);
        l_isGivingThumbsUp  = !OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, l_controller) && 
                               OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, l_controller);
        r_isPointing        = !OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, r_controller) && 
                               OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, r_controller);
        r_isGivingThumbsUp  = !OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, r_controller) && 
                               OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, r_controller);

        l_palm  = !OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, l_controller) && 
                  !OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, l_controller) && 
                  !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, l_controller);
        r_palm  = !OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, r_controller) && 
                  !OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, r_controller) && 
                  !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, r_controller);


        l_ful   = OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, l_controller) &&
                  OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, l_controller) &&
                  OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, l_controller);
        r_ful   = OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, r_controller) &&
                  OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, r_controller) &&
                  OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, r_controller);
    }

    private void CheckUnderController()
    {
        if (l_hand.position.y < r_hand.position.y)
        {
            l_handIsUnder = true;
        }
        else
        {
            l_handIsUnder = false;
        }

        if (r_hand.position.y < l_hand.position.y)
        {
            r_handIsUnder = true;
        }
        else
        {
            r_handIsUnder = false;
        }
    }

    private void SnapHandTogether()
    {
        centerPoint = (l_hand.position + r_hand.position) / 2;

        if (snapHand.snaping && l_handIsUnder && l_palm && r_ful)
        {
            l_hand.gameObject.SetActive(false);
            r_hand.gameObject.SetActive(false);
            cprHand.SetActive(true);
            cprHand.transform.position = centerPoint;
            cprHand.transform.rotation = Quaternion.identity;
        }
        else if (snapHand.snaping && r_handIsUnder && r_palm && l_ful)
        {
            l_hand.gameObject.SetActive(false);
            r_hand.gameObject.SetActive(false);
            cprHand.SetActive(true);
            cprHand.transform.position = centerPoint;
            cprHand.transform.rotation = Quaternion.identity;
        }
        else
        {
            l_hand.gameObject.SetActive(true);
            r_hand.gameObject.SetActive(true);
            cprHand.SetActive(false);
        }
    }
}
