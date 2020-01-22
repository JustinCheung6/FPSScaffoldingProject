using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Make sure the bullet has a rigidbody
    private Rigidbody rb = null;
    [SerializeField] private int damage = 1;
    [SerializeField] private int durationTime = 5;
    [SerializeField] private float moveSpeed = 5f;
    [Tooltip("Set to the Layers of what the bullet needs to attack")]
    public LayerMask targetLayers = new LayerMask();

    private void Awake()
    {
        StartCoroutine(TimeOut(durationTime));
        rb = GetComponent<Rigidbody>();
        //Velocity lets object move constantly
        rb.velocity = transform.forward * moveSpeed;  
    }

    private void OnTriggerEnter(Collider col)
    {
        //Make sure the object doesn't collide with anything when it spawns
        if (col.gameObject.layer == gameObject.layer)
            Debug.Log("Bullet collided with the same layer of itself: " + LayerMask.LayerToName(gameObject.layer) + ".");
        //Set the bullet's layer to the same as the object it spawns with
        if (  targetLayers == (targetLayers | (1 << col.gameObject.layer))  )
        {
            //IDamageable is connected to the EnemyHealth and PlayerHealth scripts
            if(col.gameObject.GetComponent<IDamageable>() != null)
                col.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    //Coroutine allows you to wait for seconds.
    private IEnumerator TimeOut(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
