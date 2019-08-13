using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource), typeof(OVRGrabbable))]
public class Calling : MonoBehaviour
{
    [System.Serializable]
    public struct Conversations {
        public AudioClip[] conversations;
    }

    public GameObject fatherShoulder;

    public GameObject phone;
    public GameObject black_screen;
    
    [SerializeField]
    public Conversations firstCall;
    [SerializeField]
    public Conversations fatherNotResponse;
    [SerializeField]
    public Conversations teachCpr;
    [SerializeField]
    public Conversations readyToCpr;

    public AudioClip phoneButtonClick;
    public AudioClip rUReady;
    public AudioClip oneTwoSound;
    public GameObject Lay_Phone_warning;
    public Text layPhoneText;
    public Rigidbody phone_rigidbody;
    public Animator phoneAnimIcon;

    public Image placeableArea;

    public float audio_time;
    public bool isCalling;
    public bool phone_Activate;
    public bool Icon_show;
    public bool warrning_icon;
    public bool Conv_2_check;
    public int Calling_count;
    public bool placeable;
    public bool snapItem;
    public bool rUReadyEnd;
    public bool cutScene1Ended;
    public bool isOnGround;
    public bool disableOnGround;

    public Collider[] colliders;
    private AudioSource audioSource;
    private OVRGrabbable ovrGrabbable;

    private void Awake()
    {
        phone_rigidbody = GetComponentInChildren<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        colliders = GetComponentsInChildren<Collider>();
    }

    private void Start()
    {
        //phoneAnimIcon.SetBool("showingIcon", false);
        Lay_Phone_warning.SetActive(false);
        rUReadyEnd = false;
        Intilize();
        placeable = false;
        phone_rigidbody.isKinematic = true;
        placeableArea.gameObject.SetActive(false);
        fatherShoulder.SetActive(false);
        cutScene1Ended = false;
        isOnGround = false;
    }
    void Update()
    {
        if (cutScene1Ended)
        {
            Activate_check();
            if (CPRHand.Instance.snaping && rUReadyEnd)
            {
                rUReadyEnd = false;
                PlayReadyToCprVoices();
            }
        }
        if (disableOnGround && ovrGrabbable.enabled && isOnGround)
        {
            if (phone_rigidbody.velocity.magnitude < 0.01)
            {
                ovrGrabbable.enabled = false;
                phone_rigidbody.isKinematic = true;
                foreach (Collider col in colliders)
                {
                    col.enabled = false;
                }
            }
        }
    }

    

    public void Intilize()
    {
        isCalling = false;
        phone_Activate = false;
        Icon_show = true;
        snapItem = false;
        audio_time = 2.0f;
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
            phone_Activate = true;
        }

        if (other.CompareTag("Hand") && (Player.Instance.l_ful || Player.Instance.r_ful))
        {
            snapItem = true;
        }

        if(phone_rigidbody.isKinematic && ovrGrabbable != null && ovrGrabbable.grabbedBy != null)
            {
            OVRInput.Controller grabControllerType = ((CustomOVRGrabber)ovrGrabbable.grabbedBy).GetControllerType();
            if (!isCalling && other.CompareTag("FingerTip") && (
                (Player.Instance.l_isPointing && Player.Instance.r_ful && grabControllerType == OVRInput.Controller.RTouch) 
                || (Player.Instance.r_isPointing && Player.Instance.l_ful && grabControllerType == OVRInput.Controller.LTouch))
            ) {
                phoneAnimIcon.SetBool("showingIcon", false);
                StartCall();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Phone_area") && phone_rigidbody.isKinematic)
        {
            placeable = true;
            placeableArea.color = Color.red;
        }
        if (placeable && other.gameObject.CompareTag("Phone_area") && !phone_rigidbody.isKinematic)
        {
            placeableArea.gameObject.SetActive(false);
            fatherShoulder.SetActive(true);
            warrning_icon = false;
            other.gameObject.SetActive(false);
            //ScenarioControl.Instance.sitCanvas.GetComponent<Animator>().SetBool("disable", true);
            //ScenarioControl.Instance.shoulderCanvas.SetActive(true);
            layPhoneText.text = "ตบไหล่พ่อ 2 ครั้ง";
            disableOnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isCalling && other.CompareTag("Hand") )
        {
            phone_Activate = false;
            snapItem = true;
            Debug.Log("handExitPhone");
        }
        if (other.gameObject.CompareTag("Phone_area"))
        {
            placeable = false;
            placeableArea.color = Color.white;
        }
    }

    public void EndCutScene1()
    {
        cutScene1Ended = true;
        phoneAnimIcon.SetBool("showingIcon", true);
        phoneAnimIcon.SetInteger("screen", 0);
        Debug.Log("End1");
    }
  

    public void StartCall()
    {
        if (!isCalling)
        {
            isCalling = true;
            audioSource.PlayOneShot(phoneButtonClick);
            StartCoroutine(IConversationPlay(firstCall, delegate {
                Calling_count++;
                //Put_calling_button.SetActive(false);
                Icon_show = false;
                //ScenarioControl.Instance.sitCanvas.SetActive(true);
                Lay_Phone_warning.SetActive(true);
                placeableArea.gameObject.SetActive(true);
            }));
        }
    }

    public void StartTeachCprCall()
    {
        /*if (ShakeShoulder.shaking)
        {
            StartCoroutine(IConversationPlay(fatherNotResponse, delegate
            {
                //ScenarioControl.Instance.cprCanvas.SetActive(true);
                Player.Instance.cprHand.enabledSnap = true;
                TeachSanpingHandCprCall();
            }));
        }*/
    }

    public void TeachSanpingHandCprCall()
    {
        /*if (ShakeShoulder.shaking)
        {
            StartCoroutine(IConversationPlay(teachCpr, delegate
            {
                rUReadyEnd = true;
            }));
        }*/
    }

    public void PlayReadyToCprVoices()
    {
        StartCoroutine(IConversationPlay(readyToCpr, delegate
        {
            StartCoroutine(ILoopCountCPR());
        }));
    }

    IEnumerator ILoopCountCPR() {
        audioSource.Stop();
        audioSource.clip = oneTwoSound;
        audioSource.loop = true;
        audioSource.Play();
        BeatController.Instance.EnableBeatTutorial();
        WaitWhile endTutorial = new WaitWhile(()=> { return BeatController.Instance.tutorialBump; });
        yield return endTutorial;
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = null;
    }

    IEnumerator IConversationPlay(Conversations conversationSet, UnityAction actionAfterPlay) {
        yield return new WaitForSeconds(phoneButtonClick.length);
        if (conversationSet.conversations != null) {
            foreach (AudioClip clip in conversationSet.conversations)
            {
                if (clip == null) continue;
                audioSource.PlayOneShot(clip);
                yield return new WaitForSeconds(clip.length);
            }
        }
        if(actionAfterPlay!=null)
            actionAfterPlay.Invoke();
    }

    public void Activate_check()
    {
        if (isCalling) return;

        if (phone_Activate == true || snapItem == true)
        {
            black_screen.SetActive(false);
        }
        else if (phone_Activate == false)
        {
            black_screen.SetActive(true);
        }

        if (phone_rigidbody.isKinematic)
        {
            phone_Activate = true;
            phoneAnimIcon.SetBool("showingIcon", true);
            phoneAnimIcon.SetInteger("screen", 1);
        }
        else
        {
            phone_Activate = true;
            phoneAnimIcon.SetBool("showingIcon", true);
            phoneAnimIcon.SetInteger("screen", 0);
        }
    }
}
