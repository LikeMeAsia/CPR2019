using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    [Header("General Settings")]
    public bool Musicstart;
    public AudioSource BeatMusic;
    public RhythmController rhythmController;

    [Header("HP Bar Settings")]
    public Image hpBar;
    public Text hpdadText;
    public RectTransform soulPosX;
    private float hpBarValue;
    public float maxHp = 120;
    public float curhpDad = 0;
    public float hpreduction = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        HpDad();
    }

    public void Heal(float healed) {
        curhpDad = curhpDad + healed;
    }


    public void StartGame()
    {
         Player.Instance.showController = false;
         Player.Instance.cprHand.enabledSnap = true;
         rhythmController.Gamestart = true;
         BeatMusic.Play(); 

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
