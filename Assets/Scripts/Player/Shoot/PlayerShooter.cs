using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private float _couldown;

    private BulletPool _bulletPool;
    private EnemyManager _enemyManager;

    [Inject]
    public void Construct(EnemyManager enemyManager, BulletPool bulletPool)
    {
        _enemyManager = enemyManager;
        _bulletPool = bulletPool;
        Debug.Log("Zenject");
        Debug.Log(_enemyManager.Find(transform, 5));
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 position = Random.insideUnitSphere * 5;
            position.y = transform.position.y;
            _enemyManager.Create(position);
        }

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Enemy target = _enemyManager.Find(transform, 6);
            Debug.Log(_enemyManager.Find(transform, 5));
            if (target != null)
            {
                Debug.Log("Target");

                Bullet bullet = _bulletPool.Spawn(_weaponPoint.position, _weaponPoint.rotation);
                Vector3 direction = target.transform.position - _weaponPoint.position;
                bullet.transform.forward = direction; 
                Debug.Log(direction);

                yield return new WaitForSeconds(_couldown);
            }

            yield return null;
        }
    }
}
