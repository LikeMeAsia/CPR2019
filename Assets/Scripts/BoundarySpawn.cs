using com.dgn.UnityAttributes;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class BoundarySpawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public Collider boundary;
    [SerializeField][ReadOnly]
    private bool inBoundary;
    private Collider col;
    private Rigidbody rigid;
    private float timer;
    private readonly float respawnTime = 1;

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
                Respawn();
            }
        }
    }

    public void Respawn() {
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        inBoundary = boundary.bounds.Intersects(col.bounds);
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
