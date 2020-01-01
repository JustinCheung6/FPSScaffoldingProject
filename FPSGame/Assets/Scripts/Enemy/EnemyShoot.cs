using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Tooltip("Time before enemy shoots.")]
    [SerializeField] private float shootDelay = 3f;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform spawnpoint = null;
    void Start()
    {
        StartCoroutine(Shoot());
    }
    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootDelay);
        Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);

        StartCoroutine(Shoot());
    }
}
