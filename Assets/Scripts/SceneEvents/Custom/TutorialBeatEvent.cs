using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "TutorialBeatEvent", menuName = "SceneEvent/TutorialBeatEvent")]

public class TutorialBeatEvent : SceneEvent
{
    private Game_Manager gameManager;
    public string assetName="Beat";
    public uint count = 10;
    private bool skip;
    public AudioClip countingAfterMeSoundClip;
    public AudioClip countingSoundClip;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<Game_Manager>(assetName, out gameManager);
        Debug.Log("Found ShakeShoulder[" + assetName + "]: " + found);
    }
    public override void Skip()
    {
        skip = true;
    }

    public override void StartEvent()
    {
        InitEvent();
        gameManager.StartGame();
        //close ui and collider frpm game manager
    }

    public override void StopEvent()
    {
    }

    public override void UpdateEvent()
    {
        if (gameManager.rhythmController != null)
        {
            if (gameManager.rhythmController.tutorialCombo >= count || skip)
            {
                passEventCondition = true;
                gameManager.rhythmController.resetScore();
            }
        }
        else
        {
            passEventCondition = true;
        }

    }

}
