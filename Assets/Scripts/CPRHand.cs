using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRHand : MonoBehaviour
{
    public Player player;
    public GameObject l_handIsUnder;
    public GameObject r_handIsUnder;
    // Start is called before the first frame update
    void Start()
    {
        l_handIsUnder.SetActive(false);
        r_handIsUnder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.l_handIsUnder)
        {
            l_handIsUnder.SetActive(true);
            r_handIsUnder.SetActive(false);
        }
        else
        {
            r_handIsUnder.SetActive(true);
            l_handIsUnder.SetActive(false);
        }
    }
}
