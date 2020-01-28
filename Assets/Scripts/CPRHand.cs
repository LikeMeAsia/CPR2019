using System.Collections;
using UnityEngine;

public class CPRHand : MonoBehaviour
{
    private static CPRHand instance;
    public static CPRHand Instance { get { return instance; } }
    public void Awake()
    {
        instance = this;
    }

    public enum HandsState { RightHandUnder, LeftHandUnder, None}

    [Header("CPR Hand")]
    public Vector3 centerPoint;
    public Collider cprHandCollider;

    public Transform rHandTrack;
    public Transform lHandTrack;

    public GameObject l_cprHandUnderObj;
    public GameObject r_cprHandUnderObj;
    public HandsState handsState;

    [Header("Status")]
    public bool snaping;
    public bool enabledSnap;
    [Header("")]
    public bool handsNear;
    public bool l_handDown;
    public bool r_handDown;

    [Header("Parameters")]
    public float minDist = 0.15f;
    public float r_rot;
    public float l_rot;
    public Vector2 r_rotationHandThreshold = new Vector2(-30f, 30f);
    public Vector2 l_rotationHandThreshold = new Vector2(-30f, 30f);

    void Start()
    {
        cprHandCollider = GetComponent<Collider>();
        DisabledSnapping();
    }

    void Update()
    {
        if (!Player.Instance.ready) return;
        CheckHandSnapping();
        SnapHandTogether();
    }

    private void CheckHandSnapping()
    {
        handsNear = Vector3.Distance(lHandTrack.position, rHandTrack.position) <= minDist;
        l_rot = lHandTrack.eulerAngles.z;
        r_rot = rHandTrack.eulerAngles.z;
        l_handDown = IsBetween(l_rot, l_rotationHandThreshold.x, l_rotationHandThreshold.y);
        r_handDown = IsBetween(r_rot, r_rotationHandThreshold.x, r_rotationHandThreshold.y);

        if (lHandTrack.position.y < rHandTrack.position.y && Player.Instance.r_ful)
        {
            handsState = HandsState.LeftHandUnder;
        }
        else if (lHandTrack.position.y > rHandTrack.position.y && Player.Instance.l_ful)
        {
            handsState = HandsState.RightHandUnder;
        }
        else {
            handsState = HandsState.None;
        }
        snaping = enabledSnap && handsNear && handsState != HandsState.None; // && r_handDown && l_handDown
    }
    private void SnapHandTogether()
    {
        if (snaping)
        {
            centerPoint = (lHandTrack.position + rHandTrack.position) / 2;
            transform.rotation = Quaternion.identity;
            Player.Instance.SetEnabledHands(false);
            cprHandCollider.enabled = true;

            if (handsState == HandsState.LeftHandUnder)
            {
                l_cprHandUnderObj.SetActive(true);
                r_cprHandUnderObj.SetActive(false);
                transform.rotation = lHandTrack.rotation;
                centerPoint.y = lHandTrack.position.y;
                transform.position = centerPoint;
            }
            else if (handsState == HandsState.RightHandUnder)
            {
                r_cprHandUnderObj.SetActive(true);
                l_cprHandUnderObj.SetActive(false);
                centerPoint.y = rHandTrack.position.y;
                transform.rotation = rHandTrack.rotation;
            }
        }
        else
        {
            Player.Instance.SetEnabledHands(true);
            DisabledSnapping();
        }

    }

    private void DisabledSnapping() {
        r_cprHandUnderObj.SetActive(false);
        l_cprHandUnderObj.SetActive(false);
        cprHandCollider.enabled = false;
    }

    private bool IsBetween(float num, float min, float max)
    {
        return num >= min && num <= max;
    }
}
