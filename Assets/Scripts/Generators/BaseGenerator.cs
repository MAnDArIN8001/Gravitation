using UnityEngine;

public class BaseGenerator : Generator
{
    protected override void GenerateObstacle()
    {
        Planet planet = GetRandomPlanet();
        Transform row = GetRandomRow();
        
        Instantiate(planet.gameObject, row.position, Quaternion.identity);
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
