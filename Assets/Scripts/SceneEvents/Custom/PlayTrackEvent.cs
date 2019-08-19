using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayTrackEvent", menuName = "SceneEvent/PlayTrackEvent")]
public class PlayTrackEvent : SceneEvent
{
    public int trackId;

    public override void InitEvent()
    {
        base.InitEvent();
    }

    public override void StartEvent()
    {
        InitEvent();
        SimpleDirectorController.Instance.PlayTrack(trackId);
    }

    public override void UpdateEvent()
    {
        passEventCondition = SimpleDirectorController.Instance.Interruptable;
    }

    public override void StopEvent()
    {

    }

    public override void Skip()
    {
        SimpleDirectorController.Instance.SkipToEndTrack();
    }
}
