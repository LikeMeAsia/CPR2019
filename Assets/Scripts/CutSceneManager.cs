using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
    public PlayableDirector cutScene1;
    public PlayableDirector cutScene2;
    public PlayableDirector cutSceneG;
    public PlayableDirector cutSceneB;

    public static bool playCs1;
    public static bool playCs2;
    public static bool playCsG;
    public static bool playCsB;
    // Start is called before the first frame update
    void Start()
    {
        playCs1 = false;
        playCs2 = false;
        playCsG = false;
        playCsB = false;

        cutScene1.Stop();
        /*cutScene2.Stop();

        cutSceneG.Stop();
        cutSceneB.Stop();*/
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
    }
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (cutScene1 == aDirector)
        {
            Debug.Log("cs1 is now Stopped");
        }
        
    }
    private void OnEnable()
    {
        cutScene1.stopped += OnPlayableDirectorStopped;
    }
    private void OnDisable()
    {
        cutScene1.stopped -= OnPlayableDirectorStopped;
    }
    
}
