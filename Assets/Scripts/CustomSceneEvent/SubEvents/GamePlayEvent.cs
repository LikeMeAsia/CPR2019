using com.dgn.SceneEvent;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GamePlayEvent", menuName = "SceneEvent/GamePlayEvent")]

public class GamePlayEvent : SceneSubEvent
{
    private Game_Manager gameManager;
    public string assetName = "GameManager";
    public AudioClip clip;
    public int goodEndingTrack;
    public int badEndingTrack;
    private bool waitCutscene;
    private bool skip;
    

    public override void InitEvent()
    {
        base.InitEvent();
        waitCutscene = false;
        skip = false;
        bool found = SceneAssetManager.GetAssetComponent<Game_Manager>(assetName, out gameManager);
        gameManager.DisableBeatUI(); //disable UI and collider from game manager
        gameManager.hpReduction = false;
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
            gameManager.EnableBeatUI(); //enable Beat UI and Beat collider from game manager
            gameManager.curhpDad = 80f;
            gameManager.StartGamePlayAndUI();
            gameManager.hpReduction = true;
        }
    }

    public override void UpdateEvent()
    {
        if (waitCutscene) {
            passEventCondition = SimpleDirectorController.Instance.Interruptable;
            //INTERRUBABLE MEANS THE CUTSCENE CAN BE INTERRUPTED 
        }
        else if (gameManager.rhythmController != null)
        {
            if (!gameManager.rhythmController.GameStart)
            {
                gameManager.DisableBeatUI();
                gameManager.StopGamePlayAndUI();
                gameManager.DefaultDadShirtColour();
                if (gameManager.curhpDad >= 50) {
                    SimpleDirectorController.Instance.PlayTrack(goodEndingTrack);
                }
                else {
                    SimpleDirectorController.Instance.PlayTrack(badEndingTrack);
                }
                waitCutscene = true;
            }
        }
        else
        {
            gameManager.DisableBeatUI();
            passEventCondition = true;
        }

    }

    public override void StopEvent()
    {
        gameManager.DisableBeatUI();
        gameManager.StopGamePlayAndUI();
        gameManager.EnableScoreBoard(); //INSERT SETACTIVE CANVAS HERE
        waitCutscene = false;
    }

    public override bool Skip()
    {
        if (waitCutscene)
        {
            SimpleDirectorController.Instance.SkipToEndTrack();
            skip = true;
        }
        else
            gameManager.rhythmController.StopRhythm();
        {
            skip = false;
        }
        return skip;
    }
}
