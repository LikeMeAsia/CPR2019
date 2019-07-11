using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
    public PlayableDirector cutScene1;
    public PlayableDirector cutScene2;
    public PlayableDirector cutSceneGoodEnd;
    public PlayableDirector cutSceneBadEnd;

    public static bool playCs1;
    public static bool playCs2;
    public static bool playCsGoodEnd;
    public static bool playCsBadEnd;
    // Start is called before the first frame update
    void Start()
    {
        cutScene1.Stop();
        cutScene2.Stop();/*
        cutSceneGoodEnd.Stop();
        cutSceneBadEnd.Stop();*/

        playCs1 = false;
        playCs2 = false;
        playCsGoodEnd = false;
        playCsBadEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playCs1)
        {
            playCs1 = false;
            SimpleDirectorController.Instance.PlayTrack(0);
            //cutScene1.Play();
            Debug.Log("Playing Cutscene Father down");
        }
        if (playCs2)
        {
            playCs2 = false;
            cutScene2.Play();
        }
    }

    //Detect when stopped playing
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (cutScene1 == aDirector)
        {
            Debug.Log("Debug when CutScene 1 is now stopped.");
        }
        if (cutScene2 == aDirector)
        {
            Debug.Log("Debug when CutScene 2 is now stopped.");
        }
    }
    void OnEnable()
    {
        cutScene1.stopped += OnPlayableDirectorStopped;
        cutScene2.stopped += OnPlayableDirectorStopped;
    }
    void OnDisable()
    {
        cutScene1.stopped -= OnPlayableDirectorStopped;
        cutScene2.stopped -= OnPlayableDirectorStopped;
    }
}
