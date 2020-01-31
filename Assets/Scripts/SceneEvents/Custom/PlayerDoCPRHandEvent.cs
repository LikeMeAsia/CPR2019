using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerDoCPRHandEvent", menuName = "SceneEvent/PlayerDoCPRHandEvent")]
public class PlayerDoCPRHandEvent : SceneEvent
{
    public string assetName;
    public string audioSourceAssetName; //name = Phone

    private Animator cprUIAnim;
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int clipIter;
    private float clipTime;
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
        touchFatherChest = false;
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
        }
        else
        {
            Player.Instance.cprHand.enabledSnap = true;
        }
    }

    public override void UpdateEvent()
    {
        if (CPRHand.Instance != null && CPRHand.Instance.snaping && touchFatherChest && !IsAudioClipPlayable()) //and animation finishes too
        {
            passEventCondition = true;
        }

        if (clipTime > 0)
        {
            clipTime -= Time.deltaTime;
            return;
        }
        else if (!passEventCondition)
        {
            if(audioSource.isPlaying == false && IsAudioClipPlayable())
            {
                clipTime = PlayClip();
                clipIter++;
            }
            touchFatherChest = touchChestCollider.touchFatherChest;
        }

    }

    public override void StopEvent()
    {
        if (cprUIAnim != null)
        {
            cprUIAnim.SetBool("enable", false);
            cprUIAnim.SetTrigger("action");
        }

        if (audioSource == null) return;
        audioSource.Stop();
        audioSource.clip = null;
    }

    private float PlayClip()
    {
        if (audioSource == null || !IsAudioClipPlayable())
        {
            return 0f;
        }
        audioSource.Stop();
        audioSource.clip = audioClips[clipIter];
        audioSource.Play();
        return audioClips[clipIter].length + 0.5f;
    }

    private bool IsAudioClipPlayable() {
        return clipIter >= 0 && clipIter < audioClips.Length;
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
