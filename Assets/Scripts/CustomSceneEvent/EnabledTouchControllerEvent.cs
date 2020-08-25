using com.dgn.SceneEvent;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "EnabledTouchControllerEvent", menuName = "SceneEvent/EnabledTouchControllerEvent")]
public class EnabledTouchControllerEvent : SceneEvent
{
    public bool enableController;
    public SceneEvent nextEvent;

    public override void InitEvent()
    {
        base.InitEvent();
        if(nextEvent) nextEvent.InitEvent();
    }

    public override void StartEvent()
    {
        passEventCondition = true;
    }
    public override void UpdateEvent(){}
    public override void StopEvent(){
        Player.Instance.showController = enableController;
    }

    public override bool Skip()
    {
        return true;
    }

    public override SceneEvent NextEvent()
    {
        return nextEvent;
    }
}
