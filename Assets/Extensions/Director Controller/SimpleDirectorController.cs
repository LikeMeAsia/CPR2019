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
        interruptable = true;
        if (playOnAwake) {
            PlayTrack(trackId);
        }
    }

    //Test Playing Custom Timeline manually by keyboard input (1 2 3 and 4)
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            trackId = 0;
            PlayTrack(trackId);
            Debug.Log("Test manual playing cutscene 1");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            trackId = 1;
            PlayTrack(trackId);
            Debug.Log("Test manual playing cutscene 2");
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Test manual playing cutscene GoodEnd");
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Debug.Log("Test manual playing cutscene BadEnd");
        }
    }
    public void ReplayTrack()
    {
        PlayTrack(trackId);
    }

	public void PlayTrack(int iTrack){
        if (director == null) {
            Debug.Log("SimpleDirectorController: Director not found");
            return;
        }
        if (iTrack < 0 || iTrack >= tracks.Length)
        {
            Debug.Log("SimpleDirectorController: Track ID not in range ["+ iTrack + "]");
            return;
        }
        if (tracks[iTrack] == null)
        {
            Debug.Log("SimpleDirectorController: No track in this ID");
            return;
        }
        Debug.Log("SimpleDirectorController: PlayTrack [" + tracks[iTrack].EventPlayableAsset.name + "]");
        StartCoroutine (IPlayTrack(iTrack));
	}

	public void PlayNextTrack(){
        if (trackId+1 >= tracks.Length)
        {
            return;
        }
        StartCoroutine (IPlayTrack(trackId + 1));
	}


    IEnumerator IPlayTrack(int nextTrack){
        if (!interruptable) {
            yield return new WaitUntil(() => interruptable);
        }
		interruptable = false;
        trackId = nextTrack;
        if (tracks[trackId].BeforePlayEvent != null){
			tracks [trackId].BeforePlayEvent.Invoke ();
		}
        if (director.playableAsset != null && trackId > 1 && tracks[trackId - 1].TransactionPlayableAsset == director.playableAsset)
        {
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
