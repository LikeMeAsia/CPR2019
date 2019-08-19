using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RhythmController : MonoBehaviour
{
    [Header("Music Settings")]
    public AudioSource mainAudioSource;
    public float tempo = 0.6f;
    public float offset = 0.25f;
    public float playbackOffset = 0.45f;


    [Header("Indicator Settings")]
    public Image outerRing;
    public Image circle;
    public Image innerRing;
    public bool invertColor = false;
    private Color defaultColor;
    public Color goodColor;
    public Color badColor;
    public float changeColorTime = 0.3f;

    [Header("Indicator Properties")]
    public AudioClip[] indicatorSound = null;
    private bool enableVibration = true;
    public float vibrateTime = 0.1f;
    private float vibrateTimer = 0.0f;
    private bool canVibrateOnce = false;

    private float playbackPercent = 0.0f;
    [HideInInspector] public bool Gamestart = false;
    private Collider beatCollider;

    [Header ("Combo Popup")]
    public GameObject perfectPopup;
    public GameObject goodPopup;
    public GameObject missPopup;
    public float timeleft;

    #region EventSystem
    [Header("Scoring Event System")]
    public UnityEvent perfectEvent;
    public UnityEvent goodEvent;
    public UnityEvent badEvent;
    #endregion

    //TODO Reimplement Scoring System
    //suggest using percent based instead of pure score based(?)
    #region ScoringSystem
    [HideInInspector] public uint maxCombo     = 0;
    [HideInInspector] public uint combo        = 0;
    [HideInInspector] public uint perfectHit   = 0;
    [HideInInspector] public uint goodHit      = 0;
    [HideInInspector] public uint missHit      = 0;
    #endregion

    enum HIT { perfect, good, bad }

    private void Awake()
    {
        if (perfectEvent == null) perfectEvent = new UnityEvent();
        if (goodEvent == null) goodEvent = new UnityEvent();
        if (badEvent == null) badEvent = new UnityEvent();
    }

    void Start()
    {
        //gamestart need some fix. This is just a dummy assigning;
        Gamestart = true;

        beatCollider = this.GetComponent<Collider>();
        defaultColor = circle.color;

        resetScore();
    }

    void Update()
    {
        //if (OVRInput.Get(OVRInput.Button.One)) Gamestart = true;

        //if (Input.GetMouseButton(0)) RegisterHit(HIT.perfect);
        //if (Input.GetMouseButton(1)) RegisterHit(HIT.bad);

        if (Gamestart == true)
        {
            playbackPercent = ((mainAudioSource.time + playbackOffset) % tempo) / tempo;
            RingTransform(playbackPercent);
            Pulse();
            if (enableVibration) { if (canVibrateOnce) Vibrate(); }
            ChangeColorCountdown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand Checker"))
        {
            Debug.Log("hit : " + mainAudioSource.time);

            if (hitOnBar)
            {
                canVibrateOnce = true;
                if (playbackPercent > 0.8f)
                {
                    RegisterHit(HIT.perfect);
                    AudioPlayer.PlayAudioClip(indicatorSound[0], true);
                    perfectPopup.SetActive(true);
                    ClearComboPopup(); //clear popup couroutine 0.5sec
                }
                else if (playbackPercent < 0.8f && playbackPercent > 0.4f)
                {
                    RegisterHit(HIT.good);
                    AudioPlayer.PlayAudioClip(indicatorSound[0], true);
                    goodPopup.SetActive(true);
                    ClearComboPopup(); //clear popup couroutine 0.5sec
                }
                else
                {
                    RegisterHit(HIT.bad);
                    AudioPlayer.PlayAudioClip(indicatorSound[1], true);
                    missPopup.SetActive(true);
                    ClearComboPopup(); //clear popup couroutine 0.5sec
                }
                hitOnBar = false;
            }
            else
            {
                    RegisterHit(HIT.bad);
                    AudioPlayer.PlayAudioClip(indicatorSound[1], true);
            }
        }
    }

    private void ClearComboPopup()
    {
        Debug.Log("Enter clearpopup");
        timeleft -= Time.deltaTime;
        if (timeleft<=0)
        {
            Debug.Log("inside");
            goodPopup.SetActive(false);
            missPopup.SetActive(false);
            perfectPopup.SetActive(false);
            timeleft = 3;
        }
    }

    void RingTransform(float playbackPercent) //formally ExpandRing
    {
        float temp = (1 - playbackPercent) - offset;
        float percent = Mathf.Clamp(temp, 0.0f, 1.0f);


        float beatRingRadius = innerRing.rectTransform.localScale.x + 1.0f * percent;
        outerRing.rectTransform.localScale = new Vector3(beatRingRadius, beatRingRadius, 1);

        outerRing.color = new Color(outerRing.color.r, outerRing.color.g, outerRing.color.b, 1 - percent);

    }

    //startposition
    private float pulseDirector = 0.0f;
    private bool hitOnBar = true;
    private void Pulse()
    {
        if (pulseDirector + offset <= mainAudioSource.time)
        {
            CheckHit();
            pulseDirector += tempo;
            if (pulseDirector >= mainAudioSource.clip.length) pulseDirector = 0.055f;
        }
    }

    private void CheckHit()
    {
        if (hitOnBar)
        {
            RegisterHit(HIT.bad);
        }
        else
        {
            hitOnBar = true;
        }
    }

    private void Vibrate()
    {
        if (vibrateTimer <= vibrateTime)
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
            vibrateTimer += Time.deltaTime;
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            vibrateTimer = 0.0f;
            canVibrateOnce = false;
        }
    }

    private void RegisterHit(HIT hit)
    {
        Debug.Log("On hit case [" + hit + "] at : " + mainAudioSource.time);
        switch (hit)
        {
            case HIT.perfect:
                ChangeColor(goodColor, true);
                perfectHit++;
                Combo(true);
                perfectEvent.Invoke();
                break;
            case HIT.good:
                ChangeColor(goodColor, true);
                goodHit++;
                Combo(true);
                goodEvent.Invoke();
                break;
            case HIT.bad:
                ChangeColor(badColor, true);
                missHit++;
                Combo(false);
                badEvent.Invoke();
                break;
            default:
                Debug.Log("THIS SHOULDN'T HAPPEN");
                break;
        }
    }

    private void Combo(bool good)
    {
        if (good)
        {
            combo++;
            if (combo > maxCombo) maxCombo = combo;
        }
        else
        {
            combo = 0;
        }
    }

    private float changeColorTimer = 0.0f;
    private void ChangeColorCountdown()
    {
        if (changeColorTimer > 0)
        {
            changeColorTimer -= Time.deltaTime;
        }
        else
        {
            ChangeColor(defaultColor);
        }
    }

    private void ChangeColor(Color color, bool isTriggerTimer = false)
    {
        circle.color = color;
        if (isTriggerTimer) changeColorTimer = changeColorTime;
    }

    public void resetScore()
    {
        maxCombo = 0;
        combo = 0;
        perfectHit = 0;
        goodHit = 0;
        missHit = 0;
    }
}
