using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    private void Awake()
    {
        instance = this;
        tutorialBump = false;
    }

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

        DisableBeat();
        songLight.enabled = false;
    }

    void FadeColor()
    {
        /*  Color fadeColor = beatRing.color;
          fadeColor.a = alphaLevel;
          beatRing.color = fadeColor;

          alphaLevel = startAlpha + (deltaAlpha * Mathf.Clamp01(beatTimer / beatTime));*/
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

    void ExpandRing()
    {
        beatRadius = startExpand + (deltaExpend * Mathf.Clamp01(beatTimer / beatTime));
        beatRing.rectTransform.localScale = new Vector3(beatRadius, beatRadius, beatRadius);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Gamestart = true;
        }

        if (Gamestart == true)
        {

            beatTimer += Time.deltaTime;
            /* beatRadius = startExpand + (deltaExpend * Mathf.Clamp01(beatTimer / beatTime));
            beatRing.rectTransform.localScale = new Vector3(beatRadius, beatRadius, beatRadius);*/
            ExpandRing();

            if (beatTimer > beatTime)
            {
                beatTimer = 0;
                circle.color = defaultColor;
            }
            if (beatRadius < hit + errCorrectionHit)//0-1
            {
                circleRing.color = goodColor;

            }
            else
            {
                circleRing.color = defaultColor;
            }

            if (hpDadGamePlay)
            {
                HpDad();
            }

         
            GhostAppear();
            CountHighCombo();
            TotalScoreBoard();
            FadeColor();
            DelayBeat();
        }
    }

    public void GamePlayEnd()
    {
        hpDadGamePlay = false;
    }

    public void WarningAdivce()
    {
        //ScenarioControl.Instance.warningCanvas.SetActive(true);
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
        //ScenarioControl.Instance.warningCanvas.GetComponent<Animator>().SetBool("disable", true);
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
        if (perfect)
        {
            ClearPopUp();
            perfectPopUp.SetActive(true);
        }
        else if (good)
        {
            ClearPopUp();
            goodPopUp.SetActive(true);
        }
        else if (miss)
        {
            ClearPopUp();
            missPopUp.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        ClearPopUp();
        perfect = false;
        good = false;
        miss = false;

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
            // FadeColor();
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



    private void OnTriggerEnter(Collider other)
    {
       if (delayTimerBump >= delayTime)
        {
            Debug.Log(other);
            if (other.gameObject.CompareTag("Hand Checker"))
            {
                Debug.Log("Hit");
                if (CheckPerfectHitBeat())//0-0.5
                {
                    Debug.Log("Perfect Hit");
                    circle.color = goodColor;
                    hitBump++;
                    perfect = true;
                    AudioPlayer.PlayAudioClip(audioClips[0], true);
                    if (countDownStart <= 0.0f)
                    {
                        curScore += scorePerPerfectHit;
                        perfectHit++;
                        comboHit++;
                        curhpDad += 2;
                    }
                }
                else if (CheckGoodHitBeat())//>0.5-1
                {
                    Debug.Log("Good Hit");
                    circle.color = goodColor;
                    hitBump++;
                    good = true;
                    AudioPlayer.PlayAudioClip(audioClips[0], true);
                    if (countDownStart <= 0.0f)
                    {
                        curScore += scorePerHit;
                        goodHit++;
                        comboHit++;
                        curhpDad++;
                    }
                }
                else
                {
                    Debug.Log("Miss");
                    circle.color = Color.red;
                    miss = true;
                    AudioPlayer.PlayAudioClip(audioClips[1], true);
                    if (countDownStart <= 0.0f)
                    {
                        missHit++;
                        comboHit = 0;
                        curhpDad -= 1;
                    }
                }

                PopUpHit();
                delayTimerBump = 0f;
            }
        }

        if (tutorialBump && hitBump >= countDownBump)
        {
            tutorialBump = false;
            DisableBeat();
            //ScenarioControl.Instance.cprCanvas.GetComponent<Animator>().SetBool("disable", true);
            SimpleDirectorController.Instance.PlayTrack(1);
            Debug.Log("tutorial_End");
            //StartCountDownGamePlay();
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
