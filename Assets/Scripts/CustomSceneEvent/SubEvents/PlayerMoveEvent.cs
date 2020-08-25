using com.dgn.SceneEvent;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerMoveEvent", menuName = "SceneEvent/SubEvent/PlayerMoveEvent", order = 3)]
public class PlayerMoveEvent : SceneSubEvent
{
    [SerializeField]
    private string positionName;
    [SerializeField]
    private string teleporterName;

    private Transform targetTransform;
    private Button walkButton;
    private Player player;
    
    
    public override void InitEvent()
    {
        base.InitEvent();
        SceneAssetManager.GetAssetComponent<Transform>(positionName, out targetTransform);
        SceneAssetManager.GetAssetComponent<Player>(teleporterName, out player);
    }

    public override void StartEvent()
    {
        passEventCondition = (targetTransform == null || player == null);
        if (!passEventCondition)
        {
            targetTransform.gameObject.SetActive(true);
            walkButton = targetTransform.GetComponentInChildren<Button>();
            if (walkButton) walkButton.onClick.AddListener(OnClick);
        }
    }

    public override void UpdateEvent()
    {

    }
    
    public override void StopEvent()
    {
        player.Teleport(targetTransform);
        if(walkButton) walkButton.onClick.RemoveListener(OnClick);
        if (targetTransform != null)  targetTransform.gameObject.SetActive(false);
    }

    public override bool Skip()
    {
        OnClick();
        return true;
    }

    public void OnClick() {
        passEventCondition = true;
    }
    
}
