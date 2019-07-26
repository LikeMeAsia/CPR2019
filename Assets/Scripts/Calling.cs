using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Calling : MonoBehaviour
{
    [System.Serializable]
    public struct Conversations {
        public AudioClip[] conversations;
    }

    public BeatController beatController;

    public GameObject fatherShoulder;

    public GameObject phone;
    public GameObject black_screen;
    [SerializeField]
    public Conversations firstCall;
    [SerializeField]
    public Conversations fatherNotResponse;
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

    private AudioSource audioSource;

    void Start()
    {
        phoneAnimIcon.SetBool("showingIcon", false);
        Lay_Phone_warning.SetActive(false);
        rUReadyEnd = false;
        Intilize();
        phone_rigidbody = GetComponentInChildren<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        placeable = false;
        placeableArea.gameObject.SetActive(false);
        fatherShoulder.SetActive(false);
    }
    void Update()
    {
        Activate_check();
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("false");
            phoneAnimIcon.SetBool("showingIcon", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("true");
            phoneAnimIcon.SetBool("showingIcon", true);
        }
        
        if (CPRHand.Instance.snaping && rUReadyEnd)
        {
            rUReadyEnd = false;
            PlayReadyToCprVoices();
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


        if (!isCalling && other.CompareTag("FingerTip")  && (Player.Instance.l_isPointing || Player.Instance.r_isPointing))
        {
            phoneAnimIcon.SetBool("showingIcon", false);
            StartCall();
        }
        if (other.gameObject.CompareTag("Phone_area") && phone_rigidbody.isKinematic)
        {
            placeable = true;
            placeableArea.color = Color.red;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (placeable && other.gameObject.CompareTag("Phone_area") &&  !phone_rigidbody.isKinematic)
        {
            placeableArea.gameObject.SetActive(false);
            fatherShoulder.SetActive(true);
            warrning_icon = false;
            other.gameObject.SetActive(false);
            layPhoneText.text = "สะกิดไหล่พ่อ 2 ครั้ง";
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
        phoneAnimIcon.SetBool("showingIcon", true);
        phoneAnimIcon.SetInteger("screen", 0);
        Debug.Log("End1");
    }
    IEnumerator IShowIconAnimDelay()
    {
        phoneAnimIcon.SetBool("showingIcon", false);
        yield return new WaitForSeconds(1.0f);
        phoneAnimIcon.SetBool("showingIcon", true);
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
                Lay_Phone_warning.SetActive(true);
                placeableArea.gameObject.SetActive(true);
            }));
        }
    }

    public void StartTeachCprCall()
    {
        if (ShakeShoulder.shakeEnd)
        {
            StartCoroutine(IConversationPlay(fatherNotResponse, delegate
            {
                ScenarioControl.Instance.cprCanvas.SetActive(true);
                Player.Instance.cprHand.enabledSnap = true;
                audioSource.PlayOneShot(rUReady);
                StartCoroutine(IWaitForReady());
            }));
        }
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
        beatController.EnableBeatTutorial();
        WaitWhile endTutorial = new WaitWhile(()=> { return beatController.tutorialBump; });
        yield return endTutorial;
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = null;
    }


    IEnumerator IWaitForReady()
    {
        Debug.Log("Call IWaitForReady()");
        if (rUReadyEnd) yield break;
        yield return new WaitForSeconds(rUReady.length);
        rUReadyEnd = true;
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
