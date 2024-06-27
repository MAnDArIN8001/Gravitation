using UnityEngine;
using Zenject;

public class LevelPickerInstaller : MonoInstaller
{
    [SerializeField] private ScenManager _scenManager;
    
    public override void InstallBindings()
    {
        Container
            .Bind<ScenManager>()
            .FromInstance(_scenManager)
            .AsSingle()
            .Lazy();
    }
}