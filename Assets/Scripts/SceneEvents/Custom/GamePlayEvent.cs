﻿using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GamePlayEvent", menuName = "SceneEvent/GamePlayEvent")]

public class GamePlayEvent : SceneEvent
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
        Debug.Log("Found Game_Manager[" + assetName + "]: " + found);
        gameManager.DisableUI(); //disable UI and collider from game manager
        gameManager.hpReduction = false;
    }
    public override bool Skip()
    {
        if (waitCutscene) {
            SimpleDirectorController.Instance.SkipToEndTrack();
            skip = true;
        }
        else {
            skip = false;
        }
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
            gameManager.EnableUI(); //enable Beat UI and Beat collider from game manager
            gameManager.curhpDad = 50f;
            gameManager.StartGamePlayAndUI();
            gameManager.hpReduction = true;
        }
    }

    public override void StopEvent()
    {
        gameManager.DisableUI();
        gameManager.StopGamePlayAndUI();
        waitCutscene = false;
    }

    public override void UpdateEvent()
    {
        if (waitCutscene) {
            passEventCondition = SimpleDirectorController.Instance.Interruptable;
        }
        else if (gameManager.rhythmController != null)
        {
            if (!gameManager.rhythmController.GameStart)
            {
                gameManager.DisableUI();
                gameManager.StopGamePlayAndUI();
                if (gameManager.curhpDad > 50) {
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
            gameManager.DisableUI();
            passEventCondition = true;
        }

    }

}
