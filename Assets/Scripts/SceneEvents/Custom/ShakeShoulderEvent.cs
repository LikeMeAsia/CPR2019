using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShakeShoulderEvent", menuName = "SceneEvent/ShakeShoulderEvent")]
public class ShakeShoulderEvent : SceneEvent
{
    public string assetName;
    private ShakeShoulder shoulder;
    private Animator shakeShoulderTutorialAnim;


    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<ShakeShoulder>(assetName, out shoulder);
        Debug.Log("Found ShakeShoulder[" + assetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<Animator>("ShakeShoulderCanvas", out shakeShoulderTutorialAnim);
        Debug.Log("Found Animator[" + assetName + "]: " + found);
        if (shakeShoulderTutorialAnim != null)
        {
            shakeShoulderTutorialAnim.SetBool("enable", false);
        }

    }

    public override void StartEvent()
    {
        InitEvent();
        if (shakeShoulderTutorialAnim != null)
        {
            shakeShoulderTutorialAnim.SetBool("enable", true);
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
        return false;
    }

}
