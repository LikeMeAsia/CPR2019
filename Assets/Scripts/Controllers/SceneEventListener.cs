using com.dgn.SceneEvent;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SceneEventController))]
public class SceneEventListener : MonoBehaviour
{
    SceneEventController eventController;
    public XRInputReceiver leftCtrl;
    public XRInputReceiver rightCtrl;
    
    void Start()
    {
        eventController = GetComponent<SceneEventController>();
    }
    
    void Update()
    {
        if (AllComponentsReady())
        {
            if (leftCtrl && leftCtrl.GetKeyDown(XRInputReceiver.KEY.Menu))
            {
                if (SceneEventController.Instance.IsEventStart)
                {
                    if(SceneEventController.Instance.IsCurrentEventAvailable)
                        SceneEventController.Instance.SkipEvent();
                }
                else
                {
                    SceneEventController.Instance.StartEvent();
                }
            }

        }
    }

    private bool AllComponentsReady() {
        return SceneEventController.Instance && Player.Instance && Player.Instance.ready;
    }
}
