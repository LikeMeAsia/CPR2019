using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerDoCPRHandEvent", menuName = "SceneEvent/PlayerDoCPRHandEvent")]
public class PlayerDoCPRHandEvent : SceneEvent
{
    public string assetName;
    public string audioSourceAssetName; //name = Phone

    private Animator cprUIAnim;
    //private Animator sitUIAnim;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    private int clipIter;
    private float clipTime;
    private bool noMoreClips= false;
    private TouchChestCollider touchChestCollider;
    private bool touchFatherChest;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<Animator>(assetName, out cprUIAnim);
        Debug.Log("Found UI CPR[" + assetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<AudioSource>(audioSourceAssetName, out audioSource);
        Debug.Log("Found Phone[" + audioSourceAssetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<TouchChestCollider>("ChestCollider", out touchChestCollider);
        Debug.Log("Found chest collider script[" + "ChestCollider" + "]: " + found);


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
        touchFatherChest = touchChestCollider.touchFatherChest;
        if (audioSource != null && cprUIAnim != null )
        {
            //add debug here
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
        if (CPRHand.Instance != null && CPRHand.Instance.snaping && noMoreClips && touchFatherChest) //and animation finishes too
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
            if(audioSource.isPlaying == false)
            {
                clipTime = PlayClip();
                clipIter++;
            }

            passEventCondition = (clipTime <= 0);
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
        if (audioSource == null || clipIter < 0 || clipIter > audioClips.Length -1)
        {
            noMoreClips = true;
            return 0f;
        }
        audioSource.Stop();
        audioSource.clip = audioClips[clipIter];
        audioSource.Play();

        return audioClips[clipIter].length + 0.5f;
    }

    public override bool Skip()
    {
        passEventCondition = true;

        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
        clipIter = audioClips.Length;
        clipTime = 0;

        return true;
    }
}
