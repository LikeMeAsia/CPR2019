
using UnityEngine;

[System.Serializable]
public abstract class SceneEvent : ScriptableObject, ISceneEvent
{
    protected bool passEventCondition;
    [SerializeField]
    protected float delayNextEvent;

    public virtual void InitEvent() {
        passEventCondition = false;
    }

    public abstract void StartEvent();
    public abstract void UpdateEvent();
    public abstract void StopEvent();
    public abstract void Skip();

    public virtual bool CheckPassEventCondition()
    {
        return passEventCondition;
    }
    public virtual float GetDelayNextEvent()
    {
        return delayNextEvent;
    }
}
