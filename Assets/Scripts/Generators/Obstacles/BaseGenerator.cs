using Interfaces;
using UnityEngine;

public class BaseGenerator : Generator, IComplexityAdjuster 
{
    [SerializeField] private int _startPlanetsCount;
    [SerializeField] private float _rotationSpeed = 0;

    private float _rotationSpeedCashed = 0;
    
    private void Awake()
    {

        _rotationSpeedCashed = _rotationSpeed;
        
        for (int i = 0; i < _startPlanetsCount; i++)
        {
            GenerateObstacle();
            MakeOffsetStep();
        }
    }
    protected override void GenerateObstacle()
    {
        var randomPlanet = GetRandomPlanet();
        var row = GetRandomRow();
        
        var planetGameObject = Instantiate(randomPlanet, row.position, Quaternion.identity);
        
        planetGameObject.RotationSpeed = _rotationSpeedCashed;


        GenerateLevelLayer();
    }

    private void GenerateLevelLayer()
    {
        Instantiate(_levelLayer, transform.position, Quaternion.identity);
    }

    private Planet GetRandomPlanet()
    {
        int randomIndex = Random.Range(0, _planets.Length);

        return _planets[randomIndex];
    }

    private Transform GetRandomRow()
    {
        int randomIndex = Random.Range(0, _generationPoints.Length);

        return _generationPoints[randomIndex];
    }

    public void SetComplexity(float complexity)
    {
        _rotationSpeedCashed *= complexity;
    }
}
