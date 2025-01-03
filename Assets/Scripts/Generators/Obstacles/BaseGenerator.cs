using Interfaces;
using UnityEngine;

public class BaseGenerator : Generator, IComplexityAdjuster 
{
    [SerializeField] private int _startPlanetsCount;
    [SerializeField] private float _rotationSpeed = 0;
    [SerializeField] private Sprite[] _planetSprites;
    [SerializeField] private Planet _planetPrefab;
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
        var sprite = GetRandomPlanetSprite();
        var row = GetRandomRow();
        
        var planetGameObject = Instantiate(_planetPrefab, row.position, Quaternion.identity);

        planetGameObject.SetSprite(sprite);
        planetGameObject.RotationSpeed = _rotationSpeedCashed;
        
        GenerateLevelLayer();
    }

    private void GenerateLevelLayer()
    {
        Instantiate(_levelLayer, transform.position, Quaternion.identity);
    }

    private Sprite GetRandomPlanetSprite()
    {
        int randomIndex = Random.Range(0, _planetSprites.Length);

        return _planetSprites[randomIndex];
    }

    private Transform GetRandomRow()
    {
        int randomIndex = Random.Range(0, _generationPoints.Length);

        return _generationPoints[randomIndex];
    }

    public void SetComplexity(float complexity)
    {
        _rotationSpeedCashed *= complexity + 0.01f;
    }
}
