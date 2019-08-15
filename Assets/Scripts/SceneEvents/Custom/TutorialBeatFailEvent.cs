using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "TutorialBeatFailEvent", menuName = "SceneEvent/TutorialBeatFailEvent")]

public class TutorialBeatFailEvent : SceneEvent
{
    private RhythmController rhythmController;
    public string assetName = "Beat";

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
        if (rhythmController.failCount >= 10)
        {
            passEventCondition = true;
        }
    }

}
