﻿using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerDoCPRHandEvent", menuName = "SceneEvent/PlayerDoCPRHandEvent")]
public class PlayerDoCPRHandEvent : SceneEvent
{
    public string assetName;
    private SceneAssetManager.SceneAsset uiAsset;
    private Animator cprUIAnim;


    public override void InitEvent()
    {
        base.InitEvent();
        bool found = SceneAssetManager.GetAssetComponent<Animator>(assetName, out cprUIAnim);
        Debug.Log("Found UI CPR[" + assetName + "]: " + found);
        if (cprUIAnim != null)
        {
            cprUIAnim.SetBool("enable", false);
        }
        else { Debug.Log("it's nulllll"); }
    }

    public override void StartEvent()
    {
        InitEvent();
        if (cprUIAnim != null)
        {
            //add debug here
            cprUIAnim.SetBool("enable", true);
        }

        if (CPRHand.Instance == null)
        {
            passEventCondition = true;
        }
        else if(uiAsset.gameObject != null)
        {
            uiAsset.gameObject.SetActive(true);
            Player.Instance.cprHand.enabledSnap = true;
        }
    }

    public override void UpdateEvent()
    {
        if (CPRHand.Instance != null && CPRHand.Instance.snaping)
        {
            passEventCondition = true;
        }
    }

    public override void StopEvent()
    {
        if (uiAsset.gameObject != null)
        {
            uiAsset.gameObject.SetActive(false);
        }
    }

    public override bool Skip()
    {
        return false;
    }
}
