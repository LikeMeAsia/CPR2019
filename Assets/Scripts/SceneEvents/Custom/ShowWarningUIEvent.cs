using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShowWarningUIEvent", menuName = "SceneEvent/ShowWarningUIEvent")]

public class ShowWarningUIEvent : SceneEvent
{
    private Animator warningUIAnim;
    public string assetName= "WarningUIAnim";
    private int countDown=8;
    private bool skip;
    private bool changeToPageOne = true;
    private bool enableFalse = false;

    //TODO: add passeventcond + chexck countdowntime + cpr exit time + and clipiter Check if it's cos of nomoreclips or touchChestCollider

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
        if (warningUIAnim != null)
        {
            warningUIAnim.SetBool("enable", false);
        }
    }

    public override void StartEvent()
    {
        if (warningUIAnim != null)
        {
            warningUIAnim.SetBool("enable", true);
        }
    }

    public override void StopEvent()
    {
        if (warningUIAnim != null)
        {
            warningUIAnim.SetBool("enable", false);
        }
    }

    public override void UpdateEvent()
    {
        countDown--;
        //Debug.Log(countDown + "countdown");
        if (countDown <= 0&&changeToPageOne)
        {
            Debug.Log("page 1");
            warningUIAnim.SetInteger("page", 1);
            countDown = 5;
            changeToPageOne = false;
            enableFalse = true;
        }
        if(countDown<0&& enableFalse)
        {
            warningUIAnim.SetBool("enable", false);
            passEventCondition = true;

        }


    }
    public override bool Skip() 
    {
        skip = true;
        passEventCondition = true;
        Debug.Log("Skippu");
        return skip;
    }
}
