using System.Collections;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;


public class ComplexityManager
{
    private IComplexityAdjuster[] _complexityAdjusters;
    private float _complexity = 1f;
    private MonoBehaviour _context;
    private Player _player;
    
    [Inject]
    private void Inject(IComplexityAdjuster[] complexityAdjusters, Player player, MonoBehaviour context)
    {
        _complexityAdjusters = complexityAdjusters;
        _player = player;
        _player.OnCollideWithLevelLayer += ComplexityUpdate;
    }

    private void ComplexityUpdate()
    {
        _complexity *= 1.001f;

        foreach (var complexityAdjuster in _complexityAdjusters)
        {
            complexityAdjuster.SetComplexity(_complexity);
        }
    }
    
    
}
