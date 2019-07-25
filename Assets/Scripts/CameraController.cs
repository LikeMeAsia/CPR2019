using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Camera cameraPlayer;
    public Transform[] cameraPos;
   
   // public Transform[] views;
   // public GameObject Shoulder;
    
    Transform currenView;
    int x;
    
    public BeatController GamestartCheck;


    void Start()
    {
        x = 0;
    }
    void Update()
    {

        if (x == 0 && ScenarioControl.Instance.cutscene1Complete)
        {

         //   currenView = views[0];
            x = 1;
        }
        else if ( x == 1 && GamestartCheck.Gamestart)
        {
            x = 2;
        }

        cameraPlayer.transform.position = cameraPos[x].transform.position;
        cameraPlayer.transform.rotation = cameraPos[x].transform.rotation;
    }
}
