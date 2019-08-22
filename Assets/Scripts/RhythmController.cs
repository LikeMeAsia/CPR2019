using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource), typeof(Collider))]
public class RhythmController : MonoBehaviour
{
    [Header("Music Settings")]
    private AudioSource mainAudioSource;
    public float tempo = 0.6f;
    public float offset = 0.25f;
    public float playbackOffset = 0.45f;

    //startposition
    private float pulseDirector = 0.0f;
    private bool hitOnBar = true;

    [Header("Indicator Settings")]
    public Canvas beatCanvas;
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
    [HideInInspector]
    private bool gamestart = false;
    public bool GameStart { get { return gamestart; } }

    private Collider beatCollider;
    public bool songHasStopped = false;

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
        mainAudioSource = this.GetComponent<AudioSource>();
        beatCollider = this.GetComponent<Collider>();
    }

    void Start()
    {
        //gamestart need some fix. This is just a dummy assigning;
        gamestart = false;
        pulseDirector = 0;
        defaultColor = circle.color;
        ResetScore();
        
    }

    void Update()
    {
        //if (OVRInput.Get(OVRInput.Button.One)) Gamestart = true;

        //if (Input.GetMouseButton(0)) RegisterHit(HIT.perfect);
        //if (Input.GetMouseButton(1)) RegisterHit(HIT.bad);

        if (gamestart == true && mainAudioSource.clip!=null)
        {
            playbackPercent = ((mainAudioSource.time + playbackOffset) % tempo) / tempo;
            RingTransform(playbackPercent);
            Pulse();
            if (enableVibration) { if (canVibrateOnce) Vibrate(); }
            ChangeColorCountdown();
            if (!mainAudioSource.isPlaying)
            {
                Debug.Log("Song stop");
                //gamestart = false;
                StopRhythm();
            }
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
                    
                }
                else if (playbackPercent < 0.8f && playbackPercent > 0.4f)
                {
                    RegisterHit(HIT.good);
                    AudioPlayer.PlayAudioClip(indicatorSound[0], true);
                   
                }
                else
                {
                    RegisterHit(HIT.bad);
                    AudioPlayer.PlayAudioClip(indicatorSound[1], true);
                  
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

    public void Setup(AudioClip clip) {
        mainAudioSource.clip = clip;
    }

    public void StartRhythm() {
        if (mainAudioSource.clip == null) return;
        gamestart = true;
        pulseDirector = 0;
        mainAudioSource.time = 0;
        mainAudioSource.Play();
        SetBeatEnabled(true);
    }

    public void StopRhythm() {
        gamestart = false;
        mainAudioSource.Stop();
        SetBeatEnabled(false);
    }

    void RingTransform(float playbackPercent) //formally ExpandRing
    {
        float temp = (1 - playbackPercent) - offset;
        float percent = Mathf.Clamp(temp, 0.0f, 1.0f);


        float beatRingRadius = innerRing.rectTransform.localScale.x + 1.0f * percent;
        outerRing.rectTransform.localScale = new Vector3(beatRingRadius, beatRingRadius, 1);

        outerRing.color = new Color(outerRing.color.r, outerRing.color.g, outerRing.color.b, 1 - percent);

    }

    private void Pulse()
    {
        if (pulseDirector + offset <= mainAudioSource.time)
        {
            CheckHit();
            pulseDirector += tempo;
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

    public void ResetScore()
    {
        maxCombo = 0;
        combo = 0;
        perfectHit = 0;
        goodHit = 0;
        missHit = 0;
    }

    public void SetBeatEnabled(bool value) {
        beatCollider.enabled = value;
        beatCanvas.gameObject.SetActive(value);
    }

    public void SongIsPlaying()
    {
        if (!mainAudioSource.isPlaying)
        {
            songHasStopped = true;

        }
    }
}
