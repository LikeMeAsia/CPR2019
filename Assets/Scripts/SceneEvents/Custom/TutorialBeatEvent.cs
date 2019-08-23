using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "TutorialBeatEvent", menuName = "SceneEvent/TutorialBeatEvent")]

public class TutorialBeatEvent : SceneEvent
{
    private Game_Manager gameManager;
    public string assetName= "GameManager";
    public uint count = 10;
    public uint loop = 3;
    public AudioClip clip;

    private uint totalCount;
    private uint countLoop;
    private bool skip;

    public override void InitEvent() 
    {
        base.InitEvent();
        skip = false;
        countLoop = 0;
        totalCount = 0;
        bool found = SceneAssetManager.GetAssetComponent<Game_Manager>(assetName, out gameManager);
        Debug.Log("Found Game_Manager[" + assetName + "]: " + found);
        gameManager.DisableUI(); //disable UI and collider from game manager
        gameManager.hpReduction = false;
    }
    public override bool Skip()
    {
        skip = true;
        return skip;
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
            gameManager.EnableUI(); //enable Beat UI and Beat collider from game manager
        }
    }

    public override void StopEvent()
    {
        gameManager.StopGame();
    }

    public override void UpdateEvent()
    {
        if (gameManager.rhythmController != null)
        {
            totalCount = gameManager.rhythmController.goodHit + gameManager.rhythmController.perfectHit;
            if (totalCount >= count || skip)
            {
                gameManager.DisableUI();
                passEventCondition = true;
            }

            Debug.Log("Total Count: " + totalCount);

            if (!gameManager.rhythmController.GameStart) {
                countLoop = countLoop + 1;
                if (countLoop < loop)
                {
                    Debug.Log("Count Loop " + countLoop);
                    gameManager.rhythmController.StartRhythm();
                }
                else {
                    gameManager.DisableUI();
                    passEventCondition = true;
                }
            }

        }
        else
        {
            gameManager.DisableUI();
            passEventCondition = true;
        }

    }

}
