using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioControl : MonoBehaviour
{
    #region Variable
    [Header("Game Object")]
    //[SerializeField] private int shotIndex;
    public GameObject handfulCanvas;
    public GameObject handpalmCanvas;
    public GameObject pointingCanvas;
    public GameObject doorCanvas;
    public GameObject phoneCanvas;
    public GameObject cprCanvas;
    public GameObject portal;
    public GameObject grim;

    [Header("Player")]
    public Player playerScript;
    public GameObject player;
    public float moveSpeed;

    [Header("Object")]
    public DoorKnob doorKnob;
    public GameObject phone;

    [Header("Position")]
    public Transform[] pos;

    [Header("Checker")]
    public float pointingTime = 2;
    public float pointingTimer;
    public bool pointingComplete;

    public float handfulTime = 2;
    public float handfulTimer;
    public bool handfulComplete;

    public float handpalmTime = 2;
    public float handpalmTimer;
    public bool handpalmComplete;

    public CutsceneEndCheck cutsceneCheck;
    float teleportTimer = 0;
    public float moveTimer = 0;
    public bool isMove;
    #endregion

    void Start()
    {

    }

    void Update()
    {
        //Peter Test vvvvv
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Debug when start playing CutScene1");
            RunCutScene1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Debug when start playing CutScene2");
            RunCutScene2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Debug when start playing GoodEnd");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Debug when start playing BadEnd");
        }
        //Peter Test ^^^^^

        #region Unused
        /*
        if (shotIndex == 1)
        {
            tutorialCanvas.SetBool("disable", true);
            doorlCanvas.gameObject.SetActive(true);
            MoveObjectAtoB(player, player.transform, pos[0], moveSpeed, 5);
        }
        else if (shotIndex == 2)
        {
            doorlCanvas.SetBool("disable", true);
            TeleportObjectAtoB(player, player.transform, pos[1], 1);
            portal.SetActive(true);
            grim.SetActive(true);
        }
        else if (shotIndex == 3)
        {
            MoveObjectAtoB(player, player.transform, pos[2], moveSpeed, 0);
        }
        */
        #endregion
        //manual[0] = OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Two);
        //manual[1] = OVRInput.Get(OVRInput.Button.Three) && OVRInput.Get(OVRInput.Button.Four);

       if (phone.GetComponent<Phone>().phoneIsPickedUp)
        {
            SnapObjectToHand(phone, phone.GetComponent<Phone>().hand);
        }

        if (!handfulComplete)//กำ
        {
            CheckHandFul();
            handfulCanvas.SetActive(true);
        }
        else if (handfulComplete  && !handpalmComplete)//แบ
        {
            CheckHandPalm();
            handfulCanvas.GetComponent<Animator>().SetBool("disable",true);
            handpalmCanvas.SetActive(true);
        }
        else if (handpalmComplete && !pointingComplete)//ชื้
        {
            CheckPointing();
            handpalmCanvas.GetComponent<Animator>().SetBool("disable", true);
            pointingCanvas.SetActive(true);
        }
        else if (pointingComplete && !doorKnob.doorOpen)//เดินไปประตู
        {
            playerScript.showController = false;
            pointingCanvas.GetComponent<Animator>().SetBool("disable", true);
            doorCanvas.SetActive(true);
            MoveObjectAtoB(player, player.transform, pos[0], moveSpeed, 3);
        }
        else if (doorKnob.doorOpen && !cutsceneCheck.cutsceneIsEnd)//เปิดประตู
        {
            //isMove = false;
            doorCanvas.GetComponent<Animator>().SetBool("disable", true);
            MoveObjectAtoB(player, player.transform, pos[1], moveSpeed, 1);
        }
        else if (cutsceneCheck.cutsceneIsEnd)
        {
            //isMove = false;
            MoveObjectAtoB(player, player.transform, pos[2], moveSpeed, 1);
        }
        /*else if (/*!manual[0] && manual[1])
        {
            //manual[1] = false;
            cprCanvas.SetActive(true);
        }*/

        //Cutscene Peter
    }

    //peter test zone
    void RunCutScene1()
    {
        SimpleDirectorController.Instance.PlayTrack(0);
    }
    void RunCutScene2()
    {
        SimpleDirectorController.Instance.PlayTrack(1);
    }
    void RunCutSceneGoodEnd()
    {

    }
    void RunCutSceneBadEnd()
    {

    }
    //Peter test zone


    public void MoveObjectAtoB(GameObject _object, Transform from, Transform to, float moveSpeed, float moveDelay)
    {
        if (_object == null)
        {
            _object = GameObject.FindGameObjectWithTag("Player");
        }
        if (from == null)
        {
            from = _object.transform;
        }

        if ((moveTimer < moveDelay) && !isMove)
        {
            moveTimer += Time.deltaTime;
        }
        else if (moveTimer >= moveDelay)
        {
            isMove = true;
            moveTimer = 0;
        }

        if (isMove)
        {

            to.position = new Vector3(to.position.x, _object.transform.position.y, to.position.z);
            _object.transform.position = Vector3.Lerp(from.position, to.position, moveSpeed);

        }

        if (_object.transform.position == to.position)
        {
            isMove = false;
        }


        Debug.Log("move pass");
    }

    public void TeleportObjectAtoB(GameObject _object, Transform from, Transform to, float teleportDelay)
    {

        if (_object == null)
        {
            _object = GameObject.FindGameObjectWithTag("Player");
        }
        if (from == null)
        {
            from = _object.transform;
        }

        if (teleportTimer < teleportDelay)
        {
            teleportTimer += Time.deltaTime;
        }
        else
        {
            teleportTimer = 0;
            to.position = new Vector3(to.position.x, _object.transform.position.y, to.position.z);
            _object.transform.position = to.transform.position;
        }
        Debug.Log("teleport pass");
    }

    private void CheckPointing()
    {
        if ((playerScript.l_isPointing && playerScript.r_isPointing) && pointingTimer < pointingTime)
        {
            pointingTimer += Time.deltaTime;
        }
        else if (pointingTimer >= pointingTime)
        {
            pointingTimer = 0;
            pointingComplete = true;
        }
    }

    private void CheckHandFul()
    {
        if (playerScript == null) return;
        if ((playerScript.l_ful && playerScript.l_ful) && handfulTimer < handfulTime)
        {
            handfulTimer += Time.deltaTime;
        }
        else if (handfulTimer >= handfulTime)
        {
            handfulTimer = 0;
            handfulComplete = true;
        }
    }

    private void CheckHandPalm()
    {
        if ((playerScript.l_palm && playerScript.r_palm) && handpalmTimer < handpalmTime)
        {
            handpalmTimer += Time.deltaTime;
        }
        else if (handpalmTimer >= handpalmTime)
        {
            handpalmTimer = 0;
            handpalmComplete = true;
        }
    }

    private void SnapHandToObject(GameObject _object, GameObject hand)
    {
        hand.transform.position = _object.transform.position;
    }

    private void SnapObjectToHand(GameObject _object, GameObject hand)
    {
        _object.transform.position = hand.transform.position;
    }
}
