using UnityEngine;

public interface ITriggerListener
{
    void OnTriggerEnter(Collider collider);
    void OnTriggerStay(Collider collider);
    void OnTriggerExit(Collider collider);
}
