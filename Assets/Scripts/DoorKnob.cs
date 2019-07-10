using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnob : MonoBehaviour
{
    public Player player;
    public Animator doorAnim;
    public bool doorOpen;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("hand") && (player.l_ful || player.r_ful))
        {
            doorAnim.SetBool("open", true);
            doorOpen = true;
        }
    }
}
