using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlaceObjectEvent", menuName = "SceneEvent/PlaceObjectEvent")]
public class PlaceObjectEvent : SceneEvent
{
    public string assetName;
    private PlaceActivateArea placeArea;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<PlaceActivateArea>(assetName, out placeArea);
        Debug.Log("Found Phone[" + assetName + "]: " + found);
        if (found)
        {
            placeArea.SetActive(false);
        }
    }

    public override void StartEvent()
    {
        InitEvent();
        if (placeArea == null)
        {
            passEventCondition = true;
        }
        else
        {
            placeArea.SetActive(true);
        }
    }
    public override void UpdateEvent()
    {
        passEventCondition = placeArea.isActivated;
    }
    public override void StopEvent()
    {

    }
    public override bool Skip()
    {
        return false;
    }
}
