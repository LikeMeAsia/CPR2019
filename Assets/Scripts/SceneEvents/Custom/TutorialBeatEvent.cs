using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "TutorialBeatEvent", menuName = "SceneEvent/TutorialBeatEvent")]

public class TutorialBeatEvent : SceneEvent
{
    private Game_Manager gameManager;
    public string assetName1= "GameManager";
    public string assetName2 = "FatherBodyMaterial";
    private Renderer fatherBodyMaterial;
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
        bool found = SceneAssetManager.GetAssetComponent<Game_Manager>(assetName1, out gameManager);
        Debug.Log("Found Game_Manager[" + assetName1 + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<Renderer>(assetName2, out fatherBodyMaterial);
        Debug.Log("Found Material[" + assetName2 + "]: " + found);

        gameManager.DisableBeatUI(); //disable UI and collider from game manager
        gameManager.hpReduction = false;
        gameManager.DefaultDadShirtColour();
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
            gameManager.EnableBeatUI(); //enable Beat UI and Beat collider from game manager
            gameManager.MakeDadShirtTransparent();
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
                gameManager.DisableBeatUI();
                passEventCondition = true;
            }

            //Debug.Log("Total Count: " + totalCount);

            if (!gameManager.rhythmController.GameStart) {
                countLoop = countLoop + 1;
                if (countLoop < loop)
                {
                   // Debug.Log("Count Loop " + countLoop);
                    gameManager.rhythmController.StartRhythm();
                }
                else {
                    gameManager.DisableBeatUI();
                    passEventCondition = true;
                }
            }

        }
        else
        {
            gameManager.DisableBeatUI();
            passEventCondition = true;
        }

    }

}
