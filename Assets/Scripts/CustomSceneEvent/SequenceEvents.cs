using UnityEngine;

namespace com.dgn.SceneEvent.Sample
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SequenceEvents", menuName = "SceneEvent/SequenceEvents", order = 1)]
    public class SequenceEvents : SceneEvent
    {
        public SceneSubEvent[] subEvents;

        private int eventIter;
        private bool callNextProc;
        private float delayProc;
        private bool skip;

        private bool bigSkip;
        private float bigSkipTimer;
        private float bigSkipTime = 1f;

        public SceneEvent nextEvent;

        public override void InitEvent()
        {
            base.InitEvent();
            foreach (SceneSubEvent sceneEvent in subEvents)
            {
                sceneEvent.InitEvent();
            }
            eventIter = 0;
            skip = false;
            bigSkip = false;
            callNextProc = true;
            if (nextEvent) nextEvent.InitEvent();
        }

        public override void StartEvent()
        {
            eventIter = 0;
            skip = false;
            bigSkip = false;
            callNextProc = true;
        }

        public override void UpdateEvent()
        {
            if (bigSkipTimer > 0) {
                bigSkipTimer -= Time.deltaTime;
            }
            if (delayProc > 0)
            {
                delayProc -= Time.deltaTime;
                return;
            }
            if (eventIter >= subEvents.Length)
            {
                passEventCondition = true;
                return;
            }
            if (callNextProc)
            {
                callNextProc = false;
                subEvents[eventIter].StartEvent();
            }
            else
            {
                subEvents[eventIter].UpdateEvent();
                if (subEvents[eventIter].CheckPassEventCondition())
                {
                    subEvents[eventIter].StopEvent();
                    delayProc = subEvents[eventIter].GetDelayNextEvent();
                    eventIter++;
                    callNextProc = true;
                }
            }
            if (skip && !callNextProc)
            {
                bool skipped = subEvents[eventIter].Skip();
                bigSkip = bigSkip && skipped;
                skip = bigSkip;
            }
        }
        
        public override void StopEvent() { }

        public override bool Skip()
        {
            skip = true;
            if (bigSkipTimer > 0) {
                bigSkip = true;
            }
            bigSkipTimer = bigSkipTime;
            return skip;
        }

        public override void Pause() { }
        public override void UnPause() { }

        public override SceneEvent NextEvent()
        {
            return nextEvent;
        }
    }
}