using UnityEngine;

public class ScenarioControl : MonoBehaviour
{
    private static ScenarioControl instance;
    public static ScenarioControl Instance { get { return instance; } }

    public void Awake()
    {
        instance = this;
    }

    #region Variable
    [Header("Hand Gesture Tutorial")]
    public SceneEvent[] sceneEvents;
    private int eventIter;
    private SceneEvent SceneEvent { get { return sceneEvents[eventIter]; } }

    [Header(" ")]
    public int procIter;
    public bool callNextProc;
    public float delayProc;
    [Header(" ")]
    public bool skip;

    #endregion

    void Start()
    {
        eventIter = 0;
        callNextProc = true;
        delayProc = 0;
        skip = false;
        foreach (SceneEvent sceneEvent in sceneEvents)
        {
            sceneEvent.InitEvent();
        }
    }

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.Start) || Input.GetKeyUp(KeyCode.S)) {
            skip = true;
        }

        if (delayProc > 0)
        {
            delayProc -= Time.deltaTime;
            return;
        }
        if (eventIter >= sceneEvents.Length)
        {
            return;
        }
        if (callNextProc)
        {
            callNextProc = false;
            skip = false;
            SceneEvent.StartEvent();
        }
        else
        {
            SceneEvent.UpdateEvent();
            if (SceneEvent.CheckPassEventCondition())
            {
                SceneEvent.StopEvent();
                delayProc = SceneEvent.GetDelayNextEvent();
                eventIter++;
                callNextProc = true;
            }
        }
        if (skip)
        {
            SceneEvent.Skip();
            skip = false;
        }
    }
}
