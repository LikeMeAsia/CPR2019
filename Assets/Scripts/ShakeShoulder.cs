﻿using cakeslice;
using UnityEngine;

public class ShakeShoulder : MonoBehaviour
{
    public GameObject shakingUI;
    public int maxHit;

    private int countShake;
    private Collider[] shoulderColliders;
    private Outline[] outlines;
    [SerializeField][ReadOnly]
    private bool shaking;
    public bool Shaking { get { return shaking; } }

    private bool enableVibration;
    public float vibrateTime = 0.1f;
    private float vibrateTimer = 0.0f;
    private bool canVibrateOnce = false;

    void Start()
    {
        shoulderColliders = GetComponentsInChildren<Collider>();
        outlines = GetComponentsInChildren<Outline>();
        countShake = 0;
        shaking = false;
        SetActiveShoulderIput(false);
    }

    private void Update()
    {
        if (enableVibration) { if (canVibrateOnce) Vibrate(); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enableVibration && !canVibrateOnce && other.gameObject.CompareTag("Hand"))
        {
            canVibrateOnce = true;
            countShake++;
            Debug.Log("Shake!" + countShake + "/"+ maxHit) ;
            if (countShake >= maxHit)
            {
                shaking = true;
                shakingUI.SetActive(false);
                SetActiveShoulderIput(false);
            }
        }
    }
    
    public void EnableInputRecieve()
    {
        countShake = 0;
        shaking = false;
        SetActiveShoulderIput(true);
    }

    private void SetActiveShoulderIput(bool value) {
        shakingUI.SetActive(value);
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
        if (vibrateTimer <= vibrateTime)
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
            vibrateTimer += Time.deltaTime;
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            vibrateTimer = 0.0f;
            canVibrateOnce = false;
        }
    }
}
