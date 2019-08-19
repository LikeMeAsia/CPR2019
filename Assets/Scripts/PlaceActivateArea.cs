using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class PlaceActivateArea : MonoBehaviour
{
    public Rigidbody targetObject;
    public bool placeable;
    public Image areaImage;
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.red;
    public UnityEvent activeEvents;
    public bool isActivated;
    public Collider[] colliders;

    private void Awake()
    {
        colliders = this.GetComponents<Collider>();
    }

    void Start()
    {
        placeable = false;
        isActivated = false;
        foreach (Collider col in colliders) {
            col.isTrigger = true;
            col.enabled = true;
        }
    }

    public void SetActive(bool value) {
        gameObject.SetActive(value);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActivated) return;
        if (other.gameObject == targetObject.gameObject)
        {
            if (targetObject.isKinematic) {
                placeable = true;
                areaImage.color = hoverColor;
            }
            if (placeable && !targetObject.isKinematic)
            {
                isActivated = true;
                areaImage.gameObject.SetActive(false);
                foreach (Collider col in colliders)
                {
                    col.enabled = false;
                }
                activeEvents.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActivated) return;
        if (other.gameObject == targetObject.gameObject)
        {
            placeable = false;
            areaImage.color = defaultColor;
        }
    }
}
