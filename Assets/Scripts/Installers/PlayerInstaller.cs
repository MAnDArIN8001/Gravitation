using Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Quaternion _playerInitialRotation;

    [SerializeField] private Transform _playerInitialPosition;

    [SerializeField] private GameObject _player;
    
    [SerializeField] private PlayerForcer _playerForcer;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<InputManager>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        
        GameObject player = Container
            .InstantiatePrefab(_player, 
                _playerInitialPosition.position, 
                _playerInitialRotation, 
                null);

        Container
            .Bind<Player>()
            .FromInstance(player.GetComponent<Player>())
            .AsSingle()
            .NonLazy();
        

        Container
            .BindInterfacesAndSelfTo<PlayerMover>()
            .FromInstance(player.GetComponent<PlayerMover>())
            .AsSingle();
        
        Container
            .BindInterfacesAndSelfTo<PlayerForcer>()
            .FromInstance(_playerForcer)
            .AsSingle();
    }
}
