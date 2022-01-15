using com.dgn.SceneEvent;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SceneEventController))]
public class SceneEventListener : MonoBehaviour
{
    SceneEventController eventController;
    public XRInputReceiver leftCtrl;
    public XRInputReceiver rightCtrl;
    private float timer = 0;
    private readonly float skipTime = 0.45f;
    
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
                    if (SceneEventController.Instance.IsCurrentEventAvailable)
                    {
                        if (timer > 0)
                        {
                            timer = 0;
                            SceneEventController.Instance.SkipEvent();
                        }
                        else
                        {
                            timer = skipTime;
                        }
                    }
                }
                else
                {
                    SceneEventController.Instance.StartEvent();
                }
            }
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private bool AllComponentsReady() {
        return SceneEventController.Instance && Player.Instance && Player.Instance.ready;
    }
}
