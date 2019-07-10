using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer mInstance;
    public static AudioPlayer Instance
    {
        get
        {
            if (mInstance == null && Camera.main != null) {
                mInstance = Camera.main.GetComponent<AudioPlayer>();
                if (mInstance == null) {
                    mInstance = Camera.main.gameObject.AddComponent<AudioPlayer>();
                }
            }
            return mInstance;
        }
    }

    private AudioSource audioSrc;

    private void Awake()
    {
        if (mInstance == null)
        {
            mInstance = this;
        }
    }

    private void Start()
    {
        GetAudioSourceFromMainCamera();
    }

    private void OnEnable()
    {
        GetAudioSourceFromMainCamera();
    }

    private void GetAudioSourceFromMainCamera() {
        if (audioSrc != null || Camera.main == null) return;
        audioSrc = Camera.main.GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            audioSrc = Camera.main.gameObject.AddComponent<AudioSource>();
        }
    }

    public static void PlayAudioClip(AudioClip clip, bool Overlappable = false)
    {
        if (clip == null || AudioPlayer.Instance.audioSrc == null) return;
        if (!Overlappable) {
            AudioPlayer.Instance.audioSrc.Stop();
        }
        AudioPlayer.Instance.audioSrc.PlayOneShot(clip);
    }

    public static void Stop()
    {
        if (AudioPlayer.Instance.audioSrc == null) return;
        if(AudioPlayer.Instance.audioSrc.isPlaying)
            AudioPlayer.Instance.audioSrc.Stop();
    }
}
