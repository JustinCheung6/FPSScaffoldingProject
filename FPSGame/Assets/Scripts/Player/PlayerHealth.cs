using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    //Used for when adding health is implemented
    private int maxHealth;
    [SerializeField] private int health = 10;

    //Red overlay when player gets hurt
    [SerializeField] private GameObject redScreen;
    private void Start()
    {
        maxHealth = health;
        redScreen.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(RedScreen());
        if (health <= 0)
            Death();
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator RedScreen()
    {
        redScreen.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        redScreen.SetActive(false);
    }
}
