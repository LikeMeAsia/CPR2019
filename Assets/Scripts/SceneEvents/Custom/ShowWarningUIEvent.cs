using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShowWarningUIEvent", menuName = "SceneEvent/ShowWarningUIEvent")]

public class ShowWarningUIEvent : SceneEvent
{
    private Animator warningUIAnim;
    public string assetName= "WarningUIAnim";
    private float countDown;
    private bool skip;
    private bool enableFalse;
    
    public override void InitEvent()
    {
        base.InitEvent();
        skip = false;
        bool found = SceneAssetManager.GetAssetComponent<Animator>(assetName, out warningUIAnim);
        Debug.Log("Found Game_Manager[" + assetName + "]: " + found);
        
        if (warningUIAnim == null)
        {
            passEventCondition = true;
        }
        else {
            warningUIAnim.SetBool("enable", false);
        }
    }

    public override void StartEvent()
    {
        enableFalse = false;
        countDown = 8f;
        if (warningUIAnim != null)
        {
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
            warningUIAnim.SetTrigger("action");
        }
    }

    public override void UpdateEvent()
    {
        countDown-=Time.deltaTime;

        if(countDown <= 0 && enableFalse)
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
