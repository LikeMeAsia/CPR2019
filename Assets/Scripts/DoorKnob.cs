using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Collider))]
public class DoorKnob : MonoBehaviour
{
    public Animator doorAnim;
    public Animator doorUIAnim;
    public AudioClip doorOpenSound;
    public float doorOpenDelay;
    [SerializeField][ReadOnly]
    private bool doorOpen;
    public bool DoorOpen { get { return doorOpen; } }
    private AudioSource audioSource;
    private Collider handleCollider;

    private void Start()
    {
        doorOpen = false;
        audioSource = this.GetComponent<AudioSource>();
        handleCollider = this.GetComponent<Collider>();
        doorUIAnim.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (!doorOpen && other.CompareTag("Hand") && (Player.Instance.l_ful || Player.Instance.r_ful))
        {
            OpenDoor();
        }
    }

    public void ShowUI() {
        doorUIAnim.gameObject.SetActive(true);
        doorUIAnim.SetBool("disable", false);
    }
    public void HideUI()
    {
        doorUIAnim.SetBool("disable", true);
    }

    public void OpenDoor() {
        if (doorOpen) return;
        doorAnim.SetTrigger("open");
        doorUIAnim.SetBool("disable", true);
        audioSource.PlayOneShot(doorOpenSound);
        //SimpleDirectorController.Instance.PlayTrack(0);
        doorOpen = true;
        handleCollider.enabled = false;
    }
}
