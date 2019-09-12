using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerDoCPRHandEvent", menuName = "SceneEvent/PlayerDoCPRHandEvent")]
public class PlayerDoCPRHandEvent : SceneEvent
{
    public string assetName;
    public string audioSourceAssetName; //name = Phone

    private Animator cprUIAnim;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    private int clipIter;
    private float clipTime;
    private bool noMoreClips = false;
    private TouchChestCollider touchChestCollider;
    private bool touchFatherChest;
    private Game_Manager gameManager;
    private bool skip;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<Animator>(assetName, out cprUIAnim);
        Debug.Log("Found UI CPR[" + assetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<AudioSource>(audioSourceAssetName, out audioSource);
        Debug.Log("Found Phone[" + audioSourceAssetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<TouchChestCollider>("ChestCollider", out touchChestCollider);
        Debug.Log("Found chest collider script[" + "ChestCollider" + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<Game_Manager>("GameManager", out gameManager);
        Debug.Log("Found Game_Manager[" + "GameManager" + "]: " + found);


        clipIter = 0;
        clipTime = 0;

        if (audioSource == null && cprUIAnim == null )
        {
            passEventCondition = true;
        }

        if (audioSource != null && cprUIAnim != null )
        {
            cprUIAnim.SetBool("enable", false);
        }
    }

    public override void StartEvent()
    {
        InitEvent();
        noMoreClips = false;
        gameManager.MakeDadShirtTransparent();
        gameManager.EnableBeatUI();
        gameManager.CallSetBeatColliderEnabled(false);

        if (audioSource != null && cprUIAnim != null )
        {
            cprUIAnim.SetBool("enable", true);

            clipTime = PlayClip();  //add SPC sound here
            clipIter++;
        }

        if (CPRHand.Instance == null && audioSource == null&& touchChestCollider == null)
        {
            passEventCondition = true;
            Debug.Log("passEvent here");
        }
        else
        {
            Player.Instance.cprHand.enabledSnap = true;
        }

     
    }

    public override void UpdateEvent()
    {
        if (CPRHand.Instance != null && CPRHand.Instance.snaping && noMoreClips && touchFatherChest) //and animation finishes too
        {
            passEventCondition = true;
            Debug.Log("touchChestCollider"+touchChestCollider + "pass event already"+clipIter+"clipIter" + audioClips.Length+"audioclip.length MINUS 1"+noMoreClips+"nomoreclips");
        }

        if (clipTime > 0)
        {
            clipTime -= Time.deltaTime;
            return;
        }
        else if (!passEventCondition)
        {
            if(audioSource.isPlaying == false)
            {
                clipTime = PlayClip();
                clipIter++;
            }
            touchFatherChest = touchChestCollider.touchFatherChest;
        }

        if(clipIter==2)
        {
            cprUIAnim.SetTrigger("StartPump");
            Debug.Log("startToPump?");
        }
    }

    public override void StopEvent()
    {
        if (cprUIAnim != null)
        {
            cprUIAnim.SetBool("enable", false);
        }

        if (audioSource == null) return;
        audioSource.Stop();
        audioSource.clip = null;
    }

    private float PlayClip()
    {
        Debug.Log("playClip");
        if (audioSource == null || clipIter < 0 || clipIter > audioClips.Length)
        {
            return 0f;
        }
        if (clipIter > audioClips.Length - 1)
        {
            Debug.Log("clipIter more than audioClipLength" + clipIter + "clipIter" + audioClips.Length + "audioClips.length");
            noMoreClips = true;
            Debug.Log("nomoreclips"+noMoreClips);
        }
        audioSource.Stop();
        audioSource.clip = audioClips[clipIter];
        audioSource.Play();

        return audioClips[clipIter].length + 0.5f;
    }

    public override bool Skip()
    {
        skip = true;
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
        if (cprUIAnim != null)
        {
            Debug.Log("cpr mai null");
            cprUIAnim.SetBool("enable", false);
        }
        clipIter = audioClips.Length;
        clipTime = 0;
        passEventCondition = true;

        return skip;
    }
}
