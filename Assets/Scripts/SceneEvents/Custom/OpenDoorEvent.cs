using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "OpenDoorEvent", menuName = "SceneEvent/OpenDoorEvent")]
public class OpenDoorEvent : SceneEvent
{
    public string doorKnobName;
    private DoorKnob doorKnob;
    private float doorOpenDelay;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<DoorKnob>(doorKnobName, out doorKnob);
        Debug.Log("Found DoorKnob["+ doorKnobName + "]: " + found);
    }

    public override void StartEvent()
    {
        InitEvent();
        if (doorKnob == null)
        {
            passEventCondition = true;
        }
        else {
            doorKnob.ShowUI();
            doorOpenDelay = doorKnob.doorOpenDelay;
        }
    }

    public override void UpdateEvent()
    {
        if (doorKnob.DoorOpen) {
            if (doorOpenDelay > 0)
            {
                doorOpenDelay -= Time.deltaTime;
            }
            else {
                passEventCondition = true;
            }
        }
    }

    public override void StopEvent()
    {

    }

    public override bool Skip()
    {
        doorKnob.OpenDoor();
        return true;
    }
}
