﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace VRProcedure
{
    [Serializable] public sealed class AudioPlayerEvent : UltEvents.UltEvent<AudioClip> { }

    public class VRProcessController : MonoBehaviour
    {
        [Serializable]
        public class VRProcess
        {
            [Header("Process Action")]
            public UltEvents.UltEvent procActions;

            [Header("Tracker")]
            public bool enableTracker;
            [ConditionalHide("enableTracker", true)]
            public GameObject trackerTarget;
            [ConditionalHide("enableTracker", true)]
            public bool trackerHoverRemove;
            public UnityEvent trackerHoverAction;

        }

        [SerializeField]
        [ReadOnly]
        int procIter;

        [Header("Process Start")]
        [Tooltip("This process will be run when call Start() or RestartProcess()")]
        public UltEvents.UltEvent procStart;
        public bool runOnAwake;

        [Header("Process Queue")]
        [Tooltip("This process will be run in order when call RunNextProcess()")]
        [LabelArray("Queue")]
        public VRProcess[] procQueue;

        private Coroutine nextProcessCoroutine;
        private bool nextProcessCoroutineRunning;

        public void Start()
        {
            nextProcessCoroutineRunning = false;
            procIter = 0;
            if (runOnAwake) {
                procStart.InvokeSafe();
            }
        }

        public void ResetProcess()
        {
            procIter = 0;
            procStart.InvokeSafe();
        }

        public void StartProcess(){
            ResetProcess();
            RunProcess(procQueue[procIter]);
        }

        public void RunNextProcess() {
            if (nextProcessCoroutineRunning)
            {
                StopCoroutine(nextProcessCoroutine);
                AudioPlayer.Stop();
            }
            nextProcessCoroutineRunning = false;
            procIter = procIter + 1;
            if (!(procIter >= 0 && procIter < procQueue.Length)) { return; }
            RunProcess(procQueue[procIter]);
        }

        private void RunProcess(VRProcess process) {
            if (process == null || process.procActions == null) {
                return;
            }
            process.procActions.InvokeSafe();
            if (process.enableTracker) {
                VRPointerTracker.Instance.SetTarget(process.trackerTarget, 
                    delegate { process.trackerHoverAction.Invoke(); }, process.trackerHoverRemove);
            }
        }

        public void PlayClipThenRunNextProcess(AudioClip clip)
        {
            if (clip != null)
            {
                AudioPlayer.PlayAudioClip(clip);
                nextProcessCoroutine = this.CallFuncWait(delegate { RunNextProcess(); }, clip.length + 0.1f);
            }
            else {
                nextProcessCoroutine = this.CallFuncWait(delegate { RunNextProcess(); }, 0.1f);
            }
            nextProcessCoroutineRunning = true;
        }

        public void Skip() {
            if (!nextProcessCoroutineRunning) {
                return;
            }
            StopCoroutine(nextProcessCoroutine);
            AudioPlayer.Stop();
            nextProcessCoroutineRunning = false;
            RunNextProcess();
        }

        public bool OnExecuteProcessCoroutine() {
            return nextProcessCoroutineRunning;
        }

        public void SetActiveChildren(GameObject parent, bool isActive) {
            for(int i=0; i<parent.transform.childCount; i++) {
                parent.transform.GetChild(i).gameObject.SetActive(isActive);
            }
        }
    }
}