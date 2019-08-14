using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatIndicator : MonoBehaviour
{
    public Image outerRing;
    public Image circle;
    public Image innerRing;
    private Color defaultColor;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        defaultColor = circle.color;
    }

    public void Reset()
    {
        circle.color = defaultColor;

    }
}
