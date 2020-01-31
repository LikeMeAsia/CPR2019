using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerMoveEvent", menuName = "SceneEvent/PlayerMoveEvent", order = 3)]
public class PlayerMoveEvent : SceneEvent
{
    [SerializeField]
    private string positionName;
    private Transform targetTransform;
    Vector3 pastFollowerPosition, pastTargetPosition;
    private GameObject lookPoint;
    private GameObject curLookPoint;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 0.1f;
    private float delayTimer = 0;
    private readonly float smoothTime = 3f;
    private Vector3 velocity;
    private bool isMove;
    public bool IsMove { get { return isMove; } }
    private Vector3 toPos = Vector3.zero;

    [SerializeField, Layer]
    private int layerMask=0;

    [SerializeField]
    private bool waitFinishMove;

    public override void InitEvent()
    {
        base.InitEvent();
        isMove = false;
        delayTimer = 0;
        velocity = Vector3.zero;
        SceneAssetManager.GetAssetComponent<Transform>(positionName, out targetTransform);
    }

    public override void StartEvent()
    {
        InitEvent();
        if (targetTransform == null) {
            passEventCondition = true;
        }
        else{
            moveSpeed = Mathf.Max(0.01f, moveSpeed);
            delayTimer = 0;
            velocity = Vector3.zero;
            isMove = true;
            toPos = GetTargetPosition(targetTransform);
            pastFollowerPosition = Player.Instance.transform.position;
            pastTargetPosition = targetTransform.position;

            CreateMarker();
        }
    }

    public override void UpdateEvent()
    {
        passEventCondition = !isMove;

        if (isMove)
        {
            if(IsPlayerLookAtTarget())
            {
                Player.Instance.transform.position = SmoothApproach(pastFollowerPosition, pastTargetPosition, targetTransform.position, moveSpeed);
                pastFollowerPosition = Player.Instance.transform.position;
                pastTargetPosition = targetTransform.position;

                if (Vector3.Distance(Player.Instance.transform.position, toPos) < 0.05f)
                {
                    //Player.Instance.transform.position = toPos;
                    isMove = false;
                }
            }
        }
        if (lookPoint!=null) {
            lookPoint.transform.LookAt(Camera.main.transform.position);
        }
    }


    Vector3 SmoothApproach(Vector3 pastPosition, Vector3 pastTargetPosition, Vector3 targetPosition, float speed)
    {
        float t = Time.deltaTime * speed;
        Vector3 v = (targetPosition - pastTargetPosition) / t;
        Vector3 f = pastPosition - pastTargetPosition + v;
        return targetPosition - v + f * Mathf.Exp(-t);
    }

    public override void StopEvent()
    {
        if (lookPoint != null) GameObject.Destroy(lookPoint);
        if (curLookPoint != null) GameObject.Destroy(curLookPoint);
    }

    public override bool Skip()
    {
        return false;
    }

    private Vector3 GetTargetPosition(Transform target)
    {
        Vector3 targetPos = new Vector3(target.position.x, Player.Instance.transform.position.y, target.position.z);
        bool configured = OVRManager.boundary.GetConfigured();
        if (configured)
        {
            Vector3[] boundaryPoints = OVRManager.boundary.GetGeometry(OVRBoundary.BoundaryType.PlayArea);
            BoxCollider box = target.GetComponentInChildren<BoxCollider>();
            if (box != null)
            {
                targetPos = target.position;
                targetPos = new Vector3(targetPos.x, Player.Instance.transform.position.y, targetPos.z);
            }
        }
        return targetPos;
    }

    private void CreateMarker() {
        lookPoint = Instantiate(Resources.Load("Prefabs/LookHere")) as GameObject;
        Vector3 lookPointPos = new Vector3(targetTransform.position.x, Camera.main.transform.position.y, targetTransform.position.z);
        Vector3 additionPos = targetTransform.position - Camera.main.transform.position;
        additionPos.y = 0;
        lookPoint.transform.position = lookPointPos + additionPos.normalized * 1f;
        
        /*curLookPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        curLookPoint.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);*/
    }

    private bool IsPlayerLookAtTarget() {
       // curLookPoint.transform.position = Camera.main.transform.position+ Camera.main.transform.forward * 2f;

        RaycastHit[] hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 5f, layerMask);
        if (hits!=null && hits.Length>0)
        {
            foreach (RaycastHit hit in hits) {
                if (hit.transform.gameObject == lookPoint) return true;
            }
        }

        return false;
    }
}
