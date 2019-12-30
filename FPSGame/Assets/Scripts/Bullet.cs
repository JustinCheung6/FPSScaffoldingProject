using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Make sure the bullet has a rigidbody
    private Rigidbody rb = null;

    [SerializeField] private int durationTime = 5;
    [SerializeField] private float moveSpeed = 5f;
    [Tooltip("Set to the Layers of what the bullet needs to attack")]
    [SerializeField] private LayerMask targetLayers = new LayerMask();

    private void Awake()
    {
        StartCoroutine(TimeOut(durationTime));
        rb = GetComponent<Rigidbody>();

        //Velocity lets object move constantly
        rb.velocity = transform.forward * moveSpeed;  
    }

    private void OnCollisionEnter(Collision col)
    {
        //Set the bullet's layer to the same as the object it spawns with
        if (col.gameObject.layer == gameObject.layer)
            return;

        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            Destroy(col.gameObject);

        //Make sure the object doesn't collide with anything when it spawns
        Destroy(gameObject);
    }

    private IEnumerator TimeOut(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
