using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    public bool Musicstart;
    public AudioSource BeatMusic;
    public BeatController beatcontroller;

    public Image hpBar;
    public Text hpdadText;
    public RectTransform soulPosX;
    private float hpBarValue;
    public float curhpDad = 0;
    public float maxHp = 120;

    public float hpreduction = 1.0f;

    void Start()
    {
        Player.Instance.showController = false;
        Player.Instance.cprHand.enabledSnap = true;
        beatcontroller.Gamestart = true;
        BeatMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        HpDad();
    }

    public void Heal(float healed) {
        curhpDad = curhpDad + healed;
    }

    void HpDad()
    {
        Heal(-hpreduction * Time.deltaTime);
        if (curhpDad <= 0.0f)
        {
            curhpDad = 0;
        }
        else if (curhpDad >= 120.0f)
        {
            curhpDad = 120;
        }
        hpBarValue = curhpDad / maxHp;
        soulPosX.localPosition = new Vector3(hpBarValue, 0.0f, 0.0f);
        hpdadText.text = "" + Mathf.CeilToInt(curhpDad) + "/" + maxHp;
        hpBar.fillAmount = hpBarValue;

        
    }
}
