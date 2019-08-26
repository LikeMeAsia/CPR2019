using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PhoneCallingEvent", menuName = "SceneEvent/PhoneCallingEvent")]
public class PhoneCallingEvent : SceneEvent
{
    public string phoneAssetName;
    private Phone phone;
    
    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<Phone>(phoneAssetName, out phone);
        Debug.Log("Found Phone[" + phoneAssetName + "]: " + found);
    }

    public override void StartEvent()
    {
        InitEvent();
        if (phone == null)
        {
            passEventCondition = true;
        }
        else
        {
            phone.SetActive(true);
            phone.Activate();
        }
    }
    public override void UpdateEvent()
    {
        passEventCondition = phone.IsCalling;
    }
    public override void StopEvent()
    {

    }
    public override bool Skip()
    {
        phone.Call();
        return true;
       // return false;
    }
}
