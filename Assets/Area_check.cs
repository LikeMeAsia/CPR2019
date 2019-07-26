using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Area_check : MonoBehaviour
{
    public GameObject Phone_spawn;
    public bool inBoundary;
    public Collider areaCollider;
    Collider col;
    Rigidbody rigid;
    float timer;
    float respawnTime = 1;

    private void Start()
    {
        col = GetComponent<Collider>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (timer > 0) {
            timer = timer - Time.deltaTime;
            if (timer < 0) {
                transform.position = Phone_spawn.transform.position;
                transform.rotation = Phone_spawn.transform.rotation;
                rigid.velocity = Vector3.zero;
                rigid.angularVelocity = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        inBoundary = areaCollider.bounds.Intersects(col.bounds);
        if (!rigid.isKinematic && collision.gameObject.tag == "Ground" && !inBoundary)
        {
            timer = respawnTime;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            timer = 0;
        }
    }
}
