using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    //Make sure the player has a PlayerHealth script
    private GameObject player = null;
    [Range(0.00f, 1.00f)]
    [SerializeField] private float rotationSpeed = 0.2f;
    void Start()
    {
        //The script will get the first object it can find with the PlayerHealth script.
        if (player == null)
            player = FindObjectOfType<PlayerHealth>().gameObject;
    }
    void Update()
    {
        //Unit vector that points from enemy to the player
        Vector3 _forward = (player.transform.position - transform.position).normalized;
        //Turn the direction vector to a quaternion
        Quaternion target = Quaternion.LookRotation(_forward);
        //Slowly turn to that rotation 
        transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed);
    }
}
