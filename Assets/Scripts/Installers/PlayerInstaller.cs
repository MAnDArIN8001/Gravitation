using Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Quaternion _playerInitialRotation;

    [SerializeField] private Transform _playerInitialPosition;

    [SerializeField] private GameObject _player;

    public override void InstallBindings()
    {
        GameObject player = Container.InstantiatePrefab(_player, _playerInitialPosition.position, _playerInitialRotation, null);

        Container.Bind<Player>().FromInstance(player.GetComponent<Player>()).AsSingle().NonLazy();
        Container.Bind<PlayerMover>().FromInstance(player.GetComponent<PlayerMover>()).AsSingle().NonLazy();
    }
}
