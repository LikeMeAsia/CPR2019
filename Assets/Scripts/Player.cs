using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get { return instance; } }
    public void Awake() {
        instance = this;
        ready = false;
    }

    private const string L_CTRL_PARENT = "TrackingSpace/LeftHandAnchor";
    private const string R_CTRL_PARENT = "TrackingSpace/RightHandAnchor";

    [Header(" Player")]
    [ReadOnly]
    public OvrAvatar m_OvrAvatar;
    [ReadOnly]
    public OVRCameraRig m_OvrCamera;
    public float playerHeight;
    public bool playerSit;

    [Header("Left hand")]
    [ReadOnly]
    public Transform l_hand;
    [SerializeField] private OVRInput.Controller l_controller;
    public bool l_isPointing = false;
    public bool l_isGivingThumbsUp = false;
    public bool l_palm = false;
    public bool l_ful = false;

    [Header("Right hand")]
    [ReadOnly]
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
    [ReadOnly]
    public GameObject l_controller_mesh;
    public GameObject l_OutlineCtrlPrefab;
    public TouchButtonOutlines leftButtons;

    [Header("Right Controller")]
    [ReadOnly]
    public GameObject r_controller_mesh;
    public GameObject r_OutlineCtrlPrefab;
    public TouchButtonOutlines rightButtons;

    public bool l_handIsUnder;
    public bool r_handIsUnder;
    [Header(" ")]
    public bool showController;
    private bool curController;

    public Transform l_indexFingerTrans;
    public Transform r_indexFingerTrans;
    // Check initial all required parameters
    public bool ready = false;

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

    IEnumerator Start()
    {
        m_OvrAvatar = this.GetComponentInChildren<OvrAvatar>();
        m_OvrCamera = this.GetComponentInChildren<OVRCameraRig>();
        
        curController = m_OvrAvatar.StartWithControllers;
        showController = curController;
        playerHeight = m_OvrCamera.transform.position.y;
        Transform l_anchor = m_OvrCamera.transform.Find(L_CTRL_PARENT);
        if (l_anchor != null)
        {
            GameObject o_leftButtons = Instantiate(l_OutlineCtrlPrefab, l_anchor);
            leftButtons = o_leftButtons.GetComponent<TouchButtonOutlines>();
            leftButtons.transform.localPosition = Vector3.zero;
            leftButtons.transform.localRotation = Quaternion.identity;
        }
        Transform r_anchor = m_OvrCamera.transform.Find(R_CTRL_PARENT);
        if (r_anchor != null)
        {
            GameObject o_rightButtons = Instantiate(r_OutlineCtrlPrefab, r_anchor);
            rightButtons = o_rightButtons.GetComponent<TouchButtonOutlines>();
            rightButtons.transform.localPosition = Vector3.zero;
            rightButtons.transform.localRotation = Quaternion.identity;
        }

        #region Player's Hands and Controllers
        // Wait instantiate Left Hand
        WaitWhile waitInst_LHand = new WaitWhile(() => { return m_OvrAvatar.transform.Find("hand_left/hand_left_renderPart_0") == null; });
        yield return waitInst_LHand;
        l_hand = m_OvrAvatar.transform.Find("hand_left/hand_left_renderPart_0");
        l_hand.tag = "hand";

        // Wait instantiate Right Hand
        WaitWhile waitInst_RHand = new WaitWhile(() => { return m_OvrAvatar.transform.Find("hand_right/hand_right_renderPart_0") == null; });
        yield return waitInst_RHand;
        r_hand = m_OvrAvatar.transform.Find("hand_right/hand_right_renderPart_0");
        r_hand.tag = "hand";
        // Wait instantiate Left Controller
        WaitWhile waitInst_LController = new WaitWhile(() => { return GameObject.Find("controller_left") == null; });
        yield return waitInst_LHand;
        l_controller_mesh = GameObject.Find("controller_left");

        // Wait instantiate Right Controller
        WaitWhile waitInst_RController = new WaitWhile(() => { return GameObject.Find("controller_right") == null; });
        yield return waitInst_LHand;
        r_controller_mesh = GameObject.Find("controller_right");
        
        l_hand.gameObject.ApplyRecursivelyOnDescendants(child => child.layer = LayerMask.NameToLayer("OnTop"));
        r_hand.gameObject.ApplyRecursivelyOnDescendants(child => child.layer = LayerMask.NameToLayer("OnTop"));
        l_controller_mesh.gameObject.ApplyRecursivelyOnDescendants(child => child.layer = LayerMask.NameToLayer("OnTop"));
        r_controller_mesh.gameObject.ApplyRecursivelyOnDescendants(child => child.layer = LayerMask.NameToLayer("OnTop"));
        #endregion
        ready = true;
    }

    void Update()
    {
        if (playerHeight <=0)
        {
            playerHeight = m_OvrCamera.transform.position.y;
        }
        if (m_OvrCamera.transform.position.y <= playerHeight/2){
            playerSit = true;
        }
        else  {  
          playerSit = false;
        }

        if (!ready) return;
        if (showController != curController) {
            m_OvrAvatar.ShowControllers(showController);
            curController = showController;
        }

        if (l_hand != null && l_indexFingerTrans == null) {
            l_indexFingerTrans = l_hand.Find("hands:l_hand_world/hands:b_l_hand/hands:b_l_index1/hands:b_l_index2/hands:b_l_index3/hands:b_l_index_ignore");
            if (l_indexFingerTrans != null)
            {
                GameObject fingerTipObj = Instantiate<GameObject>(new GameObject("l_index_tip"), l_indexFingerTrans);
                SphereCollider indexTipCollider = fingerTipObj.AddComponent<SphereCollider>();
                indexTipCollider.isTrigger = true;
                indexTipCollider.radius = 0.01f;
                indexTipCollider.center = new Vector3(0.01f, 0, 0);
                fingerTipObj.tag = "FingerTip";
            }
        }

        if (r_hand != null && r_indexFingerTrans == null)
        {
            r_indexFingerTrans = r_hand.Find("hands:r_hand_world/hands:b_r_hand/hands:b_r_index1/hands:b_r_index2/hands:b_r_index3/hands:b_r_index_ignore");
            if (r_indexFingerTrans != null)
            {
                GameObject fingerTipObj = Instantiate<GameObject>(new GameObject("r_index_tip"), r_indexFingerTrans);
                SphereCollider indexTipCollider = fingerTipObj.AddComponent<SphereCollider>();
                indexTipCollider.isTrigger = true;
                indexTipCollider.radius = 0.01f;
                indexTipCollider.center = new Vector3(0.01f, 0, 0);
                fingerTipObj.tag = "FingerTip";
            }
        }
        
        UpdateCapTouchStates();
        CheckUnderController();
       // SnapHandTogether();
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

        if (snapHand.snaping && l_handIsUnder /*&& l_palm*/ && r_ful)
        {
            l_hand.gameObject.SetActive(false);
            r_hand.gameObject.SetActive(false);
            cprHand.SetActive(true);
            cprHand.transform.position = centerPoint;
            cprHand.transform.rotation = Quaternion.identity;
        }
        else if (snapHand.snaping && r_handIsUnder /*&& r_palm*/ && l_ful)
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

    public void EnableOutlineHandFul()
    {
        leftButtons.EnableOutlineHandful();
        rightButtons.EnableOutlineHandful();
    }

    public void EnableOutlinePointing()
    {
        leftButtons.EnableOutlinePointingHand();
        rightButtons.EnableOutlinePointingHand();
    }

    public void EnableOutlineBareHands()
    {
        leftButtons.EnableOutlineBareHand();
        rightButtons.EnableOutlineBareHand();
    }

}
