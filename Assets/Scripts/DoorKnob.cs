using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorKnob : MonoBehaviour
{
    public Animator doorAnim;
    public AudioClip doorOpenSound;
    public bool doorOpen;
    private AudioSource audioSource;

    private void Start()
    {
        doorOpen = false;
        audioSource = this.GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(doorOpenSound);
        doorOpen = true;
        this.enabled = false;
    }
}
