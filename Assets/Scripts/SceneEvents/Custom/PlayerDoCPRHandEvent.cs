using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerDoCPRHandEvent", menuName = "SceneEvent/PlayerDoCPRHandEvent")]
public class PlayerDoCPRHandEvent : SceneEvent
{
    public string assetName;
    public string audioSourceAssetName; //name = Phone

    private Animator cprUIAnim;
    private Animator sitUIAnim;
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int clipIter;
    private float clipTime;
    private bool noMoreClips= false;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<Animator>(assetName, out cprUIAnim);
        Debug.Log("Found UI CPR[" + assetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<Animator>("SitUIAnim", out sitUIAnim);
        Debug.Log("Found UI CPR[" + assetName + "]: " + found);
        found = SceneAssetManager.GetAssetComponent<AudioSource>(audioSourceAssetName, out audioSource);
        Debug.Log("Found Phone[" + assetName + "]: " + found);

        clipIter = 0;
        clipTime = 0;

        if (audioSource == null && cprUIAnim == null && sitUIAnim == null)
        {
            passEventCondition = true;
        }

        if (audioSource != null && cprUIAnim != null && sitUIAnim != null)
        {
            cprUIAnim.SetBool("enable", false);
            sitUIAnim.SetBool("enable", false);
        }
    }

    public override void StartEvent()
    {
        InitEvent();
        if (audioSource != null && cprUIAnim != null && sitUIAnim != null)
        {
            //add debug here
            cprUIAnim.SetBool("enable", true);
            sitUIAnim.SetBool("enable", true);

            //add SPC sound here
            clipTime = PlayClip();
            clipIter++;
        }

        if (CPRHand.Instance == null && audioSource == null)
        {
            passEventCondition = true;
        }
        else {
            Player.Instance.cprHand.enabledSnap = true;
        }
    }

    public override void UpdateEvent()
    {
        if (CPRHand.Instance != null && CPRHand.Instance.snaping && noMoreClips)
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
            clipTime = PlayClip();
            clipIter++;
            passEventCondition = (clipTime <= 0);
        }

    }

    public override void StopEvent()
    {
        if (cprUIAnim != null && sitUIAnim != null)
        {
            cprUIAnim.SetBool("enable", false);
            sitUIAnim.SetBool("enable", false);
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
