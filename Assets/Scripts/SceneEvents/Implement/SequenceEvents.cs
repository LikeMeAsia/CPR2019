using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "SequenceEvents", menuName = "SceneEvent/SequenceEvents", order = 1)]
public class SequenceEvents : SceneEvent
{
    public SceneEvent[] sceneEvents;

    private int eventIter;
    private bool callNextProc;
    private float delayProc;
    private bool skip;

    public override void InitEvent()
    {
        base.InitEvent();
        foreach (SceneEvent sceneEvent in sceneEvents)
        {
            sceneEvent.InitEvent();
        }
        eventIter = 0;
        callNextProc = false;
        skip = false;
    }

    public override void StartEvent()
    {
        InitEvent();
        callNextProc = true;
    }
    
    public override void UpdateEvent()
    {
        if (delayProc > 0)
        {
            delayProc -= Time.deltaTime;
            return;
        }
        if (eventIter >= sceneEvents.Length)
        {
            passEventCondition = true;
            return;
        }
        if (callNextProc)
        {
            callNextProc = false;
            sceneEvents[eventIter].StartEvent();
        }
        else
        {
            sceneEvents[eventIter].UpdateEvent();
            if (sceneEvents[eventIter].CheckPassEventCondition())
            {
                sceneEvents[eventIter].StopEvent();
                delayProc = sceneEvents[eventIter].GetDelayNextEvent();
                eventIter++;
                callNextProc = true;
            }
        }
        if (skip && !callNextProc)
        {
            skip = sceneEvents[eventIter].Skip();
        }
    }


    public override void StopEvent()
    {

    }

    public override bool Skip()
    {
        skip = true;
        return skip;
    }
}
