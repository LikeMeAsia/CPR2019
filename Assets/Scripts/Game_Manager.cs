using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    [Header("General Settings")]
    public bool Musicstart;
    public RhythmController rhythmController;

    [Header("HP Bar Settings")]
    public Image hpBar;
    public Text hpdadText;
    public RectTransform soulPosX;
    private float hpBarValue;
    public float maxHp = 120;
    public float curhpDad = 0;
    public float hpreduction = 1.0f;

    public GameObject canvasForCPRButton;

    void Start()
    {
        canvasForCPRButton.SetActive(false);
        canvasForCPRButton.GetComponent<Collider>().enabled = false;       
    }

    void Update()
    {
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
         rhythmController.StartRhythm();
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

    public void EnableUI()
    {
        canvasForCPRButton.SetActive(true);
        canvasForCPRButton.GetComponent<Collider>().enabled = true;
    }

    public void DisableUI()
    {
        canvasForCPRButton.SetActive(false);
        canvasForCPRButton.GetComponent<Collider>().enabled = false;
    }
}
