using com.dgn.UnityAttributes;
using com.dgn.XR.Extensions;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnim;
    [SerializeField]
    private Animator doorUIAnim;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip doorOpenSound;
    [SerializeField]
    private AudioClip doorCloseSound;
    [SerializeField]
    private XRGrabInteractable doorHandle;
    [SerializeField]
    private HingeJoint doorHandleJoint;
    public float doorOpenDelay;

    [SerializeField]
    [ReadOnly]
    [ModifiableProperty]
    private bool doorOpen;
    public bool DoorOpen { get { return doorOpen; } }

    [Header("Grabbed Hands")]
    [SerializeField]
    private Transform handPivot;
    [SerializeField]
    private GameObject r_grab;
    [SerializeField]
    private GameObject l_grab;

    
    private void Awake()
    {
        doorOpen = false;
        if(doorUIAnim) doorUIAnim.gameObject.SetActive(false);
        if(r_grab) r_grab.SetActive(false);
        if(l_grab) l_grab.SetActive(false);
    }

    private void Update()
    {
        if (!doorOpen && doorHandleJoint && Mathf.Abs(doorHandleJoint.angle) > 70f) {
            OpenDoor();
        }
    }
    
    public void ShowUI() {
        doorUIAnim?.gameObject.SetActive(true);
        doorUIAnim?.SetBool("disable", false);
    }

    public void HideUI()
    {
        doorUIAnim?.SetBool("disable", true);
    }

    public void OpenDoor() {
        if (doorOpen) return;
        ForceReleaseHandle();
        HideUI();
        doorAnim?.SetBool("open", true);
        if (doorOpenSound) audioSource?.PlayOneShot(doorOpenSound);
        doorOpen = true;
    }

    public void CloseDoor()
    {
        if (!doorOpen) return;
        doorAnim?.SetBool("open", false);
        if(doorCloseSound) audioSource?.PlayOneShot(doorCloseSound);
        doorOpen = false;
    }
    
    private void ForceReleaseHandle()
    {
        if (doorHandle && doorHandle.interactionManager && doorHandle.selectingInteractor)
        {
            doorHandle.interactionManager.ForceRelease(doorHandle.selectingInteractor, doorHandle);
        }
    }

    private void OnGrabbed(XRBaseInteractor rBaseInteractor) {
        HandPresence rHandPresence = rBaseInteractor.GetComponentInChildren<HandPresence>();
        if (!rHandPresence)
        {
            rHandPresence = rBaseInteractor.attachTransform.GetComponentInChildren<HandPresence>();
        }
        if (rHandPresence) {
            if (rHandPresence.controllerCharacteristics.HasFlag(InputDeviceCharacteristics.Right) && r_grab) r_grab.SetActive(true);
            if (rHandPresence.controllerCharacteristics.HasFlag(InputDeviceCharacteristics.Left) && l_grab) l_grab.SetActive(true);
        }
    }

    private void OnReleased(XRBaseInteractor rBaseInteractor) {
        if (r_grab) r_grab.SetActive(false);
        if (l_grab) l_grab.SetActive(false);
    }
    

    private void OnEnable()
    {
        if (doorHandle) {
            doorHandle.onSelectEntered.AddListener(OnGrabbed);
            doorHandle.onSelectExited.AddListener(OnReleased);
        }
    }

    private void OnDisable()
    {
        if (doorHandle)
        {
            doorHandle.onSelectEntered.RemoveListener(OnGrabbed);
            doorHandle.onSelectExited.RemoveListener(OnReleased);
        }
    }
}
