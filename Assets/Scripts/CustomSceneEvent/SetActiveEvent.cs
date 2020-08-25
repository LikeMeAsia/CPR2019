using UnityEngine;

namespace com.dgn.SceneEvent.Sample
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SetActiveEvent", menuName = "SceneEvent/SetActiveEvent", order = 1)]
    public class SetActiveEvent : SceneEvent
    {
        public enum ActiveType { ToActive, ToDeactive }
        public string assetName;
        public ActiveType type;
        public SceneEvent nextScene;

        private SceneAsset target;

        public override void InitEvent()
        {
            base.InitEvent();
            bool found = SceneAssetManager.GetAsset(assetName, out target);
            if (nextScene) nextScene.InitEvent();
        }

        public override void StartEvent()
        {
            if (target != null)
            {
                switch (type)
                {
                    case ActiveType.ToActive:
                        target.gameObject.SetActive(true);
                        break;
                    case ActiveType.ToDeactive:
                        target.gameObject.SetActive(false);
                        break;
                }
                passEventCondition = true;
            }
        }

        public override void UpdateEvent() { }
        public override void StopEvent() { }

        public override bool Skip() {
            return true;
        }

        public override SceneEvent NextEvent()
        {
            return nextScene;
        }

    }
}