using com.dgn.SceneEvent;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShowWarningUIEvent", menuName = "SceneEvent/ShowWarningUIEvent")]

public class ShowWarningUIEvent : SceneSubEvent
{
    public string assetName= "WarningUIAnim";

    private GameObject warningUI;
    private Animator warningUIAnim;
    private float countDown;
    private bool skip;
    
    public override void InitEvent()
    {
        base.InitEvent();
        skip = false;
        bool found = SceneAssetManager.GetGameObjectAsset(assetName, out warningUI);
        SceneAssetManager.GetAssetComponentInChildren<Animator>(assetName, out warningUIAnim);

        if (warningUI == null)
        {
            passEventCondition = true;
        }
        else {
            warningUIAnim.SetBool("enable", false);
        }
    }

    public override void StartEvent()
    {
        countDown = 8f;
        if (warningUI != null)
        {
            warningUI.SetActive(true);
            warningUIAnim.SetBool("enable", true);
            Debug.Log("starteventwarning");
        }
        Debug.Log(countDown + "countDown at StartEvent");
    }

    public override void StopEvent()
    {
        if (warningUIAnim != null)
        {
            warningUIAnim.SetBool("enable", false);
            warningUIAnim.ResetTrigger("action");
            warningUIAnim.SetTrigger("action");
        }
    }

    public override void UpdateEvent()
    {
        countDown-=Time.deltaTime;

        if(countDown <= 0)
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
