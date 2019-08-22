using System.Collections;
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
    public Canvas uiGamePlayCanvas;
    public Canvas totalScoreBoard;
    public RectTransform soulPosX;
    private float hpBarValue;
    public float maxHp = 100;
    public float curhpDad = 0;
    public float hpreduction = 1.0f;

    [Header("Combo Popup")]
    public Canvas popupHitCanvas;

    void Start()
    {
        hpReduction = false;
        DisableUI();
        
    }

    void Update()
    {
        if (!rhythmController.GameStart)
        {
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

    public void StartGamePlayAndUI()
    {
        Player.Instance.showController = false;
        Player.Instance.cprHand.enabledSnap = true;
        rhythmController.ResetScore();
        rhythmController.StartRhythm();
        uiGamePlayCanvas.gameObject.SetActive(true);
        totalScoreBoard.gameObject.SetActive(false);
    }

    public void StopGame()
    {
        Player.Instance.cprHand.enabledSnap = false;
        rhythmController.StopRhythm();
    }

    public void StopGamePlayAndUI()
    {
        Player.Instance.cprHand.enabledSnap = false;
        rhythmController.StopRhythm();
        uiGamePlayCanvas.gameObject.SetActive(false);
       // totalScoreBoard.gameObject.SetActive(true);
    }

    void HpDad()
    {
        if (hpReduction) Heal(-hpreduction * Time.deltaTime);
        if (curhpDad <= 0.0f)
        {
            curhpDad = 0;
        }
        else if (curhpDad >= 120.0f)
        {
            curhpDad = 120;
        }
        hpBarValue = curhpDad / maxHp;
        
        hpdadText.text = "" + Mathf.CeilToInt(curhpDad) + "/" + maxHp;
        hpBar.fillAmount = hpBarValue;
        soulPosX.localPosition = new Vector3(hpBarValue, 0.0f, 0.0f);
    }

    public void EnableUI()
    {
        rhythmController.SetBeatEnabled(true);
    }

    public void DisableUI()
    {
        rhythmController.SetBeatEnabled(false);
    }

    public void BadHit()
    {
        GameObject missHit = ObjectPooler.Instance.SpawnFromPool("MissHit", popupHitCanvas.transform.position, popupHitCanvas.transform.rotation);
        if (missHit.transform.parent != null) {
            Transform parent = missHit.transform.parent;
            missHit.transform.SetParent(null);
            missHit.transform.SetParent(parent);
            missHit.transform.localPosition = Vector3.zero;
            missHit.transform.localEulerAngles = Vector3.zero;
        }
    }

    public void PerfectHit()
    {
        GameObject perfectHit = ObjectPooler.Instance.SpawnFromPool("PerfectHit", popupHitCanvas.transform.position, popupHitCanvas.transform.rotation);
        if (perfectHit.transform.parent != null)
        {
            Transform parent = perfectHit.transform.parent;
            perfectHit.transform.SetParent(null);
            perfectHit.transform.SetParent(parent);
            perfectHit.transform.localPosition = Vector3.zero;
            perfectHit.transform.localEulerAngles = Vector3.zero;
        }
    }

    public void GoodHit()
    {
        GameObject goodHit = ObjectPooler.Instance.SpawnFromPool("GoodHit", popupHitCanvas.transform.position, popupHitCanvas.transform.rotation);
        if (goodHit.transform.parent != null)
        {
            Transform parent = goodHit.transform.parent;
            goodHit.transform.SetParent(null);
            goodHit.transform.SetParent(parent);
            goodHit.transform.localPosition = Vector3.zero;
            goodHit.transform.localEulerAngles = Vector3.zero;
        }
    }

}
