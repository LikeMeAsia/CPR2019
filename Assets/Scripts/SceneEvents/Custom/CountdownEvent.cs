using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "CountdownEvent", menuName = "SceneEvent/CountdownEvent")]

public class CountdownEvent : SceneEvent
{
    private Text countdownUIText;
    public string assetName= "CountdownUI";
    private float countDown;
    private bool skip;
    
    public override void InitEvent()
    {
        base.InitEvent();
        skip = false;
        bool found = SceneAssetManager.GetAssetComponentInChildren<Text>(assetName, out countdownUIText);
        Debug.Log("Found Game_Manager[" + assetName + "]: " + found);
        countdownUIText.text = "";
        if (countdownUIText == null)
        {
            passEventCondition = true;
        }
    }

    public override void StartEvent()
    {
        countDown = 5.9f;

        if (countdownUIText != null)
        {
            countdownUIText.text = countDown.ToString();
            Debug.Log("start CountdownEvent");
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
        countdownUIText.text = Mathf.RoundToInt(countDown).ToString();

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
