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

    public GameObject phone;
    public GameObject Black_screen;
    public GameObject calling_screen;
    [SerializeField]
    public Conversations firstCall;
    [SerializeField]
    public Conversations fatherNotResponse;
    [SerializeField]
    public Conversations readyToCpr;

    public AudioClip phoneButtonClick;
    public AudioClip rUReady;
    public AudioClip oneTwoSound;
    public GameObject Phone_Activate_Icon;
    public GameObject Put_calling_button;
    public GameObject Lay_Phone_warning;
    public Text layPhoneText;
    public Rigidbody Phone_rigidbody;

    public Image placeableArea;

    public float audio_time;
    public bool Call;
    public bool Phone_Calling;
    public bool Phone_Activate;
    public bool Icon_show;
    public bool warrning_icon;
    public bool Conv_2_check;
    public int Calling_count;
    public bool placeable;
    public bool sanpItem;
    public bool rUReadyEnd;

    private AudioSource audioSource;

    void Start()
    {
        Lay_Phone_warning.SetActive(false);
        rUReadyEnd = false;
        Intilize();
        Phone_rigidbody = GetComponentInChildren<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        placeable = false;
        placeableArea.gameObject.SetActive(false);
    }
    void Update()
    {
        Activate_check();
        Icon_check();
        if (CPRHand.Instance.snaping && rUReadyEnd)
        {
            rUReadyEnd = false;
            PlayReadyToCprVoices();
        }
    }

    public void Intilize()
    {
        Phone_Calling = false;
        Call = false;
        Phone_Activate = false;
        Icon_show = true;
        Put_calling_button.SetActive(false);
        sanpItem = false;

        audio_time = 2.0f;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand")  /*&& (player.l_ful || player.r_ful)*/)
        {
            Phone_Activate = true;
        }

        if (other.CompareTag("Hand") && (Player.Instance.l_ful || Player.Instance.r_ful))
        {
            sanpItem = true;
        }


        if (other.CompareTag("FingerTip")  && (Player.Instance.l_isPointing || Player.Instance.r_isPointing))
        {
            Call = true;
            if (!Phone_Calling) {
                StartCall();
            }

        }
        if (other.gameObject.CompareTag("Phone_area") && Phone_rigidbody.isKinematic)
        {
            placeable = true;
            placeableArea.color = Color.red;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (placeable && other.gameObject.CompareTag("Phone_area") &&  !Phone_rigidbody.isKinematic)
        {
            placeableArea.gameObject.SetActive(false);
            warrning_icon = false;
            other.gameObject.SetActive(false);
            layPhoneText.text = "สะกิดใหล่พ่อ 2 ครั้ง";
            // this.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hand") )
        {
            Phone_Activate = false;
            sanpItem = true;
        }


        if (other.gameObject.CompareTag("Phone_area"))
        {
            placeable = false;
            placeableArea.color = Color.white;
        }
    }


    public void StartCall()
    {
        if (!Phone_Calling)
        {
            Phone_Calling = true;
            calling_screen.SetActive(true);
            audioSource.PlayOneShot(phoneButtonClick);
            StartCoroutine(IConversationPlay(firstCall, delegate {
                Calling_count++;
                Put_calling_button.SetActive(false);
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
        if (Phone_Activate == true || sanpItem == true)
        {
            Black_screen.SetActive(false);
            Phone_Activate_Icon.SetActive(false);
            calling_screen.SetActive(true);

        }
        else if (Phone_Activate == false && Call == false)
        {
            Black_screen.SetActive(true);
            Phone_Activate_Icon.SetActive(true);
            calling_screen.SetActive(false);
        }

    }

    public void Icon_check()
    {
        if (Phone_Activate == true && Icon_show == true)
        {
            Put_calling_button.SetActive(true);
        }


    }

    public void Timescale()
    {
       /* if (Seq1_Conversation4.time == Seq1_Conversation4.clip.length && warrning_icon == true)
        {
            Lay_Phone_warning.SetActive(true);
        }
        else if (warrning_icon == false)
            Lay_Phone_warning.SetActive(false);
        */

    }


}
