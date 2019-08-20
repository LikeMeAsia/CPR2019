﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    [Header("General Settings")]
    public bool Musicstart;
    public bool hpReduction;
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
        hpReduction = false;
        DisableUI();
    }

    void Update()
    {
        if (!rhythmController.GameStart) {
            return;
        }
        HpDad();
    }

    public void Heal(float healed) {
        curhpDad = curhpDad + healed;
    }

    public void Setup(AudioClip clip)
    {
        rhythmController.Setup(clip);
    }

    public void StartGame()
    {
        Player.Instance.showController = false;
        Player.Instance.cprHand.enabledSnap = true;
        rhythmController.ResetScore();
        rhythmController.StartRhythm();
    }

    public void StopGame()
    {
        Player.Instance.cprHand.enabledSnap = false;
        rhythmController.StopRhythm();
    }

    void HpDad()
    {
        if (!hpReduction) return;
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

    public void EnableUI()
    {
        rhythmController.SetEnabled(true);
    }

    public void DisableUI()
    {
        rhythmController.SetEnabled(false);
    }
}
