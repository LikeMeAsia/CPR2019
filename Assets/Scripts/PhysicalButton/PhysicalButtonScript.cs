using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PhysicalButtonScript : MonoBehaviour, ITriggerListener
{
    public enum PhysicalButtonState { Default, Touch, Pressed, Released}
    public UnityEvent pressedEvent;
    public UnityEvent hoverEvent;
    public UnityEvent releasedEvent;

    public bool callEventOnlyOnce;
    public bool activable = true;

    [ReadOnly]
    [SerializeField]
    PhysicalButtonState buttonState;
    public PhysicalButtonState ButtonState { get { return buttonState; } }
    
    /** Press timer to support in case hard to press button **/
    /** By holding button in curtain time, it will trigger like pressing **/
    private static readonly float PressTimeToActive = 0.02f;
    private float pressTimer;
    private float untouchTimer;

    [ReadOnly]
    [SerializeField]
    private bool pressed;

    [ReadOnly]
    [SerializeField]
    private bool activated;

    private Rigidbody pressRigid;
    private HingeJoint pressJoint;
    private Renderer pressRend;
    public Text textBtn;
    public Image backgroundImage;
    public Image iconImage;

    [ReadOnly]
    [SerializeField]
    private PhysicalButtonSkin defaultSkin;

    [SerializeField]
    private PhysicalButtonSkin hoverSkin;

    [SerializeField]
    private PhysicalButtonSkin activateSkin;
    
    private AudioClip buttonClip;
    private HashSet<OVRInput.Controller> ctrlSet;

    private Coroutine pressRoutine;

    #region Unity functions
    void Awake()
    {
        pressed = false;
        activated = false;
        untouchTimer = 0;
        ctrlSet = new HashSet<OVRInput.Controller>();
        if (pressedEvent == null) {
            pressedEvent = new UnityEvent();
        }
        if (hoverEvent == null)
        {
            hoverEvent = new UnityEvent();
        }
        if (releasedEvent == null)
        {
            releasedEvent = new UnityEvent();
        }
        Transform pressChild = this.transform.Find("Base/Press");
        if (pressChild != null)
        {
            pressRigid = pressChild.GetComponent<Rigidbody>();
            pressJoint = pressChild.GetComponent<HingeJoint>();
            pressRend = pressChild.GetComponent<MeshRenderer>();
            defaultSkin = new PhysicalButtonSkin();
            if (pressRend != null) {
                defaultSkin.rendColor = pressRend.material.color;
            }
            if (backgroundImage != null) {
                defaultSkin.backgroundSprite = backgroundImage.sprite;
                defaultSkin.backgroundColor = backgroundImage.color;
            }
            if (textBtn != null) {
                defaultSkin.textColor = textBtn.color;
            }
            if (iconImage != null)
            {
                defaultSkin.iconSprite = iconImage.sprite;
            }
        }
        Collider collider = pressChild.GetComponent<Collider>();
        if (collider != null)
        {
            TriggerBridge tb = pressChild.gameObject.AddComponent<TriggerBridge>();
            tb.Initialize(this);
        }
    }

    void Start() {
        buttonClip = Resources.Load<AudioClip>("SFX/Button");
        pressJoint.enablePreprocessing = true;
        pressJoint.enableCollision = true;
    }
    
    void LateUpdate()
    {
        if (buttonState != PhysicalButtonState.Default) {
            if (pressJoint.currentForce.sqrMagnitude < 0.1f || pressRigid.transform.localPosition.z >= pressJoint.connectedAnchor.z) {
                ReturnDefaultState();
            } else if (untouchTimer > 0) {
                untouchTimer = untouchTimer - Time.deltaTime;
                if (untouchTimer <= 0) {
                    ReturnDefaultState();
                }
            }
        }
        if (pressRigid.transform.localPosition.z < 0)
        {
            pressRigid.transform.localPosition = Vector3.zero;
        }
        else if (pressRigid.transform.localPosition.z > pressJoint.connectedAnchor.z)
        {
            pressRigid.transform.localPosition = new Vector3(0, 0, pressJoint.connectedAnchor.z);
        }
        else if(pressRigid.transform.localPosition.x != 0 || pressRigid.transform.localPosition.y != 0)
        {
            pressRigid.transform.localPosition = new Vector3(0, 0, pressRigid.transform.localPosition.z);
        }
    }

    private void ReturnDefaultState() {
        UpdateState(PhysicalButtonState.Default);
        pressRigid.isKinematic = false;
        pressed = false;
        untouchTimer = 0;
        if (!callEventOnlyOnce)
        {
            activated = false;
            SetButtonSkin(defaultSkin);
        }
    }

    private void OnDisable()
    {
        foreach (OVRInput.Controller ctrl in ctrlSet)
        {
            OVRInput.SetControllerVibration(0, 0, ctrl);
        }
        ctrlSet.Clear();
        if(pressRoutine!=null) StopCoroutine(pressRoutine);
    }
    #endregion

    #region public functions

    public void SetColor(Color icolor)
    {
        if (pressRend == null || pressRend.material == null) return;
        pressRend.material.SetColor("_Color", icolor);
    }
    public void ResetColor()
    {
        SetColor(defaultSkin.rendColor);
    }
    public void SetTextColor(Color icolor)
    {
        if (textBtn == null) return;
        textBtn.color = icolor;
    }
    public void ResetTextColor()
    {
        SetTextColor(defaultSkin.textColor);
    }
    public void SetBackgroundImage(Sprite iSprite) {
        SetBackgroundImage(iSprite, Color.white);
    }
    public void SetBackgroundImage(Sprite iSprite, Color iColor)
    {
        if (backgroundImage == null || iSprite == null) return;
        backgroundImage.sprite = iSprite;
        backgroundImage.color = iColor;
    }
    public void SetIcon(Sprite iSprite)
    {
        if (iconImage == null || iSprite == null) return;
        iconImage.sprite = iSprite;
    }
    public void ResetIcon(Sprite iSprite)
    {
        SetIcon(defaultSkin.iconSprite);
    }
    public void ResetBackgroundImage()
    {
        SetBackgroundImage(defaultSkin.backgroundSprite, defaultSkin.backgroundColor);
    }
    public void SetButtonSkin(PhysicalButtonSkin skin)
    {
        if (skin == null) return;
        SetTextColor(skin.textColor);
        SetBackgroundImage(skin.backgroundSprite, skin.backgroundColor);
        SetColor(skin.rendColor);
        SetIcon(skin.iconSprite);
    }

    public void ResetActivated()
    {
        activated = false;
    }
    public void SetActivable(bool value)
    {
        activable = value;
    }

    public void SetHoverSkin(PhysicalButtonSkin iSkin)
    {
        hoverSkin = iSkin;
    }
    public void SetHoverSkin(Sprite iBackground, Color iBackgroundColor)
    {
        if (hoverSkin == null) hoverSkin = new PhysicalButtonSkin();
        hoverSkin.textColor = defaultSkin.textColor;
        hoverSkin.backgroundSprite = iBackground;
        hoverSkin.backgroundColor = iBackgroundColor;
    }
    public void SetHoverSkin(Color iRendColor)
    {
        if (hoverSkin == null) hoverSkin = new PhysicalButtonSkin();
        hoverSkin.textColor = defaultSkin.textColor;
        hoverSkin.rendColor = iRendColor;
    }
    public void SetHoverSkin(Color iTextColor, Sprite iBackground)
    {
        if (hoverSkin == null) hoverSkin = new PhysicalButtonSkin();
        hoverSkin.textColor = iTextColor;
        hoverSkin.backgroundSprite = iBackground;
        hoverSkin.backgroundColor = Color.white;
    }
    public void SetHoverSkin(Color iTextColor, Sprite iBackground, Color iBackgroundColor) {
        if (hoverSkin == null) hoverSkin = new PhysicalButtonSkin();
        hoverSkin.textColor = iTextColor;
        hoverSkin.backgroundSprite = iBackground;
        hoverSkin.backgroundColor = iBackgroundColor;
    }
    public void SetHoverSkin(Color iTextColor, Color iRendColor)
    {
        if (hoverSkin == null) hoverSkin = new PhysicalButtonSkin();
        hoverSkin.textColor = iTextColor;
        hoverSkin.rendColor = iRendColor;
    }
    public void SetHoverSkin(Color iTextColor, Sprite iBackground, Color iBackgroundColor, Color iRendColor)
    {
        if (hoverSkin == null) hoverSkin = new PhysicalButtonSkin();
        hoverSkin.textColor = iTextColor;
        hoverSkin.backgroundSprite = iBackground;
        hoverSkin.backgroundColor = iBackgroundColor;
        hoverSkin.rendColor = iRendColor;
    }

    public void SetActivateSkin(PhysicalButtonSkin iSkin)
    {
        activateSkin = iSkin;
    }
    public void SetActivateSkin(Sprite iBackground, Color iBackgroundColor)
    {
        if (activateSkin == null) activateSkin = new PhysicalButtonSkin();
        activateSkin.textColor = defaultSkin.textColor;
        activateSkin.backgroundSprite = iBackground;
        activateSkin.backgroundColor = iBackgroundColor;
    }
    public void SetActivateSkin(Color iRendColor)
    {
        if (activateSkin == null) activateSkin = new PhysicalButtonSkin();
        activateSkin.textColor = defaultSkin.textColor;
        activateSkin.rendColor = iRendColor;
    }
    public void SetActivateSkin(Color iTextColor, Sprite iBackground)
    {
        if (activateSkin == null) activateSkin = new PhysicalButtonSkin();
        activateSkin.textColor = iTextColor;
        activateSkin.backgroundSprite = iBackground;
        activateSkin.backgroundColor = Color.white;
    }
    public void SetActivateSkin(Color iTextColor, Sprite iBackground, Color iBackgroundColor)
    {
        if (activateSkin == null) activateSkin = new PhysicalButtonSkin();
        activateSkin.textColor = iTextColor;
        activateSkin.backgroundSprite = iBackground;
        activateSkin.backgroundColor = iBackgroundColor;
    }
    public void SetActivateSkin(Color iTextColor, Color iRendColor)
    {
        if (activateSkin == null) activateSkin = new PhysicalButtonSkin();
        activateSkin.textColor = iTextColor;
        activateSkin.rendColor = iRendColor;
    }
    public void SetActivateSkin(Color iTextColor, Sprite iBackground, Color iBackgroundColor, Color iRendColor)
    {
        if (activateSkin == null) activateSkin = new PhysicalButtonSkin();
        activateSkin.textColor = iTextColor;
        activateSkin.backgroundSprite = iBackground;
        activateSkin.backgroundColor = iBackgroundColor;
        activateSkin.rendColor = iRendColor;
    }

    #endregion

    #region private functions
    IEnumerator InvokePressedEvent()
    {
        activated = true;
        SetButtonSkin(activateSkin);
        yield return new WaitForSeconds(0.2f);
        pressedEvent.Invoke();
        untouchTimer = 0.4f;
        pressRoutine = null;
    }

    private void UpdateState(PhysicalButtonState updatedState, OVRInput.Controller ovrCtrl = OVRInput.Controller.RTouch)
    {
        switch (updatedState)
        {
            case PhysicalButtonState.Touch:
                OVRInput.SetControllerVibration(0.5f, 0.25f, ovrCtrl);
                if (buttonState != updatedState) {
                    pressTimer = PressTimeToActive;
                    SetButtonSkin(hoverSkin);
                    hoverEvent.Invoke();
                }
                break;
            case PhysicalButtonState.Pressed:;
                if (!activated && activable)
                {
                    OVRInput.SetControllerVibration(1, 1, ovrCtrl);
                    pressRoutine = StartCoroutine(InvokePressedEvent());
                }
                break;
            case PhysicalButtonState.Released:
                OVRInput.SetControllerVibration(0f, 0f, ovrCtrl);
                pressJoint.connectedBody.AddForce(pressJoint.connectedBody.transform.forward, ForceMode.Impulse);
                break;
            default:
                foreach (OVRInput.Controller ctrl in ctrlSet)
                {
                    OVRInput.SetControllerVibration(0, 0, ctrl);
                }
                if (buttonState != updatedState)
                {
                    releasedEvent.Invoke();
                }
                ctrlSet.Clear();
                pressTimer = 0;
                break;
        }
        buttonState = updatedState;
    }
    #endregion

    

    #region ITriggerListener functions
    void ITriggerListener.OnTriggerEnter(Collider collider)
    {
        if (!pressed) {
            OVRInput.Controller getCtrl = Player.Instance.GetTouchOVRController(collider);
            ctrlSet.Add(getCtrl);
            UpdateState(PhysicalButtonState.Touch, getCtrl);
        }
        pressRigid.isKinematic = false;
        untouchTimer = 0;
    }

    void ITriggerListener.OnTriggerStay(Collider collider)
    {
        if (buttonState == PhysicalButtonState.Touch) {
            pressTimer -= Time.deltaTime;
        }
        if ((pressRigid.transform.localPosition.z <= 0 && buttonState != PhysicalButtonState.Released) || 
            (pressTimer <= 0 && buttonState == PhysicalButtonState.Touch))
        {
            OVRInput.Controller getCtrl = Player.Instance.GetTouchOVRController(collider);
            ctrlSet.Add(getCtrl);
            UpdateState(PhysicalButtonState.Pressed, getCtrl);
            pressed = true;
            pressRigid.isKinematic = true;
        }
        else if (pressRigid.transform.localPosition.z >= pressJoint.connectedAnchor.z)
        {
            pressRigid.isKinematic = true;
        }
        else {
            pressRigid.isKinematic = false;
        }
        untouchTimer = 0.4f;
    }

    void ITriggerListener.OnTriggerExit(Collider collider)
    {
        OVRInput.Controller getCtrl = Player.Instance.GetTouchOVRController(collider);
        ctrlSet.Add(getCtrl);
        UpdateState(PhysicalButtonState.Released, getCtrl);
        pressRigid.isKinematic = false;
        untouchTimer = 0.4f;
    }
    #endregion
}
