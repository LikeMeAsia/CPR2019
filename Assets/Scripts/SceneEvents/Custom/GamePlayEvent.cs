using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GamePlayEvent", menuName = "SceneEvent/GamePlayEvent")]

public class GamePlayEvent : SceneEvent
{
    private Game_Manager gameManager;
    public string assetName = "GameManager";
    public AudioClip clip;

    private bool skip;

    public override void InitEvent()
    {
        base.InitEvent();
        skip = false;
        bool found = SceneAssetManager.GetAssetComponent<Game_Manager>(assetName, out gameManager);
        Debug.Log("Found Game_Manager[" + assetName + "]: " + found);
        gameManager.DisableUI(); //disable UI and collider from game manager
        gameManager.StartGamePlayAndUI();
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

        if (clip == null)
        {
            passEventCondition = true;
        }
        else
        {
            gameManager.Setup(clip); //insert GamePlay song
            gameManager.StartGamePlayAndUI();
            gameManager.EnableUI(); //enable Beat UI and Beat collider from game manager
            gameManager.curhpDad = 50f;
        }
    }

    public override void StopEvent()
    {
        gameManager.StopGamePlayAndUI();
    }

    public override void UpdateEvent()
    {
        if (gameManager.rhythmController != null)
        {
            gameManager.rhythmController.StartRhythm();


            if (gameManager.rhythmController.GameStart)
            {
                if (gameManager.rhythmController.songHasStopped)
                {
                    passEventCondition = true;
                    gameManager.DisableUI();
                }
            }
        }
        else
        {
            passEventCondition = true;
            gameManager.DisableUI();
        }

    }

}
