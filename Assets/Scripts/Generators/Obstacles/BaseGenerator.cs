using UnityEngine;

public class BaseGenerator : Generator
{
    [SerializeField] private int _startPlanetsCount;

    private void Awake()
    {
        for (int i = 0; i < _startPlanetsCount; i++)
        {
            GenerateObstacle();
            MakeOffsetStep();
        }
    }
    protected override void GenerateObstacle()
    {
        Planet planet = GetRandomPlanet();
        Transform row = GetRandomRow();
        
        Instantiate(planet.gameObject, row.position, Quaternion.identity);

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
