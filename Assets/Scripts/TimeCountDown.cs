using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountDown : MonoBehaviour
{
    public Image cooldown;

    public float curTime = 0;
    public float StartingTime = 10;
    int CountDownTime;

    public float RedTime;

    public Text textCountDown;

    public GameObject CircleBump;
    public GameObject TotalScore;

    public static float CountTimeToFade;

    // Start is called before the first frame update
    void Start()
    {
        curTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        curTime -= 1 * Time.deltaTime;

        float calc_time = curTime / StartingTime;

        cooldown.fillAmount = calc_time;

        CountDownTime = Mathf.RoundToInt(curTime);
        textCountDown.text = "Time: " + CountDownTime;
        BeatController.timeCount = CountTimeToFade;

        if (curTime <= RedTime)
        {
            textCountDown.color = Color.red;
            cooldown.color = Color.red;
            if (curTime <= 0)
            {
                curTime = 0;
                gameObject.SetActive(false);
                CircleBump.SetActive(false);
                TotalScore.SetActive(true);

            }
        }

        CountTimeToFade += 1 * Time.deltaTime;

        if (CountTimeToFade > 12)
        {
            CountTimeToFade = 0;
        }
    }
}
