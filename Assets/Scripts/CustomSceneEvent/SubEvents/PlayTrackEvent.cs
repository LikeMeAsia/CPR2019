using com.dgn.SceneEvent;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayTrackEvent", menuName = "SceneEvent/SubEvent/PlayTrackEvent")]
public class PlayTrackEvent : SceneSubEvent
{
    public int trackId;

    public override void InitEvent()
    {
        base.InitEvent();
    }

    public override void StartEvent()
    {
        SimpleDirectorController.Instance.PlayTrack(trackId);
    }

    public override void UpdateEvent()
    {
        passEventCondition = SimpleDirectorController.Instance.Interruptable;
    }

    public override void StopEvent()
    {

    }

    public override bool Skip()
    {
        SimpleDirectorController.Instance.SkipToEndTrack();
        return true;
    }
    
}
