using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountDown : MonoBehaviour
{
    public Image cooldown;

    public float curTime = 0;
    public float StartingTime = 10;

    public float RedTime;

    public Text textCountDown;

    public GameObject CircleBump;
    public GameObject TotalScore;
    public GameObject HpDad;

    public static float CountTimeToFade;

    // Start is called before the first frame update
    void Start()
    {
        curTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime > 0) {
            curTime -= Time.deltaTime;
            if (curTime <= 0)
            {
                curTime = 0;
                gameObject.SetActive(false);
                CircleBump.SetActive(false);
                HpDad.SetActive(false);
                TotalScore.SetActive(true);
            }
            float calc_time = curTime / StartingTime;
            //  cooldown.fillAmount = calc_time;

            textCountDown.text = "" + Mathf.RoundToInt(curTime);
            BeatController.timeCount = CountTimeToFade;

            if (curTime <= RedTime)
            {
                textCountDown.color = Color.red;
            }
        }
        
        CountTimeToFade += 1 * Time.deltaTime;

        if (CountTimeToFade > 12)
        {
            CountTimeToFade = 0;
        }
    }
}
