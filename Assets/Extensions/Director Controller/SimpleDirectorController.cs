using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

[RequireComponent(typeof(PlayableDirector))]
public class SimpleDirectorController : MonoBehaviour {
    [System.Serializable]
    public class CustomTimelineAsset {
        public PlayableAsset EventPlayableAsset;
        [Tooltip("For only Event Playable Asset in case no Transaction Playable Asset.")]
        public DirectorWrapMode EventWrapMode;
        [Tooltip("Playable Asset that play after Event Playable as Loop mode.")]
        public PlayableAsset TransactionPlayableAsset;
        public UnityEvent BeforePlayEvent;
        public UnityEvent AfterPlayEvent;
        public bool playNext;
    }

    private static SimpleDirectorController mInstance;
    public static SimpleDirectorController Instance { get { return mInstance; } }

    public int trackId;
    [LabelArray("EventPlayableAsset", LabelArrayAttribute.LabelType.FieldName)]
    public CustomTimelineAsset[] tracks;

    private PlayableDirector director;
    private bool interruptable;
    public bool Interruptable {
        get { return interruptable; }
    }
    [ReadOnly]
    public bool pause;
    public bool playOnAwake;

    void Awake()
    {
        mInstance = this;
        pause = false;
    }

    // Use this for initialization
    void Start() {
        director = GetComponent<PlayableDirector>();
#if !UNITY_EDITOR
        trackId = 0;
#endif
        if (playOnAwake) {
            PlayTrack(trackId);
        }
    }

    public void ReplayTrack()
    {
        PlayTrack(trackId);
    }

	public void PlayTrack(int iTrack){
		if (!interruptable && (iTrack < 0 || iTrack >= tracks.Length))
        {
            return;
        }
        trackId = iTrack;
        StartCoroutine (IPlayTrack());
	}

	public void PlayNextTrack(){
		if (!interruptable)
			return;
        if (trackId+1 >= tracks.Length)
        {
            return;
        }
        trackId++;
        StartCoroutine (IPlayTrack());
	}


    IEnumerator IPlayTrack(){
		interruptable = false;
        if (tracks[trackId].BeforePlayEvent != null){
			tracks [trackId].BeforePlayEvent.Invoke ();
		}
        if (director.playableAsset!=null && trackId > 1 && tracks[trackId-1].TransactionPlayableAsset == director.playableAsset) {
            director.extrapolationMode = DirectorWrapMode.Hold;
            yield return new WaitUntil(() => director.time >= director.playableAsset.duration);
        }
        SetupPlayTrack(tracks[trackId].EventPlayableAsset, tracks[trackId].EventWrapMode);
		yield return new WaitUntil(() => director.time >= director.playableAsset.duration);
		interruptable = true;
        if (tracks[trackId].TransactionPlayableAsset != null)
        {
            SetupPlayTrack(tracks[trackId].TransactionPlayableAsset, DirectorWrapMode.Loop);
        }
        else {
            director.Stop();
            director.playableAsset = null;
        }
        if (tracks[trackId].AfterPlayEvent != null){
			tracks [trackId].AfterPlayEvent.Invoke ();
		}
        if (tracks[trackId].playNext) {
            PlayNextTrack();
        }
    }

    public void SetupPlayTrack(PlayableAsset playableAsset, DirectorWrapMode wrapMode){
		director.Stop();
        director.playableAsset = playableAsset;
		director.extrapolationMode = wrapMode;
		director.time = 0f; //director.playableAsset.duration - 0.01f;
		director.Evaluate();
		director.Play ();
    }

    public void SkipAllTracks() {
        director.Stop();
        trackId = tracks.Length - 1;
        SkipToEndTrack();
    }

    public void SkipToEndTrack() {
        director.Stop();
        if (tracks[trackId].TransactionPlayableAsset != null)
        {
            SetupPlayTrack(tracks[trackId].TransactionPlayableAsset, DirectorWrapMode.Loop);
        }
        else
        {
            director.playableAsset = tracks[trackId].EventPlayableAsset;
            director.extrapolationMode = tracks[trackId].EventWrapMode;
            director.time = tracks[trackId].EventPlayableAsset.duration - 0.1f;
            director.Evaluate();
            director.Play();
        }
        if (tracks[trackId].AfterPlayEvent != null)
        {
            tracks[trackId].AfterPlayEvent.Invoke();
        }
        interruptable = true;
    }

    public void SkipTrack()
    {
        director.Stop();
        interruptable = true;
        PlayNextTrack();
    }
}
