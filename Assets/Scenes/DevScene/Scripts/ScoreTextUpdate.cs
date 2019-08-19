using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextUpdate : MonoBehaviour
{
    public RhythmController controller;
    public Text text;

    private void Update()
    {
        text.text = "COMBO : " + controller.combo + '\n' +
            "MAX COMBO : " + controller.maxCombo + '\n' +
            "PERFECT : " + controller.perfectHit + '\n' +
            "GOOD : " + controller.goodHit + '\n' +
            "MISS : " + controller.missHit + '\n' +
            "TOTAL HIT : " + controller.perfectHit+controller.goodHit;
    }
}
