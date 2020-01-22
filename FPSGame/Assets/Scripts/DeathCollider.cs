using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    //Kills anything with a IDamageable script (EnemyHealth and PlayerHealth script)
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<IDamageable>() != null)
            col.gameObject.GetComponent<IDamageable>().Death();
    }
}
