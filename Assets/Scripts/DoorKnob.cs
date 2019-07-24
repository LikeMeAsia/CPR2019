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
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Door Knob Triggered:"+ other.name+"[" + other.tag+"]");
        if (!doorOpen && other.CompareTag("Hand") && (player.l_ful || player.r_ful))
        {
            OpenDoor();
        }
    }

    public void OpenDoor() {
        if (doorOpen) return;
        doorAnim.SetTrigger("open");
        doorOpen = true;
        SimpleDirectorController.Instance.PlayTrack(0);
        this.enabled = false;
    }
}
