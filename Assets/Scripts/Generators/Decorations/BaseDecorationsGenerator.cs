using System.Collections;
using UnityEngine;
using Zenject;

public class BaseDecorationsGenerator : DecorationGenerator
{
    [SerializeField] protected int _generationStepsMax;
    [SerializeField] protected int _generationStepsMin;
    [SerializeField] private int _currentStepsCount;
    [SerializeField] private int _randomStepsCount;

    private Player _player;

    [Inject]
    private void Initialize(Player player)
    {
        _player = player;

        _randomStepsCount = Random.Range(_generationStepsMin, _generationStepsMax);
    }

    private void OnEnable()
    {
        _player.OnCollideWithLevelLayer += HandleNewStep;
    }

    private void OnDisable()
    {
        _player.OnCollideWithLevelLayer -= HandleNewStep;
    }

    private void HandleNewStep()
    {
        if (_currentStepsCount >= _randomStepsCount)
        {
            _currentStepsCount = 0;
            _randomStepsCount = Random.Range(_generationStepsMin, _generationStepsMax);

            GenerateDecoration();

            return;
        }

        _currentStepsCount++;
    }

    protected override void GenerateDecoration()
    {
        GameObject randomDecoration = GetRandomDecoration();

        Vector2 randomSpawnPosition = GetRandomSpawnPosition();

        Instantiate(randomDecoration, randomSpawnPosition, Quaternion.identity);
    }

    private GameObject GetRandomDecoration()
    {
        int randomDecorationIndex = Random.Range(0, _decorations.Length);

        return _decorations[randomDecorationIndex];
    }

    private Vector2 GetRandomSpawnPosition()
    {
        float randomXPosition = Random.Range(_leftBorderPoint.position.x, _rightRandomPoint.position.x);

        return new Vector2(randomXPosition, transform.position.y);
    }
}
