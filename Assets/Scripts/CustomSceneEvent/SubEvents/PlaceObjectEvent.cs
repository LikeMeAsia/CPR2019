using com.dgn.SceneEvent;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
[CreateAssetMenu(fileName = "PlaceObjectEvent", menuName = "SceneEvent/PlaceObjectEvent")]
public class PlaceObjectEvent : SceneSubEvent
{
    public string assetName;
    public string targetName = "Phone";
    //private PlaceActivateArea placeArea;
    private XRSocketInteractor interactor;
    private XRBaseInteractable target;

    public override void InitEvent()
    {
        base.InitEvent();
        //bool found = SceneAssetManager.GetAssetComponent<PlaceActivateArea>(assetName, out placeArea);
        bool found = SceneAssetManager.GetAssetComponent<XRSocketInteractor>(assetName, out interactor);
        SceneAssetManager.GetAssetComponent<XRBaseInteractable>(targetName, out target);
        if (found)
        {
            //placeArea.SetActive(false);
            interactor.enableInteractions = false;
            interactor.gameObject.SetActive(false);
        }
    }

    public override void StartEvent()
    {
        InitEvent();
        //if (placeArea == null)
        if (interactor == null)
        {
            passEventCondition = true;
        }
        else
        {
            //  placeArea.SetActive(true);
            interactor.gameObject.SetActive(true);
            interactor.enableInteractions = true;
        }
    }
    public override void UpdateEvent()
    {
        //passEventCondition = placeArea.isActivated;
        passEventCondition = interactor.selectTarget == target;
    }
    public override void StopEvent()
    {
        interactor.gameObject.SetActive(false);
    }
    public override bool Skip()
    {
        //placeArea.Activated();
        return false;
    }
}
