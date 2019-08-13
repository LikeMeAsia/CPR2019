using cakeslice;
using UnityEngine;

public class ShakeShoulder : MonoBehaviour
{
    public GameObject shakingUI;
    public int maxHit;

    private int countShake;
    private Collider[] shoulderColliders;
    private Outline[] outlines;
    [SerializeField][ReadOnly]
    private bool shaking;
    public bool Shaking { get { return shaking; } }

    void Start()
    {
        shoulderColliders = GetComponentsInChildren<Collider>();
        outlines = GetComponentsInChildren<Outline>();
        countShake = 0;
        shaking = false;
        SetActiveShoulderIput(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            countShake++;
            Debug.Log("Shake!" + countShake + "/"+ maxHit) ;
            if (countShake >= maxHit)
            {
                shaking = true;
                shakingUI.SetActive(false);
                SetActiveShoulderIput(false);
            }
        }
    }
    
    public void EnableInputRecieve()
    {
        countShake = 0;
        shaking = false;
        SetActiveShoulderIput(true);
    }

    private void SetActiveShoulderIput(bool value) {
        shakingUI.SetActive(value);
        foreach (Collider col in shoulderColliders)
        {
            col.enabled = value;
        }
        foreach (Outline outline in outlines)
        {
            outline.enabled = value;
        }
    }
}
