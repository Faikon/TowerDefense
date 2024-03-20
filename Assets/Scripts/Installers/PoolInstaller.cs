using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [SerializeField] private Bullet _bulletPrefab;

    public override void InstallBindings()
    {
        Container.Bind<BulletPool>().FromInstance(new BulletPool(_bulletPrefab)).AsSingle();
    }
}