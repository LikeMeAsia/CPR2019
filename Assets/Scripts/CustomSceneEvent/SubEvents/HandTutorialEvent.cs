using com.dgn.SceneEvent;
using com.dgn.XR.Extensions;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "HandTutorialEvent", menuName = "SceneEvent/SubEvent/HandTutorialEvent", order = 2)]
public class HandTutorialEvent : SceneSubEvent
{
    public enum HandGesture { Fist = 0, Open = 1, Pointing = 2}

    [SerializeField]
    private HandGesture gesture;
    private Animator handTutorialAnim;
    private Image timerBar;
    [SerializeField]
    private float handTime = 4f;
    private float handTimer;
    private float delayInputReceiveTime = 2f;
    private float delayInputReceiveTimer;
    private bool skip;

    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponentInChildren<Animator>("HandTutorialCanvas", out handTutorialAnim);
        found = SceneAssetManager.GetAssetComponent<Image>("TimerBar", out timerBar);
        if (handTutorialAnim != null)
        {
            handTutorialAnim.SetBool("disable", true);
        }
    }
    public override void StartEvent()
    {
        skip = false;
        handTimer = 0;
        FillTimeBar(0);
        if (handTutorialAnim != null) {
            int gestureId = (int)gesture;
            Debug.Log("gestureId: "+ gestureId);
            handTutorialAnim.SetInteger("type", gestureId);
            handTutorialAnim.SetBool("disable", false);
            handTutorialAnim.SetBool("action", false);
            delayInputReceiveTimer = delayInputReceiveTime;
        }
    }

    public override void UpdateEvent()
    {
        passEventCondition = CheckHandGestureInput();
    }

    public override void StopEvent() {
        if (handTutorialAnim != null)
        {
            handTutorialAnim.SetBool("disable", true);
            handTutorialAnim.SetBool("action", false);
        }
    }

    public override float GetDelayNextEvent()
    {
        return skip ? 0 : base.GetDelayNextEvent();
    }

    public override bool Skip()
    {
        skip = true;
        return true;
    }

    private bool CheckHandGestureInput()
    {
        if(skip) return true;
        if (Player.Instance == null) return false;
        if (delayInputReceiveTimer > 0) {
            delayInputReceiveTimer -= Time.deltaTime;
            return false;
        }
        if (handTimer >= handTime)
        {
            FillTimeBar(1f);
            return true;
        }
        if (CheckDoGestureBothHands())
        {
            handTimer += Time.deltaTime;
            if (handTutorialAnim != null)
                handTutorialAnim.SetBool("action", true);
        }
        else
        {
            handTimer = Mathf.Max(handTimer - Time.deltaTime, 0);
            if (handTutorialAnim != null)
                handTutorialAnim.SetBool("action", false);
        }
        FillTimeBar(handTimer / handTime);
        return false;
    }

    private bool CheckDoGestureBothHands(){
        bool doGesture = false;
        switch (gesture)
        {
            case HandGesture.Fist:
                doGesture = Player.Instance.RightHandState == HandPresence.HandState.Fist
                    && Player.Instance.LeftHandState == HandPresence.HandState.Fist;
                break;
            case HandGesture.Open:
                doGesture = Player.Instance.RightHandState == HandPresence.HandState.BareHand
                    && Player.Instance.LeftHandState == HandPresence.HandState.BareHand;
                break;
            case HandGesture.Pointing:
                doGesture = Player.Instance.RightHandState == HandPresence.HandState.Pointing
                    && Player.Instance.LeftHandState == HandPresence.HandState.Pointing;
                break;
        }
        return doGesture;
    }

    private void EnableOutline() {
        /*switch (gesture) {
            case HandGesture.Fist:
                Player.Instance.EnableOutlineHandFul();
                break;
            case HandGesture.Open:
                Player.Instance.EnableOutlineBareHands();
                break;
            case HandGesture.Pointing:
                Player.Instance.EnableOutlinePointing();
                break;
            default:
                Player.Instance.EnableOutlineBareHands();
                break;
        }*/
    }

    private void FillTimeBar(float percentage) {
        if (timerBar == null) return;
        timerBar.fillAmount = Mathf.Clamp01(percentage);
    }
}
