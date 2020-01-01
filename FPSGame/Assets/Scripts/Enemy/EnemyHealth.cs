using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 10;
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Death();
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
