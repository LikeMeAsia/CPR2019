using com.dgn.SceneEvent;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "CountdownEvent", menuName = "SceneEvent/CountdownEvent")]

public class CountdownEvent : SceneSubEvent
{
    private TextMeshProUGUI countdownUIText;
    public string assetName= "CountdownUI";
    private float countDown;
    private bool skip;
    
    public override void InitEvent()
    {
        base.InitEvent();
        skip = false;
        bool found = SceneAssetManager.GetAssetComponentInChildren<TextMeshProUGUI>(assetName, out countdownUIText);
        if(found) countdownUIText.text = "";
        else passEventCondition = true;
    }

    public override void StartEvent()
    {
        countDown = 5.9f;
        Player.Instance.cprHand.enabledSnap = true;
        if (countdownUIText != null)
        {
            countdownUIText.text = Mathf.FloorToInt(countDown).ToString();
        }
    }

    public override void StopEvent()
    {
        if (countdownUIText != null)
        {
            countdownUIText.text = "";
        }
    }

    public override void UpdateEvent()
    {
        countDown-=Time.deltaTime;
        countdownUIText.text = Mathf.FloorToInt(countDown).ToString();

        if (countDown <= 0)
        {
            passEventCondition = true;
        }
    }
    public override bool Skip() 
    {
        skip = true;
        passEventCondition = true;
        return skip;
    }
    
}
