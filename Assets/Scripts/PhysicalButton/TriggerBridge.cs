using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerBridge : MonoBehaviour
{
    private ITriggerListener _listener;
    public void Initialize(ITriggerListener l)
    {
        _listener = l;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (_listener == null) return;
        _listener.OnTriggerEnter(collider);

    }
    void OnTriggerStay(Collider collider)
    {
        if (_listener == null) return;
        _listener.OnTriggerStay(collider);
    }
    void OnTriggerExit(Collider collider)
    {
        if (_listener == null) return;
        _listener.OnTriggerExit(collider);
    }
}
