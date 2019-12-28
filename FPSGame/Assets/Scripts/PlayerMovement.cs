using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //Converts input to move player depending on the direction it's facing
        Vector3 x = moveSpeed * Input.GetAxis("Horizontal") * transform.right;
        Vector3 z = moveSpeed * Input.GetAxis("Vertical") * transform.forward;

        //deltaTime locks player at the same speed regardless of framerate
        transform.position += (x + z) * Time.deltaTime;
    }
}
