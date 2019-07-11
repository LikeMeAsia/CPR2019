using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatController : MonoBehaviour
{

    public GameObject TimeAndScore;
    public GameObject Ghost;

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
    public Text gooHitText;
    public Text missText;


    public float alphaLevel;
    public int curScore;
    public int scorePerHit = 10;
    public int scorePerPerfectHit = 30;

    public float countDownBump;
    float HitBump;

    public static float timeCount;

    int comboHit;
    int highCombo;
    int perfectHit;
    int goodHit;
    int missHit;

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

        scoreText.text = "Score: 0";
        HitBump = 0;
        highCombo = 0;
        comboHit = 0;
        perfectHit = 0;
        goodHit = 0;
        missHit = 0;

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


            if (countDownBump == HitBump)
            {
                TimeAndScore.SetActive(true);               
            }

            CountHighCombo();

            scoreText.text = "Score: " + curScore;
            totalScoreText.text = "Score: " + curScore;
            comboText.text = "Combo x " + highCombo;
            perfectHitText.text = "Perfect: " + perfectHit;
            gooHitText.text = "Good: " + goodHit;
            missText.text = "Miss: " + missHit;

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
                HitBump++;
                if (countDownBump <= HitBump)
                {
                    curScore += scorePerPerfectHit;
                    perfectHit++;
                    comboHit++;
                }
            }
            else if (CheckGoodHitBeat())//0-1
            {
                Debug.Log("Good Hit");
                circle.color = goodColor;
                HitBump++;
                if (countDownBump <= HitBump)
                {
                    curScore += scorePerHit;
                    goodHit++;
                    comboHit++;
                }
            }
            else
            {
                Debug.Log("Miss");
                circle.color = Color.red;
                missHit++;
                comboHit = 0;
            }

        }
    }

    void CountHighCombo()
    {
        if (comboHit > highCombo)
        {
            highCombo = comboHit;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        circle.color = defaultColor;
    }

    public bool CheckGoodHitBeat()
    {
        return beatRadius > hit - errCorrectionHit && beatRadius < hit + errCorrectionHit;
    }

    public bool CheckPerfectHitBeat()
    {
        return beatRadius > hit - errCorrectionHit/2 && beatRadius < hit + errCorrectionHit/2;
    }
}
