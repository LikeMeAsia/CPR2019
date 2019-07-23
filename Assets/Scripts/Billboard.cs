
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Billboard : MonoBehaviour
{

    [Header("Player Settings")]
    GameObject Player; // gameobject player
    Transform player; // the Object the player is controlling

    [Header("GameObject Calculations Settings")]
    public float facePlayerfactor = 20f; // angle of facing player

    void Start()
    {
        Player = GameObject.FindWithTag("Player"); // find the gameobject with the tag of Player.
        player = Player.GetComponent<Transform>(); // from the gameobject of player get the transform
    }

    // The function to billboard this object to face the player
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerfactor);
    }
}