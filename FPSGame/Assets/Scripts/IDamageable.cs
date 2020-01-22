using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scripts with an interface will inherit the interface's functions
public interface IDamageable //IDamageable is used in PlayerHealth and EnemyyHealth scripts
{
    void TakeDamage(int damage);

    void Death();
}
