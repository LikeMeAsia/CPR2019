using com.dgn.UnityAttributes;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource), typeof(XRGrabInteractable), typeof(Rigidbody))]
public class Phone : MonoBehaviour
{
    private AudioSource audioSource;
    private XRGrabInteractable grabbable;
    private Rigidbody phone_rigidbody;
    private Collider[] colliders;

    public Animator phoneAnimIcon;
    public GameObject blackScreen;
    public GameObject callButton;

    public AudioClip phoneButtonClick;

    [Header("Debug")]
    [SerializeField]
    [ReadOnly]
    private bool activate;
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
        grabbable = GetComponent<XRGrabInteractable>();
        colliders = GetComponentsInChildren<Collider>();
    }

    private void Start()
    {
        activate = false;
        isCalling = false;
        activeScreen = false;
        blackScreen.SetActive(false);
        callButton.SetActive(false);
        phoneAnimIcon.SetBool("showingIcon", false);
    }

    private void Update()
    {
        if (!activate) {
            return;
        }
        UpdateStatus();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!isCalling && other.CompareTag("PlayerHand") && !phone_rigidbody.isKinematic)
        {
            activeScreen = true;
        }
    }

    public void Call() {
        if (isCalling) return;
        
        if (phoneButtonClick != null) {
            audioSource.PlayOneShot(phoneButtonClick);
        }
        isCalling = true;
        blackScreen.SetActive(false);
        callButton.SetActive(false);
        phoneAnimIcon.SetBool("showingIcon", false);
    }


    private void OnTriggerExit(Collider other)
    {
        if (!isCalling && other.CompareTag("PlayerHand"))
        {
            activeScreen = false;
            Debug.Log("handExitPhone");
        }
    }

    public void Activate() {
        activate = true;
        isCalling = false;
        blackScreen.SetActive(true);
        phoneAnimIcon.SetBool("showingIcon", true);
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
    }
    public void Deactivate() {
        activate = false;
        grabbable.enabled = false;
        blackScreen.SetActive(false);
        phoneAnimIcon.SetBool("showingIcon", false);
    }
    public void SetActive(bool value) {
        gameObject.SetActive(value);
    }

    private void UpdateStatus()
    {
        if (isCalling) return;
        
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

        if (activeScreen == true)
        {
            blackScreen.SetActive(false);
        }
        else if (activeScreen == false)
        {
            blackScreen.SetActive(true);
        }

        if (grabbable.selectingInteractor && grabbable.selectingInteractor.tag == "PlayerHand")
        {
            callButton.SetActive(true);
            blackScreen.SetActive(false);
        }
        else {
            callButton.SetActive(false);
        }
    }
}
