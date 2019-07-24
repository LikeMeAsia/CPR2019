﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioControl : MonoBehaviour
{
    private static ScenarioControl instance;
    public static ScenarioControl Instance { get { return instance; } }

    public void Awake()
    {
        instance = this;
    }

    #region Variable
    [Header("Game Object")]
    //[SerializeField] private int shotIndex;
    public GameObject handfulCanvas;
    public GameObject handpalmCanvas;
    public GameObject pointingCanvas;
    public GameObject doorCanvas;
    public GameObject phoneCanvas;
    public GameObject cprCanvas;

    public float moveSpeed;

    [Header("Object")]
    public DoorKnob doorKnob;
    public GameObject phone;

    [Header("Position")]
    public Transform[] pos;

    [Header("Checker")]

    public float handfulTime = 2;
    public float handfulTimer;
    public bool handfulComplete;

    public float handpalmTime = 2;
    public float handpalmTimer;
    public bool handpalmComplete;

    public float pointingTime = 2;
    public float pointingTimer;
    public bool pointingComplete;

    public bool moveToDoorComplete;
    public bool openDoorComplete;
    public bool cutscene1Complete;
    public bool cutscene2Complete;

    [Header(" ")]
    public SnapHand snapHand;
    public CutsceneEndCheck cutsceneCheck;
    float teleportTimer = 0;
    float moveDelay = 0;
    public float moveTimer = 0;
    public bool isMove;
    Vector3 toPos = Vector3.zero;
    public GameObject checkpt;
    #endregion

    void Start()
    {

        //shotIndex = 0;
        //playerAnim.SetTrigger("fade in");
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

        if (isMove)
        {
            moveTimer += Time.deltaTime;
            if (moveTimer >= moveDelay)
            {
                Player.Instance.transform.position = Vector3.Lerp(Player.Instance.m_OvrCamera.transform.position, toPos, Mathf.Clamp01(moveSpeed * (moveTimer - moveDelay)));
            }
            if (Player.Instance.m_OvrCamera.transform.position == toPos)
            {
                moveTimer = 0;
                isMove = false;
            }
        }
        else if (!handfulComplete)//กำ
        {
            CheckHandFul();
            Player.Instance.EnableOutlineHandFul();
            handfulCanvas.SetActive(true);
        }
        else if (handfulComplete && !handpalmComplete)//แบ
        {
            CheckHandPalm();
            Player.Instance.EnableOutlineBareHands();
            handfulCanvas.GetComponent<Animator>().SetBool("disable", true);
            handpalmCanvas.SetActive(true);
        }
        else if (handpalmComplete && !pointingComplete)//ชื้
        {
            CheckPointing();
            Player.Instance.EnableOutlinePointing();
            handpalmCanvas.GetComponent<Animator>().SetBool("disable", true);
            pointingCanvas.SetActive(true);
        }
        else if (handfulComplete && handpalmComplete && pointingComplete && !moveToDoorComplete)//เดินไปประตู
        {
            moveToDoorComplete = true;
            Player.Instance.EnableOutlineBareHands();
            Player.Instance.showController = false;
            pointingCanvas.GetComponent<Animator>().SetBool("disable", true);
            doorCanvas.SetActive(true);
            MovePlayertoArea(pos[0], moveSpeed, 3);
        } else if (openDoorComplete && !doorKnob.doorOpen) {
            doorKnob.OpenDoor();
        }
        else if (doorKnob.doorOpen && !cutscene1Complete)//เปิดประตู
        {
            cutscene1Complete = true;
            openDoorComplete = true;
            doorCanvas.GetComponent<Animator>().SetBool("disable", true);
            MovePlayertoArea(pos[1], moveSpeed, 3);
        }
        else if (cutsceneCheck.cutsceneIsEnd && !cutscene2Complete)//เดินไปหาพ่อ
        {
            cutscene2Complete = true;
            MovePlayertoArea(pos[2], moveSpeed, 1);
        }

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


    public void MovePlayertoArea(Transform to, float moveSpeed, float imoveDelay)
    {
        moveDelay = imoveDelay;
        toPos = Vector3.zero;
        bool configured = OVRManager.boundary.GetConfigured();
        if (configured)
        {
            Vector3[] boundaryPoints = OVRManager.boundary.GetGeometry(OVRBoundary.BoundaryType.PlayArea);
            BoxCollider box = to.GetComponentInChildren<BoxCollider>();
            if (box != null)
            {
                /*Vector3 nearestPt = Vector3.zero;
                Vector3 closestBoundPt = Vector3.zero;
                float dist = 0;
                foreach (Vector3 boundaryPoint in boundaryPoints)
                {
                    if (box.bounds.SqrDistance(boundaryPoint) > dist)
                    {
                        nearestPt = boundaryPoint;
                        closestBoundPt = box.bounds.ClosestPoint(boundaryPoint);
                    }
                }*/
                toPos = to.position;
                toPos = new Vector3(toPos.x, Player.Instance.transform.position.y, toPos.z);
            }
        }
        else {
            toPos = new Vector3(to.position.x, Player.Instance.transform.position.y, to.position.z);
        }
        checkpt.transform.position = toPos;
        isMove = true;
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
    }

    private void CheckPointing()
    {
        if ((Player.Instance.l_isPointing && Player.Instance.r_isPointing) && pointingTimer < pointingTime)
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
        if (Player.Instance == null) return;
        if ((Player.Instance.l_ful && Player.Instance.l_ful) && handfulTimer < handfulTime)
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
        if ((Player.Instance.l_palm && Player.Instance.r_palm) && handpalmTimer < handpalmTime)
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
