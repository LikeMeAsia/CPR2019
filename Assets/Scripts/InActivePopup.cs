using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InActivePopup : MonoBehaviour
{
    public float timeLeft = 0;
    public float timeTillDisappear = 1;

    void Start()
    {
        timeLeft = timeTillDisappear;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        timeLeft = timeTillDisappear;
    }

}
