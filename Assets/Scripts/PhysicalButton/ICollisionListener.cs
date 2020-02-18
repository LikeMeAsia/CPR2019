using UnityEngine;

public interface ICollisionListener
{
    void OnCollisionEnter(Collision collision);
    void OnCollisionStay(Collision collision);
    void OnCollisionExit(Collision collision);
}