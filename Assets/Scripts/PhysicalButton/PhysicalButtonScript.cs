using UnityEngine;
using UnityEngine.Events;

public class PhysicalButtonScript : MonoBehaviour, ITriggerListener
{
    public enum PhysicalButtonState { Default, Touch, Pressed, Released}

    public UnityEvent pressedEvent;
    public UnityEvent touchEvent;
    public UnityEvent defualtEvent;

    public bool callEventOnlyOnce;
    [ReadOnly]
    [SerializeField]
    PhysicalButtonState buttonState;
    [ReadOnly]
    [SerializeField]
    bool pressed;

    [ReadOnly]
    [SerializeField]
    bool activated;

    Rigidbody pressRigid;
    HingeJoint pressJoint;

    void Awake()
    {
        pressed = false;
        activated = false;
        if (pressedEvent == null) {
            pressedEvent = new UnityEvent();
        }
        Transform pressChild = this.transform.Find("Base/Press");
        if (pressChild != null)
        {
            pressRigid = pressChild.GetComponent<Rigidbody>();
            pressJoint = pressChild.GetComponent<HingeJoint>();
        }
        Collider collider = pressChild.GetComponent<Collider>();
        if (collider != null)
        {
            TriggerBridge tb = pressChild.gameObject.AddComponent<TriggerBridge>();
            tb.Initialize(this);
        }
    }

    void Start()
    {

    }
    
    void LateUpdate()
    {
        if (pressJoint.currentForce.sqrMagnitude == 0 && !pressed)
        {
            UpdateState(PhysicalButtonState.Default);
            pressRigid.isKinematic = false;
            pressed = false;
            if (!callEventOnlyOnce)
            {
                activated = false;
            }
        }
        if (pressRigid.transform.localPosition.z < 0)
        {
            pressRigid.transform.localPosition = Vector3.zero;
        }
        else if (pressRigid.transform.localPosition.z > pressJoint.connectedAnchor.z)
        {
            pressRigid.transform.localPosition = new Vector3(0, 0, pressJoint.connectedAnchor.z);
        }
    }

    void ITriggerListener.OnTriggerEnter(Collider collider)
    {
        if (!activated) {
            UpdateState(PhysicalButtonState.Touch);
        }
        pressRigid.isKinematic = false;
    }

    void ITriggerListener.OnTriggerStay(Collider collider)
    {
        if (pressRigid.transform.localPosition.z <= 0 && buttonState != PhysicalButtonState.Released)
        {
            UpdateState(PhysicalButtonState.Pressed);
            pressed = true;
            pressRigid.isKinematic = true;
        }
        else if (pressRigid.transform.localPosition.z >= pressJoint.connectedAnchor.z)
        {
            pressRigid.isKinematic = true;
        }
        else {
            if (!activated)
            {
                UpdateState(PhysicalButtonState.Touch);
            }
            pressRigid.isKinematic = false;
            pressed = false;
        }
    }

    void ITriggerListener.OnTriggerExit(Collider collider)
    {
        UpdateState(PhysicalButtonState.Released);
        pressRigid.isKinematic = false;
    }

    private void UpdateState(PhysicalButtonState updatedState) {
        buttonState = updatedState;
        switch (updatedState) {
            case PhysicalButtonState.Touch:
                OVRInput.SetControllerVibration(1f, 0.5f, OVRInput.Controller.RTouch);
                touchEvent.Invoke();
                break;
            case PhysicalButtonState.Pressed:
                if (!activated)
                {
                    OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                    activated = true;
                    pressedEvent.Invoke();
                }
                break;
            case PhysicalButtonState.Released:
                OVRInput.SetControllerVibration(0.5f, 0.2f, OVRInput.Controller.RTouch);
                break;
            default:
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
                defualtEvent.Invoke();
                break;
        }
    }

    public void OnDisable()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
