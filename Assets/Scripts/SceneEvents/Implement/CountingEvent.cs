using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "CountingEvent", menuName = "SceneEvent/CountingEvent")]
public class CountingEvent : SceneEvent
{
    public string assetName;
    public uint objectiveCount;
    private SceneAssetManager.SceneAsset target;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAsset(assetName, out target);
        Debug.Log("Found Asset[" + assetName + "]: " + found);
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
        if (true)//target count >= objective count
        {
            passEventCondition = true;
        }
    }
}
