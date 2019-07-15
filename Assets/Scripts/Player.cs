using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Player_Script_Temp : MonoBehaviour
{
    public OvrAvatar m_OvrAvatar;

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

    [Header("Left Controller")]
    public GameObject l_button01;
    public GameObject l_button02;
    public GameObject l_side_trigger;
    public GameObject l_trigger;
    public GameObject l_stick;
    [Header("Right Controller")]
    public GameObject r_button01;
    public GameObject r_button02;
    public GameObject r_side_trigger;
    public GameObject r_trigger;
    public GameObject r_stick;
    [Header("For Debug")]
    public bool l_button01_outline;
    public bool l_button02_outline;
    public bool l_side_trigger_outline;
    public bool l_trigger_outline;
    public bool l_stick_outline;
    public bool r_button01_outline;
    public bool r_button02_outline;
    public bool r_side_trigger_outline;
    public bool r_trigger_outline;
    public bool r_stick_outline;

    public bool l_handIsUnder;
    public bool r_handIsUnder;
    [Header(" ")]
    public bool showController;

    // Check initial all required parameters
    public bool ready = false;

    IEnumerator Start()
    {
        ready = false;
        #region FindHand
        // Wait instantiate Left Hand
        WaitWhile waitInst_LHand = new WaitWhile(() => { return GameObject.Find("hand_left_renderPart_0") == null; });
        yield return waitInst_LHand;
        l_hand = GameObject.Find("hand_left_renderPart_0").GetComponent<Transform>();


        // Wait instantiate Right Hand
        WaitWhile waitInst_RHand = new WaitWhile(() => { return GameObject.Find("hand_right_renderPart_0") == null; });
        yield return waitInst_RHand;
        r_hand = GameObject.Find("hand_right_renderPart_0").GetComponent<Transform>();

        l_hand.gameObject.layer = LayerMask.NameToLayer("Heart");
        r_hand.gameObject.layer = LayerMask.NameToLayer("Heart");

        #region Controller Unuse;
        // Setup Touch Controllers
        // Only work when start with controllers
        /* if (m_OvrAvatar.StartWithControllers)
         {
             // Wait instantiate Left Touch Controller
             WaitWhile waitInst_LTouchCtrl = new WaitWhile(() => { return GameObject.Find("lctrl:left_touch_controller_world") == null; });
             yield return waitInst_LTouchCtrl;
             l_controllerMesh = GameObject.Find("lctrl:left_touch_controller_world");
             //l_controllerMesh.AddComponent<Outline>();
             controller.Add(l_controllerMesh);

             // Wait instantiate Right Touch Controller
             WaitWhile waitInst_RTouchCtrl = new WaitWhile(() => { return GameObject.Find("rctrl:right_touch_controller_world") == null; });
             yield return waitInst_RTouchCtrl;
             r_controllerMesh = GameObject.Find("rctrl:right_touch_controller_world");
             controller.Add(r_controllerMesh);

             // Wait instantiate Left Button 1
             WaitWhile waitInst_LBtn01 = new WaitWhile(() => { return GameObject.Find("lctrl:b_button01") == null; });
             yield return waitInst_LBtn01;
             l_controllerMesh_button01 = GameObject.Find("lctrl:b_button01");
             //l_controllerMesh_button01.AddComponent<Outline>();
             controller.Add(l_controllerMesh_button01);

             // Wait instantiate Right Button 1
             WaitWhile waitInst_RBtn01 = new WaitWhile(() => { return GameObject.Find("rctrl:b_button01") == null; });
             yield return waitInst_RBtn01;
             r_controllerMesh_button01 = GameObject.Find("rctrl:b_button01");
             controller.Add(r_controllerMesh_button01);

             // Wait instantiate Left Button 2
             WaitWhile waitInst_LBtn02 = new WaitWhile(() => { return GameObject.Find("lctrl:b_button02") == null; });
             yield return waitInst_LBtn02;
             l_controllerMesh_button02 = GameObject.Find("lctrl:b_button02");
             controller.Add(l_controllerMesh_button02);

             // Wait instantiate Right Button 2
             WaitWhile waitInst_RBtn02 = new WaitWhile(() => { return GameObject.Find("rctrl:b_button02") == null; });
             yield return waitInst_RBtn02;
             r_controllerMesh_button02 = GameObject.Find("rctrl:b_button02");
             controller.Add(r_controllerMesh_button02);

             // Wait instantiate Left Button 3
             WaitWhile waitInst_LBtn03 = new WaitWhile(() => { return GameObject.Find("lctrl:b_button03") == null; });
             yield return waitInst_LBtn03;
             l_controllerMesh_button03 = GameObject.Find("lctrl:b_button03");
             controller.Add(l_controllerMesh_button03);

             // Wait instantiate Right Button 3
             WaitWhile waitInst_RBtn03 = new WaitWhile(() => { return GameObject.Find("rctrl:b_button03") == null; });
             yield return waitInst_RBtn03;
             r_controllerMesh_button03 = GameObject.Find("rctrl:b_button03");
             controller.Add(r_controllerMesh_button03);

             // Wait instantiate Left Hold
             WaitWhile waitInst_LHold = new WaitWhile(() => { return GameObject.Find("lctrl:b_hold") == null; });
             yield return waitInst_LHold;
             l_controllerMesh_hold = GameObject.Find("lctrl:b_hold");
             controller.Add(l_controllerMesh_hold);

             // Wait instantiate Right Hold
             WaitWhile waitInst_RHold = new WaitWhile(() => { return GameObject.Find("rctrl:b_hold") == null; });
             yield return waitInst_RHold;
             r_controllerMesh_hold = GameObject.Find("rctrl:b_hold");
             controller.Add(r_controllerMesh_hold);

             // Wait instantiate Left Stick
             WaitWhile waitInst_LStick = new WaitWhile(() => { return GameObject.Find("lctrl:b_stick") == null; });
             yield return waitInst_LStick;
             l_controllerMesh_stick = GameObject.Find("lctrl:b_stick");
             controller.Add(l_controllerMesh_stick);

             // Wait instantiate Right Stick
             WaitWhile waitInst_RStick = new WaitWhile(() => { return GameObject.Find("rctrl:b_stick") == null; });
             yield return waitInst_RStick;
             r_controllerMesh_stick = GameObject.Find("rctrl:b_stick");
             controller.Add(r_controllerMesh_stick);

             // Wait instantiate Left Trigger
             WaitWhile waitInst_LTrigger = new WaitWhile(() => { return GameObject.Find("lctrl:b_trigger") == null; });
             yield return waitInst_LTrigger;
             l_controllerMesh_trigger = GameObject.Find("lctrl:b_trigger");
             controller.Add(l_controllerMesh_trigger);

             // Wait instantiate Right Trigger
             WaitWhile waitInst_RTrigger = new WaitWhile(() => { return GameObject.Find("rctrl:b_trigger") == null; });
             yield return waitInst_RTrigger;
             r_controllerMesh_trigger = GameObject.Find("rctrl:b_trigger");
             controller.Add(r_controllerMesh_trigger);
        #endregion
    }*/
        #endregion
        #endregion
        l_button01.SetActive(false);
        l_button02.SetActive(false);
        l_side_trigger.SetActive(false);
        l_trigger.SetActive(false);
        l_stick.SetActive(false);
        r_button01.SetActive(false);
        r_button02.SetActive(false);
        r_side_trigger.SetActive(false);
        r_trigger.SetActive(false);
        r_stick.SetActive(false);
    ready = true;
    }

    void Update()
    {
        #region FindHandAndController
        // Old script that used before changed to setup at Start()
        /* 
         if (l_hand == null)
             l_hand = GameObject.Find("hand_left_renderPart_0").GetComponent<Transform>();
         if (r_hand == null)
             r_hand = GameObject.Find("hand_right_renderPart_0").GetComponent<Transform>();

         if (l_controllerMesh == null)
         {
             l_controllerMesh = GameObject.Find("lctrl:left_touch_controller_world");
             //l_controllerMesh.AddComponent<Outline>();
             controller.Add(l_controllerMesh);
         }
         if (l_controllerMesh_button01 == null)
         {
             l_controllerMesh_button01 = GameObject.Find("lctrl:b_button01");
             //l_controllerMesh_button01.AddComponent<Outline>();
             controller.Add(l_controllerMesh_button01);
         }
         if (l_controllerMesh_button02 == null)
         {
             l_controllerMesh_button02 = GameObject.Find("lctrl:b_button02");
             controller.Add(l_controllerMesh_button02);
         }
         if (l_controllerMesh_button03 == null)
         {
             l_controllerMesh_button03 = GameObject.Find("lctrl:b_button03");
             controller.Add(l_controllerMesh_button03);
         }
         if (l_controllerMesh_hold == null)
         {
             l_controllerMesh_hold = GameObject.Find("lctrl:b_hold");
             controller.Add(l_controllerMesh_hold);
         }
         if (l_controllerMesh_stick == null)
         {
             l_controllerMesh_stick = GameObject.Find("lctrl:b_stick");
             controller.Add(l_controllerMesh_stick);
         }
         if (l_controllerMesh_trigger == null)
         {
             l_controllerMesh_trigger = GameObject.Find("lctrl:b_trigger");
             controller.Add(l_controllerMesh_trigger);
         }

         if (r_controllerMesh == null)
         {
             r_controllerMesh = GameObject.Find("rctrl:right_touch_controller_world");
             controller.Add(r_controllerMesh);

         }
         if (r_controllerMesh_button01 == null)
         {
             r_controllerMesh_button01 = GameObject.Find("rctrl:b_button01");
             controller.Add(r_controllerMesh_button01);

         }
         if (r_controllerMesh_button02 == null)
         {
             r_controllerMesh_button02 = GameObject.Find("rctrl:b_button02");
             controller.Add(r_controllerMesh_button02);

         }
         if (r_controllerMesh_button03 == null)
         {
             r_controllerMesh_button03 = GameObject.Find("rctrl:b_button03");
             controller.Add(r_controllerMesh_button03);

         }
         if (r_controllerMesh_hold == null)
         {
             r_controllerMesh_hold = GameObject.Find("rctrl:b_hold");
             controller.Add(r_controllerMesh_hold);

         }
         if (r_controllerMesh_stick == null)
         {
             r_controllerMesh_stick = GameObject.Find("rctrl:b_stick");
             controller.Add(r_controllerMesh_stick);

         }
         if (r_controllerMesh_trigger == null)
         {
             r_controllerMesh_trigger = GameObject.Find("rctrl:b_trigger");
             controller.Add(r_controllerMesh_trigger);

         }
         */
        #endregion
        if (!ready) return;
        UpdateCapTouchStates();
        CheckUnderController();
        SnapHandTogether();
        #region Debug Outline
        EnableOutline(l_button01, l_button01_outline);
        EnableOutline(l_button02, l_button01_outline);
        EnableOutline(l_stick, l_stick_outline);
        EnableOutline(l_trigger, l_trigger_outline);
        EnableOutline(l_side_trigger, l_side_trigger_outline);

        EnableOutline(r_button01, r_button01_outline);
        EnableOutline(r_button02, r_button01_outline);
        EnableOutline(r_stick, r_stick_outline);
        EnableOutline(r_trigger, r_trigger_outline);
        EnableOutline(r_side_trigger, r_side_trigger_outline);
        #endregion
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

    private void EnableOutline(GameObject button, bool enable)
    {
        button.SetActive(enable);
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(Player))]
    [ExecuteInEditMode]
    public class PlayerPropertyDrawer : Editor
    {
        private bool trackShowController;
        private Player player;
        public void OnEnable()
        {
            Player player = (Player)target;
            trackShowController = player.showController;
        }
        public override void OnInspectorGUI()
        {
            // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            DrawDefaultInspector();
            if (player == null) {
                Player player = (Player)target;
            }
            else {
                if (player.showController != trackShowController)
                {
                    player.m_OvrAvatar.ShowControllers(player.showController);
                    player.showController = trackShowController;
                }
            }
            // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
#endif
}
