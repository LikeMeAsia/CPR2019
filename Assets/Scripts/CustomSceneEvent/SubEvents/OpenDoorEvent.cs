using com.dgn.SceneEvent;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "OpenDoorEvent", menuName = "SceneEvent/SubEvent/OpenDoorEvent")]
public class OpenDoorEvent : SceneSubEvent
{
    public string doorName;
    public string positionName;
    public string teleporterName;

    private DoorBehaviour door;
    private float doorOpenDelay;
    private Transform targetTransform;
    private Player player;

    public override void InitEvent()
    {
        base.InitEvent();
        SceneAssetManager.GetAssetComponent<DoorBehaviour>(doorName, out door);
        SceneAssetManager.GetAssetComponent<Transform>(positionName, out targetTransform);
        SceneAssetManager.GetAssetComponent<Player>(teleporterName, out player);
    }

    public override void StartEvent()
    {
        if (door == null)
        {
            passEventCondition = true;
        }
        else {
            door.gameObject.SetActive(true);
            door.ShowUI();
            doorOpenDelay = door.doorOpenDelay;
        }
    }

    public override void UpdateEvent()
    {
        if (door.DoorOpen) {
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
        player.Teleport(targetTransform);
    }

    public override bool Skip()
    {
        door.OpenDoor();
        return true;
    }
    
}
