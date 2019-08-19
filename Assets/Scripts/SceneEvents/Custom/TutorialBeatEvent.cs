using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "TutorialBeatEvent", menuName = "SceneEvent/TutorialBeatEvent")]

public class TutorialBeatEvent : SceneEvent
{
    private RhythmController rhythmController;
    public string assetName="Beat";
    public uint count = 10;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<RhythmController>(assetName, out rhythmController);
        Debug.Log("Found ShakeShoulder[" + assetName + "]: " + found);
    }
    public override void Skip()
    {
      
    }

    public override void StartEvent()
    {
        InitEvent();
    }

    public override void StopEvent()
    {
    }

    public override void UpdateEvent()
    {
        if (rhythmController.combo >= count)
        {
            passEventCondition = true;
            rhythmController.resetScore();
        }

    }

}
