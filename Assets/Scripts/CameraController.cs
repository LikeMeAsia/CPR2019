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

    public CutsceneEndCheck cutsceneCheck;
   // public ScenarioControl scenarioCheck;
    public BeatController GamestartCheck;


    void Start()
    {
        x = 1;
        cameraPlayer.transform.SetParent(cameraPos[x-1]);
        cameraPlayer.transform.localPosition = Vector3.zero;
        cameraPlayer.transform.localRotation = Quaternion.identity;
    }
    void Update()
    {

        if (cutsceneCheck.cutsceneIsEnd )
        {

         //   currenView = views[0];
            x = 2;
            cameraPlayer.transform.SetParent(cameraPos[x - 1]);
            cameraPlayer.transform.localPosition = Vector3.zero;
            cameraPlayer.transform.localRotation = Quaternion.identity;
        }
        else if ( x == 2 && GamestartCheck.Gamestart)
        {
            x = 3;
            cameraPlayer.transform.SetParent(cameraPos[x - 1]);
            cameraPlayer.transform.localPosition = Vector3.zero;
            cameraPlayer.transform.localRotation = Quaternion.identity;
        }

        
     }

     /* void LateUpdate()
     {
         transform.position = Vector3.Lerp(transform.position, currenView.position, Time.deltaTime * transitionSpeed);

        Vector3 currntAngle = new Vector3
            (
                Mathf.LerpAngle(transform.rotation.eulerAngles.x, currenView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.y, currenView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.z, currenView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
            );
         transform.eulerAngles = currntAngle;
     }*/

    /* void Start()
     {
         camera1.enabled = true;
         cameraPlayer2.enabled = false;
         currenView = views[0];
         x = 1;
     }
     void Update()
     {

         if (cutsceneCheck.cutsceneIsEnd&&x==1)
         {
             camera1.enabled = false;
             cameraPlayer2.enabled = true;
             cameraPlayer2.transform.position = views[1].transform.position;
             x = 2;

         }
         else if (Shoulder==false&&x==2)
         {
             currenView = views[2];
         }

        /* if(GamestartCheck.Gamestart&&x==2)
         {
             currenView = views[1];
         }
     }

      void LateUpdate()
     {
         transform.position = Vector3.Lerp(transform.position, currenView.position, Time.deltaTime * transitionSpeed);

         Vector3 currntAngle = new Vector3
             (
                 Mathf.LerpAngle(transform.rotation.eulerAngles.x, cameraPlayer2.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
                 Mathf.LerpAngle(transform.rotation.eulerAngles.y, cameraPlayer2.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
                 Mathf.LerpAngle(transform.rotation.eulerAngles.z, cameraPlayer2.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
             );
         transform.eulerAngles = currntAngle;
     }*/









        /* [Header("Camera")]
         public Camera camera1;
         public Camera camera2;

         public CutsceneEndCheck cutsceneCheck;
         // Start is called before the first frame update
         void Start()
         {
             camera1.enabled = true;
             camera2.enabled = false;
         }

         // Update is called once per frame
         void Update()
         {
             if (cutsceneCheck.cutsceneIsEnd)
             {
                 //isMove = false;
                 //phoneCanvas.GetComponent<Animator>().SetBool("disable", true);
                 //MoveObjectAtoB(player, player.transform, pos[2], moveSpeed, 1);
                 camera1.enabled = false;
                 camera2.enabled = true;
             }
         }*/
    }
