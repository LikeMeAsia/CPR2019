using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShakeShoulderEvent", menuName = "SceneEvent/ShakeShoulderEvent")]
public class ShakeShoulderEvent : SceneEvent
{
    public string assetName;
    private ShakeShoulder shoulder;


    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<ShakeShoulder>(assetName, out shoulder);
        Debug.Log("Found ShakeShoulder[" + assetName + "]: " + found);
    }

    public override void StartEvent()
    {
        InitEvent();
        if (shoulder == null)
        {
            passEventCondition = true;
        }
        else
        {
            shoulder.EnableInputRecieve();
        }
    }

    public override void UpdateEvent()
    {
        if (shoulder.Shaking)
        {
            passEventCondition = true;
        }
    }

    public override void StopEvent()
    {

    }

    public override bool Skip()
    {
        return false;
    }

}
