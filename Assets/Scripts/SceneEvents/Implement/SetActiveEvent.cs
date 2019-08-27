using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "SetActiveEvent", menuName = "SceneEvent/SetActiveEvent", order = 1)]
public class SetActiveEvent : SceneEvent
{

    public enum ActiveType { ToActive, ToDeactive }
    public string assetName;
    public ActiveType type;
    private SceneAssetManager.SceneAsset target;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAsset(assetName, out target);
        Debug.Log("Found Asset[" + assetName + "]: " + found);
        if (found)
        {
            switch (type) {
                case ActiveType.ToActive:
                    target.gameObject.SetActive(false);
                    break;
                case ActiveType.ToDeactive:
                    target.gameObject.SetActive(true);
                    break;
            }
        }
    }

    public override void StartEvent()
    {
        InitEvent();
        if (target != null) {
            switch (type)
            {
                case ActiveType.ToActive:
                    target.gameObject.SetActive(true);
                    break;
                case ActiveType.ToDeactive:
                    target.gameObject.SetActive(false);
                    break;
            }
            passEventCondition = true;
        }
    }

    public override void UpdateEvent() { }
    public override void StopEvent() { }
    public override bool Skip() { return false; }
}
