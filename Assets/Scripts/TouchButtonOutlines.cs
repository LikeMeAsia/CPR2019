using cakeslice;
using UnityEngine;

public class TouchButtonOutlines : MonoBehaviour
{
    private const string MAIN_TRIGGER = "main_trigger_PLY";
    private const string SIDE_TRIGGER = "side_trigger_PLY";
    private const string THUMB_STICK_BALL = "thumbstick_ball_PLY";
    private const string X_BUTTON = "x_button_PLY";
    private const string Y_BUTTON = "y_button_PLY";
    private const string A_BUTTON = "a_button_PLY";
    private const string B_BUTTON = "b_button_PLY";

    public enum TouchButtonName  { buttonX, buttonY, side_trigger, main_trigger, thumbstick_ball }

    [ReadOnly]
    public Outline buttonX;
    [ReadOnly]
    public Outline buttonY;
    [ReadOnly]
    public Outline side_trigger;
    [ReadOnly]
    public Outline main_trigger;
    [ReadOnly]
    public Outline thumbstick_ball;

    void Start()
    {
        gameObject.ApplyRecursivelyOnDescendants(child => child.layer = LayerMask.NameToLayer("OnTop"));
        SkinnedMeshRenderer[] rends = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer rend in rends)
        {
            rend.enabled = false;
        }
        Outline[] allOutline = GetComponentsInChildren<Outline>();
        foreach (Outline ot in allOutline) {
            if (ot.name.Contains(MAIN_TRIGGER))
            {
                main_trigger = ot;
            }
            else if(ot.name.Contains(SIDE_TRIGGER))
            {
                side_trigger = ot;
            }
            else if (ot.name.Contains(THUMB_STICK_BALL))
            {
                thumbstick_ball = ot;
            }
            else if (ot.name.Contains(X_BUTTON) || ot.name.Contains(A_BUTTON))
            {
                buttonX = ot;
            }
            else if (ot.name.Contains(Y_BUTTON)|| ot.name.Contains(B_BUTTON))
            {
                buttonY = ot;
            }
            ot.enabled = false;
        }
    }

    public Outline GetOutlineButton(TouchButtonName button)
    {
        switch (button)
        {
            case TouchButtonName.buttonX:
                return buttonX;
            case TouchButtonName.buttonY:
                return buttonY;
            case TouchButtonName.side_trigger:
                return side_trigger;
            case TouchButtonName.main_trigger:
                return main_trigger;
            case TouchButtonName.thumbstick_ball:
                return thumbstick_ball;
        }
        return null;
    }

    public void SetEnableOutline(TouchButtonName button, bool isEnable)
    {
        Outline outlineBtn = GetOutlineButton(button);
        if (outlineBtn != null)
        {
            outlineBtn.enabled = isEnable;
        }
        else
        {
            Debug.Log("Button [" + button.ToString() + "] is not found.");
        }
    }

    public void EnableOutlineBareHand() {
        foreach (TouchButtonName button in (TouchButtonName[])System.Enum.GetValues(typeof(TouchButtonName)))
        {
            SetEnableOutline(button, false);
        }
    }

    public void EnableOutlineHandful()
    {
        EnableOutlineBareHand();
        SetEnableOutline(TouchButtonName.buttonX, true);
        SetEnableOutline(TouchButtonName.buttonY, true);
        SetEnableOutline(TouchButtonName.side_trigger, true);
        SetEnableOutline(TouchButtonName.main_trigger, true);
    }
    
    public void EnableOutlinePointingHand()
    {
        EnableOutlineBareHand();
        SetEnableOutline(TouchButtonName.side_trigger, true);
        SetEnableOutline(TouchButtonName.buttonX, true);
        SetEnableOutline(TouchButtonName.buttonY, true);
    }
}
