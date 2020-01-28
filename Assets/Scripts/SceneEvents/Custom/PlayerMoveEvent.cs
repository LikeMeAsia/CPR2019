using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerMoveEvent", menuName = "SceneEvent/PlayerMoveEvent", order = 3)]
public class PlayerMoveEvent : SceneEvent
{
    [SerializeField]
    private string positionName;
    private Transform targetTransform;
    private GameObject lookPoint;
    private GameObject marklookPoint;
    private Renderer lookPointRend;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 0.1f;
    [SerializeField]
    private float moveDelay = 0;
    private float delayTimer = 0;
    private float smoothTime = 0.2f;
    private Vector3 velocity;
    private bool isMove;
    public bool IsMove { get { return isMove; } }
    private Vector3 toPos = Vector3.zero;
    
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
            MoveTo();
            lookPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            lookPoint.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Vector3 lookPointPos = new Vector3(toPos.x, Camera.main.transform.position.y, toPos.z);
            Vector3 additionPos = targetTransform.position - Camera.main.transform.position;
            additionPos.y = 0;
            lookPoint.transform.position = lookPointPos + additionPos.normalized*0.3f;
            lookPointRend = lookPoint.GetComponent<Renderer>();


            marklookPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            marklookPoint.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    public override void UpdateEvent()
    {
        passEventCondition = !isMove;

        if (isMove)
        {
            if(IsPlayerLookAtTarget())
            {
                Player.Instance.transform.position = Vector3.SmoothDamp(Player.Instance.transform.position, toPos,
                                                        ref velocity, smoothTime, moveSpeed);
                if (Vector3.Distance(Player.Instance.transform.position, toPos) < 0.1f)
                {
                    Player.Instance.transform.position = toPos;
                    isMove = false;
                }
            }
        }
    }

    public override void StopEvent()
    {
        if (lookPoint != null) GameObject.Destroy(lookPoint);
        if (marklookPoint != null) GameObject.Destroy(marklookPoint);
    }

    public override bool Skip()
    {
        return false;
    }

    private void MoveTo()
    {
        bool configured = OVRManager.boundary.GetConfigured();
        if (configured)
        {
            Vector3[] boundaryPoints = OVRManager.boundary.GetGeometry(OVRBoundary.BoundaryType.PlayArea);
            BoxCollider box = targetTransform.GetComponentInChildren<BoxCollider>();
            if (box != null)
            {
                toPos = targetTransform.position;
                toPos = new Vector3(toPos.x, Player.Instance.transform.position.y, toPos.z);
            }
        }
        else
        {
            toPos = new Vector3(targetTransform.position.x, Player.Instance.transform.position.y, targetTransform.position.z);
        }
        moveSpeed = Mathf.Max(0.01f, moveSpeed);
        delayTimer = 0;
        velocity = Vector3.zero;
        isMove = true;
    }

    private bool IsPlayerLookAtTarget() {
        int layer_mask = ~( LayerMask.GetMask("Props"));
        marklookPoint.transform.position = Camera.main.transform.position+ Camera.main.transform.forward * 2f;

        RaycastHit[] hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 2f, layer_mask);
        if (hits!=null && hits.Length>0)
        {
            foreach (RaycastHit hit in hits) {
                if (hit.transform.gameObject == lookPoint) return true;
            }
        }
        return false;
    }
}
