using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "EnabledTouchControllerEvent", menuName = "SceneEvent/EnabledTouchControllerEvent")]
public class EnabledTouchControllerEvent : SceneEvent
{
    public bool enableController;

    public override void StartEvent()
    {
        Player.Instance.showController = enableController;
        passEventCondition = true;
    }
    public override void UpdateEvent(){}
    public override void StopEvent(){}
    public override bool Skip(){ return false; }
}
