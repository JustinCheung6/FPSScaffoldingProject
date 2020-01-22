using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 10;
    [SerializeField] private GameObject enemyModelObject;
    [Tooltip("The enemy's material will change to this when injured, then back to the material it started with.")]
    [SerializeField] private Material injuredMaterial;

    private Material startMaterial;

    private void Start()
    {
        startMaterial = enemyModelObject.GetComponent<Renderer>().material;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(ChangeMaterial());
        if (health <= 0)
            Death();
    }
    public void Death()
    {
        Destroy(gameObject);
    }

    //Makes the Enemies flash red when injured
    private IEnumerator ChangeMaterial()
    {
        enemyModelObject.GetComponent<Renderer>().material = injuredMaterial;
        yield return new WaitForSeconds(0.05f);
        enemyModelObject.GetComponent<Renderer>().material = startMaterial;
    }

}
