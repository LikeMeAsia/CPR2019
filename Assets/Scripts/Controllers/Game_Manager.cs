using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    [Header("General Settings")]
    public bool Musicstart;
    public bool hpReduction;
    public RhythmController rhythmController;

    [Header("Canvas")]
    public Canvas uiGamePlayCanvas;
    public Canvas totalScoreBoard;
    public Canvas popupHitCanvas;
    public GameObject restartButton;

    [Header("HP Bar Settings")]
    public Image hpBar;
    public Text hpdadText;
    public RectTransform soulPosX;
    private float hpBarValue;
    public float maxHp = 100;
    public float curhpDad = 0;
    public float hpreduction = 1.0f;

    [Header("Scoring System")]
    public Text totalScoreText;
    public Text comboText;
    public Text perfectHitText;
    public Text goodHitText;
    public Text missText;
    public Text hpDadtextscr;
    public Image boardImg;
    public GameObject headerWin;
    public GameObject headerLose;
    public Image rank;
    public Sprite[] rankImg;
    
    [Header("Dad's Material")]
    public Renderer fatherBodyMaterial;
    //private Color32 transparentShirtColour = new Color32(255, 255, 255, 225);
    private Color32 opaqueShirtColour = new Color32(255, 255, 255, 255);
    
    void Start()
    {
        hpReduction = false;
        uiGamePlayCanvas.gameObject.SetActive(false);
        totalScoreBoard.gameObject.SetActive(false);
        popupHitCanvas.gameObject.SetActive(false);
        restartButton.SetActive(false);
        DisableBeatUI();
    }

    void Update()
    {
        if (!rhythmController.GameStart)
        {
            return;
        }
        HpDad();
    }

    public void Heal(float healed)
    {
        curhpDad = curhpDad + healed;
        curhpDad = Mathf.Clamp(curhpDad, 0, 100);
    }

    public void Setup(AudioClip clip)
    {
        rhythmController.Setup(clip);
    }

    public void StartGame()
    {
        Player.Instance.showController = false;
        Player.Instance.cprHand.enabledSnap = true;
        popupHitCanvas.gameObject.SetActive(true);
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
        restartButton.SetActive(false);
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
    }

    void HpDad()
    {
        if (hpReduction) Heal(-hpreduction * Time.deltaTime);
        if (curhpDad <= 0.0f)
        {
            curhpDad = 0;
        }
        else if (curhpDad >= maxHp)
        {
            curhpDad = maxHp;
        }
        hpBarValue = curhpDad / maxHp;

        hpdadText.text = "" + Mathf.CeilToInt(curhpDad) + "/" + maxHp;
        hpBar.fillAmount = hpBarValue;
        soulPosX.localPosition = new Vector3(hpBarValue, 0.0f, 0.0f);
    }

    public void EnableBeatUI()
    {
        rhythmController.SetBeatEnabled(true);
    }

    public void DisableBeatUI()
    {
        rhythmController.SetBeatEnabled(false);
    }

    public void BadHit()
    {
        GameObject missHit = ObjectPooler.Instance.SpawnFromPool("MissHit", popupHitCanvas.transform.position, popupHitCanvas.transform.rotation);
        if (missHit.transform.parent != null)
        {
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

    public void EnableScoreBoard()
    {
        totalScoreBoard.gameObject.SetActive(true);
        restartButton.SetActive(true);
        float totalScore = (rhythmController.perfectHit * 2000f) + (rhythmController.goodHit * 1000f);
        float maxScore = (rhythmController.perfectHit + rhythmController.goodHit + rhythmController.missHit) * 2000f;
        float rankInPercentage = (curhpDad / maxHp);
        totalScoreText.text = Mathf.FloorToInt(totalScore).ToString();
        comboText.text = "x"+rhythmController.maxCombo.ToString();
        perfectHitText.text = rhythmController.perfectHit.ToString();
        goodHitText.text = rhythmController.goodHit.ToString();
        missText.text = rhythmController.missHit.ToString();
        hpDadtextscr.text = Mathf.RoundToInt((curhpDad / maxHp)*100f) + "%";

        if (rankInPercentage >= 0.9f)
        {
            rank.sprite = rankImg[0];
            headerWin.SetActive(true);
            headerLose.SetActive(false);
        }
        else if(rankInPercentage >= 0.7f)
        {
            rank.sprite = rankImg[1];
            headerWin.SetActive(true);
            headerLose.SetActive(false);
        }
        else if (rankInPercentage >= 0.5f)
        {
            rank.sprite = rankImg[2];
            headerWin.SetActive(true);
            headerLose.SetActive(false);
        }
        else
        {
            headerWin.SetActive(false);
            headerLose.SetActive(true);
        }
    }

    public void MakeDadShirtTransparent()
    {
        fatherBodyMaterial.materials[1].SetFloat("_Mode", 2);//fade
        Color32 transparentShirtColour = new Color32(255, 255, 255, 200);
        fatherBodyMaterial.materials[1].SetColor("_Color", transparentShirtColour);
    }

    public void DefaultDadShirtColour()
    {
        fatherBodyMaterial.materials[1].SetColor("_Color", opaqueShirtColour);
        fatherBodyMaterial.materials[1].SetFloat("_Mode", 0); //opaque
    }

    public void CallSetBeatColliderEnabled(bool value)
    {
        rhythmController.ForSetBeatColliderOnly(value);
    }


    public void RestartGame()
    {
        Debug.Log("restartgame");
        SceneManager.LoadScene("Playscene");
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
