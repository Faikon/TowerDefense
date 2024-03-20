using UnityEngine;
using Zenject;


public class Pool<T>
{
    public GameObject prefab;
    public T prefabs;

    public Pool(T pre)
    {
        this.prefab = prefab;
    }
    //Spawn
    //Despawm
}

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerShooter _playerShooter;
    [SerializeField] private Enemy _enemies;

    [SerializeField] private GameObject _prefab;


    public override void InstallBindings()
    {
        Container.Bind<Enemy>().FromInstance(_enemies).AsSingle();
        Container.Bind<EnemyManager>().AsSingle();
        Container.Bind<PlayerShooter>().FromInstance(_playerShooter).AsSingle();



        //pool
        //Container.Bind<Pool>().FromInstance(new Pool(_prefab)).AsSingle();
        Container.Bind<Pool<Enemy>>().FromInstance(new Pool<Enemy>(_enemies)).AsSingle();
    }
}