using com.dgn.XR.Extensions;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[DisallowMultipleComponent]
public class Player : Singleton<Player>
{
    protected override void Awake() {
        base.Awake();
        ready = false;
    }

    [Header("Left hand")]
    public HandPresence l_hand;
    public XRDirectInteractor l_interactor;
    public SphereCollider l_index;
    public XRInteractorLineVisual l_LineVisual;
    private Gradient l_invalidColor;
    public HandPresence.HandState LeftHandState { get { return l_hand ? l_hand.CurrentState : HandPresence.HandState.Undefined; } }

    [Header("Right hand")]
    public HandPresence r_hand;
    public XRDirectInteractor r_interactor;
    public SphereCollider r_index;
    public XRInteractorLineVisual r_LineVisual;
    private Gradient r_invalidColor;
    public HandPresence.HandState RightHandState { get { return r_hand? r_hand.CurrentState: HandPresence.HandState.Undefined; } }

    [Header("CPR Hands")]
    public CPRHand cprHand;

    [Header(" ")]
    public bool showController;
    private bool curController;
    
    private TeleportationProvider teleporter;

    public Gradient transparentGradient;

    // Check initial all required parameters
    public bool ready = false;

    void Start()
    {
        curController = showController;
        teleporter = this.GetComponentInChildren<TeleportationProvider>();
        l_invalidColor = l_LineVisual.invalidColorGradient;
        l_LineVisual.invalidColorGradient = transparentGradient;
        r_invalidColor = r_LineVisual.invalidColorGradient;
        r_LineVisual.invalidColorGradient = transparentGradient;
        ready = true;
    }

    void Update()
    {
        if (!ready) return;

        if (showController != curController) {
            r_hand.showController = showController;
            r_hand.showHand = !showController;
            l_hand.showController = showController;
            l_hand.showHand = !showController;
            curController = showController;
        }
        if (l_index) {
            l_index.enabled = l_hand.CurrentState == HandPresence.HandState.Pointing;
            l_LineVisual.invalidColorGradient = l_index.enabled ? l_invalidColor : transparentGradient;
        }
        if (r_index) {
            r_index.enabled = r_hand.CurrentState == HandPresence.HandState.Pointing;
            r_LineVisual.invalidColorGradient = r_index.enabled ? r_invalidColor : transparentGradient;
        }
    }
    
    private bool CreateFingerTip(Transform indexFingerTrans, out SphereCollider indexTipCollider) {
        indexTipCollider = null;
        if (indexFingerTrans != null)
        {
            GameObject fingerTipObj = Instantiate<GameObject>(new GameObject("index_tip"), indexFingerTrans);
            fingerTipObj.tag = "FingerTip";
            fingerTipObj.layer = LayerMask.NameToLayer("FingerTip");
            indexTipCollider = fingerTipObj.AddComponent<SphereCollider>();
            indexTipCollider.isTrigger = true;
            indexTipCollider.radius = 0.01f;
            indexTipCollider.center = new Vector3(0.01f, 0, 0);
            return true;
        }
        return false;
    }
    
    public void SetEnabledHands(bool enabled) {
        r_hand.gameObject.SetActive(enabled);
        l_hand.gameObject.SetActive(enabled);
    }

    public XRNode GetXRController(Collider col)
    {
        if (col == l_index)
        {
            return XRNode.LeftHand;
        }
        if (col == r_index)
        {
            return XRNode.RightHand;
        }
        return XRNode.GameController;
    }
    
    public bool Teleport(Transform targetPosition) {
        if (teleporter) {
            TeleportRequest teleportRequest = new TeleportRequest
            {
                destinationPosition = targetPosition.position,
                destinationRotation = targetPosition.rotation
            };
            return teleporter.QueueTeleportRequest(teleportRequest);
        }
        return false;
    }
}
