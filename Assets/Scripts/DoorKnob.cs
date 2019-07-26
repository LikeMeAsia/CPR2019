using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorKnob : MonoBehaviour
{
    public Animator doorAnim;
    public bool doorOpen;

    private void Start()
    {
        doorOpen = false;
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
        if (!doorOpen && other.CompareTag("Hand") && (Player.Instance.l_ful || Player.Instance.r_ful))
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
