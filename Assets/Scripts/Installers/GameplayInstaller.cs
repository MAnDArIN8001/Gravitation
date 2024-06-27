using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private LevelManager _levelManager;

    [SerializeField] private ScenManager _sceneManager;

    public override void InstallBindings()
    {
        Container.Bind<ScenManager>().FromInstance(_sceneManager).AsSingle().NonLazy();

        var levelManager = Container.InstantiatePrefab(_levelManager.gameObject, Vector3.zero, Quaternion.identity, null);
        Container.Bind<LevelManager>().FromInstance(levelManager.GetComponent<LevelManager>()).AsSingle().NonLazy();
    }
}
