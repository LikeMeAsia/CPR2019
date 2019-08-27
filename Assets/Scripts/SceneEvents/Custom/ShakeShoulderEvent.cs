using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShakeShoulderEvent", menuName = "SceneEvent/ShakeShoulderEvent")]
public class ShakeShoulderEvent : SceneEvent
{
    public string assetName;
    private ShakeShoulder shoulder;
    private Animator shakeShoulderAnim;
    private Game_Manager gameManager;


    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<ShakeShoulder>(assetName, out shoulder);
        Debug.Log("Found ShakeShoulder[" + assetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<Animator>("ShakeShoulderUIAnim", out shakeShoulderAnim);
        Debug.Log("Found Animator[" + assetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<Game_Manager>("GameManager", out gameManager);
        Debug.Log("Found Animator[" + assetName + "]: " + found);

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
            Debug.Log("enable!!!!");
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
        //return false;
    }

}
