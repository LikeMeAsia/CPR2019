using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatController : MonoBehaviour
{
    public GameObject HpBarDad;
    public GameObject TimeAndScore;
    public GameObject Ghost;

    public RectTransform soulPosX;

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
    public Text winOrLoseText;


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

    public AudioSource songLight;
    public AudioClip[] audioClips = null;

    private void Awake()
    {
        tutorialBump = false;
    }

    void Start()
    {
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

        beatCanvas.SetActive(false);
        songLight.enabled = false;
    }

    void FadeColor()
    {
        /*  Color fadeColor = beatRing.color;
          fadeColor.a = alphaLevel;
          beatRing.color = fadeColor;

          alphaLevel = startAlpha + (deltaAlpha * Mathf.Clamp01(beatTimer / beatTime));*/
        alphaLevel = 0;
        beatRing.color = new Color(beatRing.color.r, beatRing.color.g, beatRing.color.b, alphaLevel);
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

        }
    }

    public void StartCountDownGamePlay()
    {
        sceneCountStart.SetActive(true);
        StartCoroutine(ICountDownGamePlay());
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
        hpdadText.text = "Hp:" + curhpDad + "/" + maxHp;
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

    private void OnTriggerEnter(Collider other)
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
            else if (CheckGoodHitBeat())//0-1
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
        }

        if (tutorialBump && hitBump >= countDownBump)
        {
            tutorialBump = false;
            ScenarioControl.Instance.cprCanvas.GetComponent<Animator>().SetBool("disable", true);
            SimpleDirectorController.Instance.PlayTrack(1);
            Debug.Log("tutorial_End");
            //StartCountDownGamePlay();
        }
    }

    public void EnableBeatTutorial() {
        tutorialBump = true;
       
        beatCanvas.SetActive(true);
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
        totalScoreText.text = "Score: " + curScore;
        comboText.text = "Combo x " + highCombo;
        perfectHitText.text = "Perfect: " + perfectHit;
        goodHitText.text = "Good: " + goodHit;
        missText.text = "Miss: " + missHit;
        if (curhpDad >= 60)
        {
            winOrLoseText.text = "Save lives";
        }
        else if (curhpDad < 60)
        {
            winOrLoseText.text = "Rescue Fail";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        circle.color = defaultColor;
       // AudioPlayer.PlayAudioClip(audioClips[2], true);  

    }

    public bool CheckGoodHitBeat()
    {
        return beatRadius > hit - errCorrectionHit && beatRadius < hit + errCorrectionHit;
    }

    public bool CheckPerfectHitBeat()
    {
        return beatRadius > hit - errCorrectionHit / 2 && beatRadius < hit + errCorrectionHit / 2;
    }
}
