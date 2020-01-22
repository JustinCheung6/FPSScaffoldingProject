using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Tooltip("Time before enemy shoots.")]
    [SerializeField] private float shootDelay = 3f;

    [Tooltip("Prefab of the enemy bullet")]
    [SerializeField] private GameObject bullet = null;
    [Tooltip("Point where the bullet spawn")]
    [SerializeField] private Transform spawnpoint = null;
    void Start()
    {
        StartCoroutine(Shoot());
    }
    //The enemy will create a bullet every few seconds. (IEnumerator will allow functions to wait for seconds)
    private IEnumerator Shoot()
    {
        //The functions will wait this amount of seconds
        yield return new WaitForSeconds(shootDelay);
        Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
        //Repeat the Coroutine function
        StartCoroutine(Shoot());
    }
}
