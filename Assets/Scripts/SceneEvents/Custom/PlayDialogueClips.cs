using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayDialogueClips", menuName = "SceneEvent/PlayDialogueClips")]
public class PlayDialogueClips : SceneEvent
{
    public string audioSourceAssetName;
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int clipIter;
    private float clipTime;

    public override void InitEvent()
    {
        base.InitEvent();
        clipIter = 0;
        clipTime = 0;
        bool found = SceneAssetManager.GetAssetComponent<AudioSource>(audioSourceAssetName, out audioSource);
        Debug.Log("Found Phone[" + audioSourceAssetName + "]: " + found);
    }

    public override void StartEvent()
    {
        InitEvent();
        if (audioSource == null)
        {
            passEventCondition = true;
        }
    }
    public override void UpdateEvent()
    {
        if (clipTime > 0)
        {
            clipTime -= Time.deltaTime;
            return;
        }
        else if(!passEventCondition)
        {
            clipTime = PlayClip();
            clipIter++;
            passEventCondition = clipTime <= 0;
        }
    }
    public override void StopEvent()
    {
        if (audioSource == null) return;
        audioSource.Stop();
        audioSource.clip = null;
        
    }
    public override void Skip()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
        clipIter = audioClips.Length;
        clipTime = 0;
    }

    private float PlayClip() {
        if (audioSource == null || clipIter< 0 || clipIter >= audioClips.Length) {
            return 0f;
        }
        audioSource.Stop();
        audioSource.clip = audioClips[clipIter];
        audioSource.Play();
        return audioClips[clipIter].length +0.5f;
    }
}
