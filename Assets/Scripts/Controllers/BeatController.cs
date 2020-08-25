using com.dgn.UnityAttributes;
using com.dgn.XR.Extensions;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;

[RequireComponent(typeof(Collider))]
public class BeatController : MonoBehaviour
{
    public GameObject HpBarDad;
    public GameObject TimeAndScore;
    public GameObject Ghost;
    public GameObject reaperLoopAnimPos;
    public GameObject reaperLoopPos;

    public SkinnedMeshRenderer fatherRend;
    public Material defaultFatherMat;
    public Material transparentFatherMat;

    public RectTransform soulPosX;
    public Animator reaperAnim;

    public GameObject beatCanvas;

    public bool Gamestart;
    public Image beatRing;
    public Image circle;
    public Image circleRing;
    Color defaultColor;
    public Color goodColor;
    public Color badColor;/*= new Color(0,255,0)*/
    public float beatRadius;
    public float bpm; // bpm
    float beatTime;
    float beatTimer;

    public float startExpand;
    public float endExpand;
    public float fadeRadius;
    public float hit;
    public float errCorrectionHit;
    float deltaExpend;

    public float startAlpha;
    public float endAlpha;
    float deltaAlpha;

    public Text scoreText;
    public Text totalScoreText;
    public Text comboText;
    public Text perfectHitText;
    public Text goodHitText;
    public Text missText;

    public GameObject boardWin;
    public GameObject boardLose;

    public float alphaLevel;
    public int curScore;
    public int scorePerHit = 10;
    public int scorePerPerfectHit = 30;

    [Header("Tutorial Bump")]
    public bool tutorialBump;
    public float countDownBump;
    [SerializeField]
    [ReadOnly]
    private float hitBump;

    public static float timeCount;

    public float countDownStart;
    int CountDownStart;
    public Text countDownStartText;
    public GameObject sceneCountStart;

    int comboHit;
    int highCombo;
    int perfectHit;
    int goodHit;
    int missHit;

    public bool hpDadGamePlay;
    public Text hpdadText;
    public float curhpDad = 0;
    public float maxHp;

    public Image hpBar;
    private float hpBarValue;

    public GameObject perfectPopUp;
    public GameObject goodPopUp;
    public GameObject missPopUp;

    bool perfect;
    bool good;
    bool miss;

    public float delayTimerBump;
    public float delayTime;

    private Collider beatCollider;

    public AudioSource songLight;
    public AudioClip[] audioClips = null;

    public Sprite rankA;
    public Sprite rankB;
    public Sprite rankC;

    public Image rankImg;

    private static BeatController instance;
    public static BeatController Instance { get { return instance; } }

    public UnityEvent perfectEvent;
    public UnityEvent goodEvent;
    public UnityEvent badEvent;

    public Text debugger;

    private void Awake()
    {
        instance = this;
        tutorialBump = false;
        if (perfectEvent == null) {
            perfectEvent = new UnityEvent();
        }
        if (goodEvent == null)
        {
            goodEvent = new UnityEvent();
        }
        if (badEvent == null)
        {
            badEvent = new UnityEvent();
        }
    }
    //TODO
    //1.hit scoring
    void Start()
    {
        beatCollider = this.GetComponent<Collider>();
        alphaLevel = 1f;
        alphaLevel = startAlpha;
        deltaAlpha = (endAlpha - startAlpha);
        curScore = 0;
        beatRadius = startExpand;
        beatRing.rectTransform.localScale = new Vector3(beatRadius, beatRadius, beatRadius);
        beatRing.color = new Color(beatRing.color.r, beatRing.color.g, beatRing.color.b, alphaLevel);
        deltaExpend = (endExpand - startExpand);
        if (bpm == 0) bpm = 1;
        beatTime = 60f / bpm;

        beatTimer = 0;
        defaultColor = circle.color;

        //scoreText.text = ""+ curScore;
        hitBump = 0;
        highCombo = 0;
        comboHit = 0;
        perfectHit = 0;
        goodHit = 0;
        missHit = 0;

        hpDadGamePlay = false;
        maxHp = 120;
        curhpDad = maxHp / 2;

        countDownStart = 3;

        perfect = false;
        good = false;
        miss = false;

        delayTimerBump = 0f;
        delayTime = 0.2f;

        boardWin.SetActive(false);
        boardLose.SetActive(false);
        
    }

    void FadeColor()
    {
        if (beatRadius <= fadeRadius)
        {
            alphaLevel = 0;
            beatRing.color = new Color(beatRing.color.r, beatRing.color.g, beatRing.color.b, alphaLevel);
        }
        else
        {
            alphaLevel = 100;
            beatRing.color = new Color(beatRing.color.r, beatRing.color.g, beatRing.color.b, alphaLevel);
        }
    }

    public float expandOffset = 0.25f;
    void ExpandRing(float playbackPercent)
    {
        float temp = (1 - playbackPercent) - expandOffset;
        float percent = Mathf.Clamp(temp,0.0f,1.0f);


        float beatRingRadius = circleRing.rectTransform.localScale.x + 1.0f * percent;
        beatRing.rectTransform.localScale = new Vector3(beatRingRadius, beatRingRadius, 1);

        beatRing.color = new Color (beatRing.color.r, beatRing.color.g, beatRing.color.b, 1 - percent);
        
    }

    public float offset = 0.1f;
    public float playbackPercent = 0.0f;
    float tempbpm = 0.6f;

    void Update()
    {
        debugger.text = Mathf.Round(playbackPercent*10) .ToString();

        //new timer
        if (Gamestart == true)
        {
            if (true) //doggo
            {
                
                playbackPercent = ((songLight.time + offset) % tempbpm) / tempbpm;
                ExpandRing(playbackPercent);
                Pulse();
            }
            
            CountHighCombo();
            TotalScoreBoard();
            DelayBeat();


            if (canVibrateOnce) Vibrate();
            ChangeColorCountdown();

        }
    }

    private float pulseDirector = 0.0f;
    public bool bPulse = true;
    private float pulseCounter = 0.0f;
    //private float offset = 0.20f;

    private float previousPulse = 0.0f;

    private void Pulse()
    {
        if (pulseDirector+expandOffset <= songLight.time)
        {
            CheckHit();
            Debug.Log("Pulse=" + bPulse + "  on " + pulseDirector+expandOffset + ":" + songLight.time);
            pulseDirector += tempbpm;
        }
        
    }

    private void CheckHit()
    {
        if (bPulse)
        {
            RegisterHit(HIT.bad);
        }
        else
        {
            bPulse = true;
        }
    }

    public void GamePlayEnd()
    {
        hpDadGamePlay = false;
    }

    public void WarningAdivce()
    {
        StartCoroutine(IWarningAdivce());
    }

    IEnumerator IWarningAdivce()
    {
        WaitForSeconds waitOneSec = new WaitForSeconds(1);
        for (int i = 14; i >= 0; i--)
        {
            countDownStartText.text = "" + i;
            yield return waitOneSec;
        }
        StartCountDownGamePlay();
    }

    public void StartCountDownGamePlay()
    {
        Debug.Log("start!!!");
        sceneCountStart.SetActive(true);
        StartCoroutine(ICountDownGamePlay());
        reaperLoopAnimPos.transform.position = reaperLoopPos.transform.position;
    }

    IEnumerator ICountDownGamePlay() {
        WaitForSeconds waitOneSec = new WaitForSeconds(1);
        for (int i = 3; i >= 0; i--) {
            countDownStartText.text = "" + i;
            yield return waitOneSec;
        }
        sceneCountStart.SetActive(false);
        countDownStart = 0;
        TimeAndScore.SetActive(true);
        hpDadGamePlay = true;
        HpBarDad.SetActive(true);
        songLight.enabled = true;
        songLight.Play();
        EnableBeat();
        // HpDad();
    }

    public void PopUpHit()
    {
        StartCoroutine(IPopUpHit());
    }

    IEnumerator IPopUpHit()
    {
        Debug.Log("wait");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("clear");

        ClearPopUp();

    }
    void ClearPopUp()
    {
        perfectPopUp.SetActive(false);
        goodPopUp.SetActive(false);
        missPopUp.SetActive(false);
    }

    void GhostAppear()
    {
        if (timeCount >= 10)
        {
            Ghost.SetActive(true);
            Debug.Log("StartFade");
        }
        else
        {
            Ghost.SetActive(false);
            alphaLevel = 1;
            beatRing.color = new Color(beatRing.color.r, beatRing.color.g, beatRing.color.b, alphaLevel);
        }
    }

    void HpDad()
    {
        
        curhpDad -= 1 * Time.deltaTime;
        hpBarValue = curhpDad / maxHp;
        soulPosX.localPosition = new Vector3(hpBarValue, 0.0f, 0.0f);
        hpdadText.text = "" + Mathf.CeilToInt(curhpDad) + "/" + maxHp;
        hpBar.fillAmount = hpBarValue;

        if (curhpDad <= 0.0f)
        {
            curhpDad = 0;
        }
        else if (curhpDad >= 120.0f)
        {
            curhpDad = 120;
        }
    }

   public void DelayBeat()
    {
        delayTimerBump += Time.deltaTime;
    }


    //TODO Touch Controller Vibrate
    private bool canVibrateOnce = false;
    private float vibrateTime = 0.1f;
    private float vibrateTimer = 0.0f;

    private void Vibrate()
    {
        if (vibrateTimer <= vibrateTime)
        {
            XRVibrationManager.Instance.TriggerVibration(1, 1, XRNode.RightHand);
            XRVibrationManager.Instance.TriggerVibration(1, 1, XRNode.LeftHand);
            vibrateTimer += Time.deltaTime;
        }
        else
        {
            XRVibrationManager.Instance.StopVibration(XRNode.RightHand);
            XRVibrationManager.Instance.StopVibration(XRNode.LeftHand);
            vibrateTimer = 0.0f;
            canVibrateOnce = false;
        }
    }

    private float changeColorTime = 0.3f;
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

    enum HIT { perfect, good, bad }
    private void RegisterHit(HIT hit)
    {
        switch (hit)
        {
            case HIT.perfect:
                ChangeColor(goodColor, true);
                perfectEvent.Invoke();
                perfectPopUp.SetActive(true);
                IPopUpHit();
                break;
            case HIT.good:
                ChangeColor(goodColor, true);
                goodEvent.Invoke();
                goodPopUp.SetActive(true);
                IPopUpHit();
                break;
            case HIT.bad:
                ChangeColor(badColor, true);
                badEvent.Invoke();
                missPopUp.SetActive(true);
                IPopUpHit();
                break;
            default:
                Debug.Log("THIS SHOULDN'T HAPPEN");
                break;
        }
    }

    public bool inverseColor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand Checker"))
        {
            if (bPulse)
            {
                canVibrateOnce = true;
                if (playbackPercent > 0.8f)
                {
                    RegisterHit(HIT.perfect);
                    AudioPlayer.PlayAudioClip(audioClips[0], true);

                }
                else if (playbackPercent <= 0.8f && playbackPercent >= 0.4f)
                {
                    RegisterHit(HIT.good);
                    AudioPlayer.PlayAudioClip(audioClips[1], true);

                }
                else
                {
                    RegisterHit(HIT.bad);
                    AudioPlayer.PlayAudioClip(audioClips[1], true);

                }
                bPulse = false;
            }
            else
            {
                RegisterHit(HIT.bad);
                AudioPlayer.PlayAudioClip(audioClips[1], true);
            }
        }
        
    }

    public void EnableBeatTutorial() {
        tutorialBump = true;
        EnableBeat();
    }

    public void EnableBeat()
    {
        beatCanvas.SetActive(true);
        beatCollider.enabled = true;
    }

    public void DisableBeat()
    {
        beatCanvas.SetActive(false);
        beatCollider.enabled = false;
    }

    void CountHighCombo()
    {
        if (comboHit > highCombo)
        {
            highCombo = comboHit;
        }

    }

    void TotalScoreBoard()
    {
        scoreText.text = "" + curScore;
        totalScoreText.text = ": " + curScore;
        comboText.text = "Combo x " + highCombo;
        perfectHitText.text = "X " + perfectHit;
        goodHitText.text = "X " + goodHit;
        missText.text = "X " + missHit;

        

        if (curhpDad >= 60)
        {
            if (curhpDad > 80)
            {
                rankImg.sprite = rankA;
            }
            else
            {
                rankImg.sprite = rankB;
            }
            boardWin.SetActive(true);
            boardLose.SetActive(false);
        }
        
        else 
        {
            rankImg.sprite = rankC;
            boardLose.SetActive(true);
            boardWin.SetActive(false);
        }
    }

    public void CheckWinLose()
    {
        if (curhpDad >= 60)
        {
            SimpleDirectorController.Instance.PlayTrack(3);
        }
        else
        {
            SimpleDirectorController.Instance.PlayTrack(2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        circle.color = defaultColor;
       // AudioPlayer.PlayAudioClip(audioClips[2], true);  

    }

    public bool CheckGoodHitBeat()
    {
        return beatRadius > hit - errCorrectionHit && beatRadius < hit + errCorrectionHit && beatRadius > 0;
    }

    public bool CheckPerfectHitBeat()
    {
        return beatRadius > hit - errCorrectionHit / 2 && beatRadius < hit + errCorrectionHit / 2 && beatRadius > 0;
    }
}
