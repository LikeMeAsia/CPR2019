using UnityEngine;
using UnityEngine.Events;


public class ButtonBehaviour : MonoBehaviour
{
    public LayerMask layermask;
    public UnityEvent OnPress = null;

    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private bool previousPress = false;

    private Collider hoverInteractor;
    private float previousHandHeight = 0.0f;
    
    private void Start()
    {
        SetMinMax();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        StartPress(other);
    }

    private void OnTriggerExit(Collider other)
    {
        EndPress(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (hoverInteractor)
        {
            float newHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);

            CheckPress();
        }
    }

    private void StartPress(Collider interactor)
    {
        if (layermask == (layermask | (1 << interactor.gameObject.layer)) && hoverInteractor == null) {
            hoverInteractor = interactor;
            previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
        }
    }

    private void EndPress(Collider interactor)
    {
        hoverInteractor = null;
        previousHandHeight = 0.0f;
        previousPress = false;
        SetYPosition(yMax);
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        yMax = transform.localPosition.y;
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);
        return localPosition.y;
    }

    private void SetYPosition(float yPos)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(yPos, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();
        if (inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();
        }
    }

    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMax + 0.01f);
        return transform.localPosition.y == inRange;
    }
}
