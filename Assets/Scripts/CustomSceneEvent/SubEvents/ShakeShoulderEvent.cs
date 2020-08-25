using com.dgn.SceneEvent;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShakeShoulderEvent", menuName = "SceneEvent/ShakeShoulderEvent")]
public class ShakeShoulderEvent : SceneSubEvent
{
    public string shoulderName = "Shoulder";
    public string canvasName = "ShakingShoulderCanvas";
    private ShakeShoulder shoulder;
    private Animator shakeShoulderAnim;
    private Game_Manager gameManager;


    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<ShakeShoulder>(shoulderName, out shoulder);
        found = SceneAssetManager.GetAssetComponentInChildren<Animator>(canvasName, out shakeShoulderAnim);
        found = SceneAssetManager.GetAssetComponent<Game_Manager>("GameManager", out gameManager);

        if (shakeShoulderAnim != null)
        {
            shakeShoulderAnim.SetBool("enable", false);
        }
    }

    public override void StartEvent()
    {
        InitEvent();
        gameManager.DefaultDadShirtColour();
        if (shakeShoulderAnim != null)
        {
            shakeShoulderAnim.SetBool("enable", true);
        }
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
        shoulder.SuccessShaking();
        return true;
    }
    
}
