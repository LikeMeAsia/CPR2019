using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionBridge : MonoBehaviour
{
    private ICollisionListener _listener;
    public void Initialize(ICollisionListener l)
    {
        _listener = l;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (_listener == null) return;
        _listener.OnCollisionEnter(collision);
        
    }
    void OnCollisionStay(Collision collision)
    {
        if (_listener == null) return;
        _listener.OnCollisionStay(collision);
    }
    void OnCollisionExit(Collision collision)
    {
        if (_listener == null) return;
        _listener.OnCollisionExit(collision);
    }
}