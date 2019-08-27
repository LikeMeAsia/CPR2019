
using UnityEngine;

public interface ISceneEvent
{
    void InitEvent();
    void StartEvent();
    void UpdateEvent();
    void StopEvent();
    bool CheckPassEventCondition();
    float GetDelayNextEvent();
    // return is skippable
    bool Skip();
}
