using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

    }
}
