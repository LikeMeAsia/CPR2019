using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "HandTutorialEvent", menuName = "SceneEvent/HandTutorialEvent", order = 2)]
public class HandTutorialEvent : SceneEvent
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
        bool found = SceneAssetManager.GetAssetComponent<Animator>("HandTutorial", out handTutorialAnim);
        Debug.Log("Found HandTutorial: " + found);
        found = SceneAssetManager.GetAssetComponent<Image>("TimerBar", out timerBar);
        Debug.Log("Found TimerBar: " + found);
        if (handTutorialAnim != null)
        {
            handTutorialAnim.SetBool("disable", true);
        }
        skip = false;
        handTimer = 0;
        FillTimeBar(0);
    }
    public override void StartEvent()
    {
        InitEvent();
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
        if (Player.Instance.showController) {
            OVRInput.Controller activeController = OVRInput.GetActiveController();
            if (activeController == OVRInput.Controller.Touch)
            {
                EnableOutline();
            }
            else
            {
                Player.Instance.EnableOutlineBareHands();
            }
        }
    }

    public override void StopEvent() {
        Player.Instance.EnableOutlineBareHands();
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
        return skip;
    }

    private bool CheckHandGestureInput()
    {
        if (Player.Instance == null) return false;
        if (delayInputReceiveTimer > 0) {
            delayInputReceiveTimer -= Time.deltaTime;
            return false;
        }
        if (handTimer >= handTime || skip)
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
                doGesture = Player.Instance.l_ful && Player.Instance.r_ful;
                break;
            case HandGesture.Open:
                doGesture = Player.Instance.l_palm && Player.Instance.r_palm;
                break;
            case HandGesture.Pointing:
                doGesture = Player.Instance.l_isPointing && Player.Instance.r_isPointing;
                break;
        }
        return doGesture;
    }

    private void EnableOutline() {
        switch (gesture) {
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
        }
    }

    private void FillTimeBar(float percentage) {
        if (timerBar == null) return;
        timerBar.fillAmount = Mathf.Clamp01(percentage);
    }
}
