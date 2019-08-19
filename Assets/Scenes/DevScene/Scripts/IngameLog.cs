using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameLog : MonoBehaviour
{
    [Header("Ingame Log")]
    public List<string> Log;
    public string printText = "";

    public Text text;
    public bool dubugFlood = false;

    [Header("Hooked Event Params")]
    public string output = "";
    public string stack = "";

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void Start()
    {

    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (Log.Count > 10)
        {
            Log.RemoveAt(0);
        }
        Log.Add(logString);
        printText = "";
        foreach (string logtext in Log)
        {
            printText = printText + '\n' + logtext;
        }

        text.text = printText;
    }

    private void Update()
    {
        if (dubugFlood)
        {
            if (OVRInput.GetDown(OVRInput.Button.Any))
            {
                Debug.Log("Clickity Clackity " + Random.Range(0.1f, 100f));
            }
        }
        
    }
}
