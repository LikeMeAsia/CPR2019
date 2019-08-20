using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerMoveEvent", menuName = "SceneEvent/PlayerMoveEvent", order = 3)]
public class PlayerMoveEvent : SceneEvent
{
    [SerializeField]
    private string positionName;
    private Transform targetTransform;

    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float moveDelay = 0;

    [SerializeField]
    private bool waitFinishMove;

    public override void InitEvent()
    {
        base.InitEvent();
        SceneAssetManager.GetAssetComponent<Transform>(positionName, out targetTransform);
    }

    public override void StartEvent()
    {
        InitEvent();
        if (targetTransform == null) {
            passEventCondition = true;
        }
        else{
            passEventCondition = !waitFinishMove;
            Player.Instance.MoveTo(targetTransform, moveSpeed, moveDelay);
        }
    }

    public override void UpdateEvent()
    {
        passEventCondition = !waitFinishMove || !Player.Instance.IsMove;
    }

    public override void StopEvent()
    {
    }

    public override bool Skip()
    {
        return false;
    }

}
