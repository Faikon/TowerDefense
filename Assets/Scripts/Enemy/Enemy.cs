using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public event Action<Enemy> Died;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       Destroy(gameObject);
        Died?.Invoke(this);
    }
}
