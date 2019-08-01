using System.Collections;
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
    public Animator handTutorialAnim;
    public GameObject handCanvas;
    public GameObject doorCanvas;
    public GameObject phoneCanvas;
    public GameObject cprCanvas;
    public GameObject sitCanvas;
    public GameObject shoulderCanvas;
    public GameObject warningCanvas;

    public Image timerBar;

    public float moveSpeed;

    [Header("Object")]
    public DoorKnob doorKnob;
    public Area_check phone;

    [Header("Position")]
    public Transform[] pos;

    [Header("Checker")]

    public float handfulTime = 4;
    public float handfulTimer;
    public bool handfulComplete;

    public float handpalmTime = 4;
    public float handpalmTimer;
    public bool handpalmComplete;

    public float pointingTime = 4;
    public float pointingTimer;
    public bool pointingComplete;

    public bool openDoorComplete;
    public bool cutscene1Complete;

    [Header(" ")]
    float teleportTimer = 0;
    float moveDelay = 0;
    public float moveTimer = 0;
    public bool isMove;
    Vector3 toPos = Vector3.zero;
    public GameObject checkpt;

    public int procIter;
    public bool callNextProc;
    public float delayCallNextProc;

    #endregion

    void Start()
    {
        handfulComplete = false;
        handpalmComplete = false;
        pointingComplete = false;
        openDoorComplete = false;
        cutscene1Complete = false;
        procIter = 0;
        callNextProc = true;
        delayCallNextProc = 2f;
        phone.SetKinematic(true);
    }

    void Update()
    {
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

        if (callNextProc) {
            if (delayCallNextProc <=0) {
                callNextProc = false;
                NextProcess();
            }
            delayCallNextProc -= Time.deltaTime;
        }
        UpdateProcess();

       /* if (!handfulComplete)//กำ
        {
            CheckHandFul();
            Player.Instance.EnableOutlineHandFul();
            //handfulCanvas.SetActive(true);
        }
        else if (handfulComplete && !handpalmComplete)//แบ
        {
            handTutorialAnim.SetInteger("type", 1);
            handTutorialAnim.SetBool("disable", false);
            CheckHandPalm();
            Player.Instance.EnableOutlineBareHands();
            //handfulCanvas.GetComponent<Animator>().SetBool("disable", true);
            //handpalmCanvas.SetActive(true);
        }
        else if (handpalmComplete && !pointingComplete)//ชื้
        {
            handTutorialAnim.SetInteger("type", 2);
            handTutorialAnim.SetBool("disable", false);
            CheckPointing();
            Player.Instance.EnableOutlinePointing();
           // handpalmCanvas.GetComponent<Animator>().SetBool("disable", true);
            //pointingCanvas.SetActive(true);
        }
        else if (handfulComplete && handpalmComplete && pointingComplete && !moveToDoorComplete)//เดินไปประตู
        {
            moveToDoorComplete = true;
            Player.Instance.EnableOutlineBareHands();
            Player.Instance.showController = false;
           // pointingCanvas.GetComponent<Animator>().SetBool("disable", true);
            doorCanvas.SetActive(true);
            MovePlayertoArea(pos[0], moveSpeed, 3);
        } else if (!doorKnob.doorOpen && openDoorComplete) {
            doorKnob.OpenDoor();
            openDoorComplete = true;
            //RunCutScene1();
            doorCanvas.GetComponent<Animator>().SetBool("disable", true);
            MovePlayertoArea(pos[1], moveSpeed, 3);
        }
        else if (doorKnob.doorOpen && !openDoorComplete)//เปิดประตู
        {
            openDoorComplete = true;
            //RunCutScene1();
            doorCanvas.GetComponent<Animator>().SetBool("disable", true);
            MovePlayertoArea(pos[1], moveSpeed, 3);
        }
        else if (openDoorComplete && cutscene1Complete && !toFather)//เดินไปหาพ่อ
        {
            toFather = true;
            MovePlayertoArea(pos[2], moveSpeed, 1);
        }

        TimerBar();*/

    }



    public void NextProcess()
    {
        procIter = procIter + 1;
        switch (procIter)
        {
            case 1: // prepare player do handful
                handfulTimer = 0;
                timerBar.fillAmount = 0;
                handTutorialAnim.SetInteger("type", 0);
                handTutorialAnim.SetBool("disable", false);
                Player.Instance.EnableOutlineHandFul();
                break;
            case 2: // prepare player do bare hand
                handpalmTimer = 0;
                timerBar.fillAmount = 0;
                handTutorialAnim.SetInteger("type", 1);
                handTutorialAnim.SetBool("disable", false);
                Player.Instance.EnableOutlineBareHands();
                break;
            case 3: // prepare player do pointing
                pointingTimer = 0;
                timerBar.fillAmount = 0;
                handTutorialAnim.SetInteger("type", 2);
                handTutorialAnim.SetBool("disable", false);
                Player.Instance.EnableOutlinePointing();
                break;
            case 4: // player move to door
                Player.Instance.EnableOutlineBareHands();
                Player.Instance.showController = false;
                doorCanvas.SetActive(true);
                MovePlayertoArea(pos[0], moveSpeed, 3);
                break;
            case 5: // move player and play cutscene 1
                doorCanvas.GetComponent<Animator>().SetBool("disable", true);
                MovePlayertoArea(pos[1], moveSpeed, 3);
                break;
            case 6: // move to father
                MovePlayertoArea(pos[2], moveSpeed, 1);
                break;
        }
    }

    public void UpdateProcess() {
        if (callNextProc) {
            return;
        }
        switch (procIter)
        {
            case 1: // check player do handful
                if (CheckHandFul()) {
                    handTutorialAnim.SetInteger("type", 1);
                    handTutorialAnim.SetBool("disable", true);
                    handTutorialAnim.SetBool("action", false);
                    callNextProc = true;
                    delayCallNextProc = 2f;
                }
                break;
            case 2: // check player do bare hand
                if (CheckHandPalm())
                {
                    handTutorialAnim.SetInteger("type", 2);
                    handTutorialAnim.SetBool("disable", true);
                    handTutorialAnim.SetBool("action", false);
                    callNextProc = true;
                    delayCallNextProc = 2f;
                }
                break;
            case 3: // check player do pointing
                if (CheckPointing())
                {
                    handTutorialAnim.SetInteger("type", 3);
                    handTutorialAnim.SetBool("disable", true);
                    handTutorialAnim.SetBool("action", false);
                    callNextProc = true;
                    delayCallNextProc = 0f;
                }
                break;
            case 4: // check player open door
                if (doorKnob.doorOpen) {
                    callNextProc = true;
                    delayCallNextProc = 1f;
                }
                else if (!doorKnob.doorOpen && openDoorComplete)
                {
                    doorKnob.OpenDoor();
                }
                break;
            case 5: // check cutscene 1 complete
                if (cutscene1Complete)
                {
                    phone.transform.parent = null;
                    phone.SetKinematic(false);
                    phone.Respawn();
                    callNextProc = true;
                    delayCallNextProc = 0f;
                }
                break;
        }
    }


    private bool CheckHandFul()
    {
        if (Player.Instance == null) return false;
        if (handfulTimer >= handfulTime || handfulComplete)
        {
            timerBar.fillAmount = 1f;
            return true;
        }

        if (Player.Instance.l_ful && Player.Instance.l_ful)
        {
            handfulTimer += Time.deltaTime;
            handTutorialAnim.SetBool("action", true);
        }
        else
        {
            handfulTimer = Mathf.Max(handfulTimer - Time.deltaTime, 0);
            handTutorialAnim.SetBool("action", false);
        }
        timerBar.fillAmount = Mathf.Clamp01(handfulTimer / handfulTime);
        return false;
    }

    private bool CheckHandPalm()
    {
        if (Player.Instance == null) return false;
        if (handpalmTimer >= handpalmTime || handpalmComplete)
        {
            timerBar.fillAmount = 1f;
            return true;
        }
        else
        {
            if (Player.Instance.l_palm && Player.Instance.r_palm)
            {
                handpalmTimer += Time.deltaTime;
                handTutorialAnim.SetBool("action", true);
            }
            else
            {
                handpalmTimer = Mathf.Max(handpalmTimer - Time.deltaTime, 0);
                handTutorialAnim.SetBool("action", false);
            }
            timerBar.fillAmount = Mathf.Clamp01(handpalmTimer / handpalmTime);
        }
        return false;
    }

    private bool CheckPointing()
    {
        if (Player.Instance == null) return false;
        if (pointingTimer >= pointingTime || pointingComplete)
        {
            timerBar.fillAmount = 1f;
            return true;
        }
        else
        {
            if (Player.Instance.l_isPointing && Player.Instance.r_isPointing)
            {
                pointingTimer += Time.deltaTime;
                handTutorialAnim.SetBool("action", true);
            }
            else
            {
                pointingTimer = Mathf.Max(pointingTimer - Time.deltaTime, 0);
                handTutorialAnim.SetBool("action", false);
            }
            timerBar.fillAmount = Mathf.Clamp01(pointingTimer / pointingTime);
        }
        return false;
    }


    public void EndCutScene1() {
        cutscene1Complete = true;
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
        moveTimer = 0;
        isMove = false;
        moveDelay = imoveDelay;
        toPos = Vector3.zero;
        bool configured = OVRManager.boundary.GetConfigured();
        if (configured)
        {
            Vector3[] boundaryPoints = OVRManager.boundary.GetGeometry(OVRBoundary.BoundaryType.PlayArea);
            BoxCollider box = to.GetComponentInChildren<BoxCollider>();
            if (box != null)
            {
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

    private void SnapHandToObject(GameObject _object, GameObject hand)
    {
        hand.transform.position = _object.transform.position;
    }

    private void SnapObjectToHand(GameObject _object, GameObject hand)
    {
        _object.transform.position = hand.transform.position;
    }
}
