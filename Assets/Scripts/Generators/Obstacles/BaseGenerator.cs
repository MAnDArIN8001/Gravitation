using UnityEngine;

public class BaseGenerator : Generator
{
    [SerializeField] private int _startPlanetsCount;
    [SerializeField] private float _rotationSpeed = 0;
    [SerializeField] private float _rotationSpeedDelta = 0;

    private float _rotationSpeedCashed = 0;
    private float _rotationSpeedDeltaCashed = 0;
    private void Awake()
    {

        _rotationSpeedCashed = _rotationSpeed;
        _rotationSpeedDeltaCashed = _rotationSpeedDelta;
        
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
        _rotationSpeedCashed *= _rotationSpeedDeltaCashed;
        planetGameObject.RotationSpeed += _rotationSpeedCashed;

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
}
