using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorKnob : MonoBehaviour
{
    public Player player;
    public Animator doorAnim;
    public bool doorOpen;

    private void Start()
    {
        doorOpen = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (!doorOpen && other.CompareTag("hand") && (player.l_ful || player.r_ful))
        {
            doorAnim.SetTrigger("open");
            doorOpen = true;
            SimpleDirectorController.Instance.PlayTrack(0);
        }
    }
}
