using cakeslice;
using com.dgn.UnityAttributes;
using com.dgn.XR.Extensions;
using UnityEngine;
using UnityEngine.XR;

public class ShakeShoulder : MonoBehaviour
{
    public Canvas shakingUI;
    public int maxHit;

    private int countShake;
    private Collider[] shoulderColliders;
    private Outline[] outlines;
    [SerializeField][ReadOnly]
    private bool shaking;
    public bool Shaking { get { return shaking; } }

    private bool enableVibration;
    public float vibrateTime = 0.1f;
    public float vibrateDelay = 0.03f;
    private float vibrateTimer = 0.0f;
    private bool canVibrateOnce = false;

    void Start()
    {
        shoulderColliders = GetComponentsInChildren<Collider>();
        outlines = GetComponentsInChildren<Outline>();
        countShake = 0;
        shaking = false;
        SetActiveShoulderInput(false);
    }

    private void Update()
    {
        if (enableVibration && canVibrateOnce) {
            Vibrate();
            if (!canVibrateOnce) {
                countShake++;
                Debug.Log("Shake!" + countShake + "/" + maxHit);
                if (countShake >= maxHit)
                {
                    SuccessShaking();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enableVibration &&  !canVibrateOnce && other.gameObject.CompareTag("PlayerHand"))
        {
            canVibrateOnce = true;
        }
    }

    public void SuccessShaking()
    {
        shaking = true;
        shakingUI.gameObject.SetActive(false);
        SetActiveShoulderInput(false);
    }

    public void EnableInputRecieve()
    {
        countShake = 0;
        shaking = false;
        SetActiveShoulderInput(true);
        shakingUI.gameObject.SetActive(true);
    }

    private void SetActiveShoulderInput(bool value) {
        //Debug.Log("shake UI"+ value);
        enableVibration = value;
        foreach (Collider col in shoulderColliders)
        {
            col.enabled = value;
        }
        foreach (Outline outline in outlines)
        {
            outline.enabled = value;
        }
    }


    private void Vibrate()
    {
        vibrateTimer += Time.deltaTime;
        if (vibrateTimer < vibrateTime)
        {
            XRVibrationManager.Instance.TriggerVibration(1, 1, XRNode.RightHand);
            XRVibrationManager.Instance.TriggerVibration(1, 1, XRNode.LeftHand);
        }
        else
        {
            XRVibrationManager.Instance.StopVibration(XRNode.RightHand);
            XRVibrationManager.Instance.StopVibration(XRNode.LeftHand);
        }

        if (vibrateTimer > vibrateTime + vibrateDelay)
        {
            vibrateTimer = 0.0f;
            canVibrateOnce = false;
        }
    }
}
