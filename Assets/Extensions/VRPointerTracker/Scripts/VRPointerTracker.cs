using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRPointerTracker : MonoBehaviour
{
    private static VRPointerTracker instance;
    public static VRPointerTracker Instance {
        get { return instance; }
    }

    [SerializeField]
    [ReadOnly]
    private RectTransform pointerCtr;
    [SerializeField]
    [ReadOnly]
    Canvas canvas;
    [SerializeField]
    [ReadOnly]
    private GameObject target;

    public bool removeTarget;

    public Action lookInvoke; 

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pointerCtr = this.transform.Find("ArrowCtr").gameObject.GetComponent<RectTransform>();
        canvas = this.GetComponent<Canvas>();
    }

    void Update()
    {
        if (target != null && target.activeInHierarchy)
        {
            if (IsTargetRaycasted())
            {
                canvas.enabled = false;
                if (lookInvoke!=null) {
                    lookInvoke.Invoke();
                }
                if (removeTarget) {
                    RemoveTarget();
                }
            } else {
                canvas.enabled = true;
                Quaternion rot = Quaternion.LookRotation(target.transform.position - Camera.main.transform.position, Camera.main.transform.forward);
                pointerCtr.rotation = rot;
                rot = pointerCtr.localRotation;
                rot.x = 0;
                rot.y = 0;
                pointerCtr.localRotation = rot;
            }
        }
        else
        {
            canvas.enabled = false;
        }
    }

    public void SetTarget( GameObject i_target, Action i_lookInvoke ,bool i_remove = false) {
        target = i_target;
        removeTarget = i_remove;
        lookInvoke = i_lookInvoke;
    }

    public void SetTarget(GameObject i_target, bool i_remove)
    {
        SetTarget(i_target, null, i_remove);
    }

    public void SetTarget(GameObject i_target)
    {
        SetTarget(i_target, null);
    }

    public void RemoveTarget()
    {
        target = null;
    }

    private bool IsTargetRaycasted()
    {
        bool isRaycasted = false;
        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if (results.Count > 0)
        {
            foreach (RaycastResult result in results) {
                if (target == result.gameObject) {
                    isRaycasted = true;
                    break;
                }
            }
            GameObject root = results[results.Count - 1].gameObject;
            if (!isRaycasted) { // try check is it parent?
                while (root.transform.parent != null) {
                    if (target == root) {
                        isRaycasted = true;
                        break;
                    }
                    root = root.transform.parent.gameObject;
                }
            }
        }
        results.Clear();
        return isRaycasted;
    }
}
