using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerDoCPRHandEvent", menuName = "SceneEvent/PlayerDoCPRHandEvent")]
public class PlayerDoCPRHandEvent : SceneEvent
{
    public string uiName;
    private SceneAssetManager.SceneAsset uiAsset;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAsset(uiName, out uiAsset);
        Debug.Log("Found UI CPR[" + uiName + "]: " + found);
        if (found)
        {
            uiAsset.gameObject.SetActive(false);
        }
    }

    public override void StartEvent()
    {
        InitEvent();
        if (CPRHand.Instance == null)
        {
            passEventCondition = true;
        }
        else if(uiAsset.gameObject != null)
        {
            uiAsset.gameObject.SetActive(true);
            Player.Instance.cprHand.enabledSnap = true;
        }
    }

    public override void UpdateEvent()
    {
        if (CPRHand.Instance != null && CPRHand.Instance.snaping)
        {
            passEventCondition = true;
        }
    }

    public override void StopEvent()
    {
        if (uiAsset.gameObject != null)
        {
            uiAsset.gameObject.SetActive(false);
        }
    }

    public override void Skip()
    {

    }
}
