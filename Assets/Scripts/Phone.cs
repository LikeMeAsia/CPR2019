using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(OVRGrabbable), typeof(Rigidbody))]
public class Phone : MonoBehaviour
{
    private AudioSource audioSource;
    private OVRGrabbable ovrGrabbable;
    private Rigidbody phone_rigidbody;
    private Collider[] colliders;

    public Animator phoneAnimIcon;
    public GameObject blackScreen;

    public AudioClip phoneButtonClick;

    [Header("Debug")]
    [SerializeField]
    [ReadOnly]
    private bool activate;
    [SerializeField]
    [ReadOnly]
    private bool isOnGround;
    [SerializeField]
    [ReadOnly]
    private bool disableOnGround;
    [SerializeField]
    [ReadOnly]
    private bool isGrabbed;
    [SerializeField]
    [ReadOnly]
    private bool isCalling;
    public bool IsCalling { get { return isCalling; } }
    [SerializeField]
    [ReadOnly]
    private bool activeScreen;

    private void Awake()
    {
        phone_rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        colliders = GetComponentsInChildren<Collider>();
    }

    private void Start()
    {
        activate = false;
        isOnGround = false;
        isCalling = false;
        activeScreen = false;
        isGrabbed = false;
        disableOnGround = false;
        Deactivate();
    }

    private void Update()
    {
        if (disableOnGround && isOnGround)
        {
            if (phone_rigidbody.velocity.magnitude < 0.01)
            {
                phone_rigidbody.isKinematic = true;
                foreach (Collider col in colliders)
                {
                    col.enabled = false;
                }
            }
        }
        if (!activate) {
            return;
        }
        UpdateStatus();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCalling && other.CompareTag("Hand") && !phone_rigidbody.isKinematic)
        {
            activeScreen = true;
        }

        if (other.CompareTag("Hand") && (Player.Instance.l_ful || Player.Instance.r_ful))
        {
            isGrabbed = true;
        }
        
        if (activate && phone_rigidbody.isKinematic && ovrGrabbable != null && ovrGrabbable.grabbedBy != null)
        {
            OVRInput.Controller grabControllerType = ((CustomOVRGrabber)ovrGrabbable.grabbedBy).GetControllerType();
            if (!isCalling && other.CompareTag("FingerTip") && (
                (Player.Instance.l_isPointing && Player.Instance.r_ful && grabControllerType == OVRInput.Controller.RTouch)
                || (Player.Instance.r_isPointing && Player.Instance.l_ful && grabControllerType == OVRInput.Controller.LTouch))
            ) {
                Call();
            }
        }
    }

    public void Call() {
        if (phoneButtonClick != null) {
            audioSource.PlayOneShot(phoneButtonClick);
        }
        isCalling = true;
        blackScreen.SetActive(false);
        phoneAnimIcon.SetBool("showingIcon", false);
    }


    private void OnTriggerExit(Collider other)
    {
        if (!isCalling && other.CompareTag("Hand"))
        {
            activeScreen = false;
            isGrabbed = true;
            Debug.Log("handExitPhone");
        }
    }

    public void Activate() {
        activate = true;
        isCalling = false;
        blackScreen.SetActive(true);
        phoneAnimIcon.SetBool("showingIcon", true);
        phone_rigidbody.isKinematic = !isGrabbed;
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
    }
    public void Deactivate() {
        activate = false;
        disableOnGround = true;
        ovrGrabbable.enabled = false;
        blackScreen.SetActive(false);
        phoneAnimIcon.SetBool("showingIcon", false);
    }
    public void SetActive(bool value) {
        gameObject.SetActive(value);
    }

    private void UpdateStatus()
    {
        if (isCalling) return;

        if (activeScreen == true || isGrabbed == true)
        {
            blackScreen.SetActive(true);
        }
        else if (activeScreen == false)
        {
            blackScreen.SetActive(false);
        }

        if (phone_rigidbody.isKinematic)
        {
            activeScreen = true;
            phoneAnimIcon.SetBool("showingIcon", true);
            phoneAnimIcon.SetInteger("screen", 1);
        }
        else
        {
            activeScreen = true;
            phoneAnimIcon.SetBool("showingIcon", true);
            phoneAnimIcon.SetInteger("screen", 0);
        }
    }
}
