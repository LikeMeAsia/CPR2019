using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "TutorialBeatEvent", menuName = "SceneEvent/TutorialBeatEvent")]

public class TutorialBeatEvent : SceneEvent
{
    private Game_Manager gameManager;
    public string assetName="Beat";
    public uint count = 10;
    private bool skip;
    public AudioClip clip;

    public override void InitEvent() 
    {
        base.InitEvent();
        skip = false;
        bool found = SceneAssetManager.GetAssetComponent<Game_Manager>(assetName, out gameManager);
        Debug.Log("Found Game_Manager[" + assetName + "]: " + found);
        gameManager.DisableUI(); //disable UI and collider from game manager
    }
    public override void Skip()
    {
        skip = true;
    }

    public override void StartEvent()
    {
        InitEvent();

        if (clip == null) {
            passEventCondition = true;
        }
        else{
            gameManager.Setup(clip);
            gameManager.StartGame();
            gameManager.EnableUI(); //enable UI and collider from game manager
        }
    }

    public override void StopEvent()
    {
        gameManager.rhythmController.ResetScore();
    }

    public override void UpdateEvent()
    {
        if (gameManager.rhythmController != null)
        {
            if (gameManager.rhythmController.tutorialCombo >= count || skip)
            {
                passEventCondition = true;
                gameManager.DisableUI();
            }

            Debug.Log(gameManager.rhythmController.tutorialCombo);

            if (gameManager.rhythmController.countToThree>=3)
            {
                passEventCondition = true;
                gameManager.DisableUI();

            }

        }
        else
        {
            passEventCondition = true;
            gameManager.DisableUI();
        }

    }

}
