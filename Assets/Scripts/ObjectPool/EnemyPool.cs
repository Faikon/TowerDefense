using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : BasePool<Enemy>
{
    public EnemyPool(Enemy prefab) : base(prefab)
    {
    }

    protected override void OnDespawn(Enemy despawnObject)
    {
        throw new System.NotImplementedException();
    }

    protected override void OnSpawn(Enemy spawnObject)
    {
        throw new System.NotImplementedException();
    }
}
