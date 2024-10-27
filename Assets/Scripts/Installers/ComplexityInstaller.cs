using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ComplexityInstaller: MonoInstaller
    {
        public List<GameObject> _complexityAdjusters;
        public MonoBehaviour context;
        public override void InstallBindings()
        {
            Container
                .Bind<MonoBehaviour>()
                .FromInstance(context)
                .AsSingle();
            
            foreach (var gameObject in _complexityAdjusters)
            {
                if(gameObject.TryGetComponent<IComplexityAdjuster>(out var complexityAdjuster))
                {
                    Container
                        .Bind<IComplexityAdjuster>()
                        .FromInstance(complexityAdjuster)
                        .AsSingle();
                }
                else
                {
                    Debug.LogError($"GameObject '{gameObject.name}' does not have a component implementing IComplexityAdjuster. Please ensure the component is attached.");
                }
            }

            Container
                .Bind<ComplexityManager>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}