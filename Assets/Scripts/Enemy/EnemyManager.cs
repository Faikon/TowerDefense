using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager 
{
    private readonly Enemy _enemyPrefab;
    private List<Enemy> _enemies = new();

    public EnemyManager(Enemy enemy)
    {
        _enemyPrefab = enemy;      
    }

    public void Create(Vector3 point)
    {
       Enemy enemy =  Object.Instantiate(_enemyPrefab, point, Quaternion.identity);
        _enemies.Add(enemy);
        enemy.Died += Destroy;
        
    }

    private void Destroy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.Died -= Destroy;
    }

    public void Add(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public Enemy Find(Transform playerTransform, float playerRadius)
    {
        return CommonHandler.Find<Enemy>(_enemies, playerTransform, playerRadius);
    }
}
