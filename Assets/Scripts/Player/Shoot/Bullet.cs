using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    public event Action<Bullet> Died;

    private void Update()
    {
        transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        //transform.position += transform.forward * 10 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Died?.Invoke(this);
        }
    } 
}
