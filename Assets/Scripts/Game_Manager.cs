using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public bool Musicstart;
    public AudioSource BeatMusic;
    public BeatController beatcontroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Musicstart)//OVRInput.Get(OVRInput.Button.Two)
        {
            //if(OVRInput.Get(OVRInput.Button.One))
            //{
                if (beatcontroller.CheckGoodHitBeat())
                {
                    Musicstart = true;
                    beatcontroller.Gamestart = true;
                    BeatMusic.Play();
                    Debug.Log("Work");
                } 
            //}

        }
      
    }

}
