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
    SphereCollider l_indexTipCollider;

    [Header("Right hand")]
    [ReadOnly]
    public Transform r_hand;
    [SerializeField] private OVRInput.Controller r_controller;
    public bool r_isPointing = false;
    public bool r_isGivingThumbsUp = false;
    public bool r_palm = false;
    public bool r_ful = false;
    SphereCollider r_indexTipCollider;

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

    [Header("CPR Hands")]
    public CPRHand cprHand;

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
        m_OvrAvatar.ShowControllers(showController);
        curController = showController;
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
        WaitWhile waitInst_LHand = new WaitWhile(() => { return m_OvrAvatar.transform.Find("hand_left") == null; });
        yield return waitInst_LHand;
        l_hand = m_OvrAvatar.transform.Find("hand_left");
        l_hand.tag = "Hand";

        // Wait instantiate Right Hand
        WaitWhile waitInst_RHand = new WaitWhile(() => { return m_OvrAvatar.transform.Find("hand_right") == null; });
        yield return waitInst_RHand;
        r_hand = m_OvrAvatar.transform.Find("hand_right");
        r_hand.tag = "Hand";
        // Wait instantiate Left Controller
        WaitWhile waitInst_LController = new WaitWhile(() => { return GameObject.Find("controller_left") == null; });
        yield return waitInst_LHand;
        l_controller_mesh = GameObject.Find("controller_left");

        // Wait instantiate Right Controller
        WaitWhile waitInst_RController = new WaitWhile(() => { return GameObject.Find("controller_right") == null; });
        yield return waitInst_LHand;
        r_controller_mesh = GameObject.Find("controller_right");
        
        #endregion
        ready = true;
    }

    void Update()
    {
        if (!ready) return;
        if (showController != curController) {
            m_OvrAvatar.ShowControllers(showController);
            curController = showController;
        }

        if (l_hand != null && l_indexFingerTrans == null) {
            l_indexFingerTrans = l_hand.Find("hand_left_renderPart_0/hands:l_hand_world/hands:b_l_hand/hands:b_l_index1/hands:b_l_index2/hands:b_l_index3/hands:b_l_index_ignore");
            if (l_indexFingerTrans != null)
            {
                GameObject fingerTipObj = Instantiate<GameObject>(new GameObject("l_index_tip"), l_indexFingerTrans);
                l_indexTipCollider = fingerTipObj.AddComponent<SphereCollider>();
                l_indexTipCollider.isTrigger = true;
                l_indexTipCollider.radius = 0.01f;
                l_indexTipCollider.center = new Vector3(0.01f, 0, 0);
                l_indexTipCollider = fingerTipObj.AddComponent<SphereCollider>();
                l_indexTipCollider.isTrigger = false;
                l_indexTipCollider.radius = 0.01f;
                l_indexTipCollider.center = new Vector3(0.01f, 0, 0);
                fingerTipObj.tag = "FingerTip";
                fingerTipObj.layer = LayerMask.NameToLayer("FingerTip");
            }
        }

        if (r_hand != null && r_indexFingerTrans == null)
        {
            r_indexFingerTrans = r_hand.Find("hand_right_renderPart_0/hands:r_hand_world/hands:b_r_hand/hands:b_r_index1/hands:b_r_index2/hands:b_r_index3/hands:b_r_index_ignore");
            if (r_indexFingerTrans != null)
            {
                GameObject fingerTipObj = Instantiate<GameObject>(new GameObject("r_index_tip"), r_indexFingerTrans);
                r_indexTipCollider = fingerTipObj.AddComponent<SphereCollider>();
                r_indexTipCollider.isTrigger = true;
                r_indexTipCollider.radius = 0.01f;
                r_indexTipCollider.center = new Vector3(0.01f, 0, 0);
                r_indexTipCollider = fingerTipObj.AddComponent<SphereCollider>();
                r_indexTipCollider.isTrigger = false;
                r_indexTipCollider.radius = 0.01f;
                r_indexTipCollider.center = new Vector3(0.01f, 0, 0);
                fingerTipObj.tag = "FingerTip";
                fingerTipObj.layer = LayerMask.NameToLayer("FingerTip");
            }
        }
        
        UpdateCapTouchStates();

    }

    private void UpdateCapTouchStates()
    {
        l_isPointing        = !OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, l_controller) &&
                               OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, l_controller);
        l_indexTipCollider.enabled = l_isPointing;

        l_isGivingThumbsUp  = !OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, l_controller) &&
                               OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, l_controller);

        r_isPointing        = !OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, r_controller) &&
                               OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, r_controller);
        r_indexTipCollider.enabled = r_isPointing;

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
    
    public void SetEnabledHands(bool enabled) {
        r_hand.gameObject.SetActive(enabled);
        l_hand.gameObject.SetActive(enabled);
    }

    public OVRInput.Controller GetTouchOVRController(Collider col)
    {
        if (col == l_indexTipCollider)
        {
            return OVRInput.Controller.LTouch;
        }
        if (col == r_indexTipCollider)
        {
            return OVRInput.Controller.RTouch;
        }
        return OVRInput.Controller.None;
    }
}
