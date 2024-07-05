using UnityEngine;
using Zenject;

public abstract class Generator : MonoBehaviour
{
    [SerializeField] protected Vector2 _generationOffsetMin;
    [SerializeField] protected Vector2 _generationOffsetMax;

    [SerializeField] protected LevelLayer _levelLayer;

    [SerializeField] protected Transform[] _generationPoints;

    [SerializeField] protected Planet[] _planets;


    protected Player _player;

    [Inject]
    protected virtual void Initialize(Player player)
    {
        _player = player;
    }

    private void OnEnable()
    {
        _player.OnCollideWithLevelLayer += GenerateObstacle;
        _player.OnCollideWithLevelLayer += MakeOffsetStep;
    }

    private void OnDisable()
    {
        _player.OnCollideWithLevelLayer -= GenerateObstacle;
        _player.OnCollideWithLevelLayer -= MakeOffsetStep;
    }

    protected abstract void GenerateObstacle();

    protected virtual void MakeOffsetStep()
    {
        Vector2 randomOffset = GetRandomOffset();

        transform.position += (Vector3)randomOffset;
    }

    protected virtual Vector2 GetRandomOffset()
    {
        float randomOffsetX = Random.Range(_generationOffsetMin.x, _generationOffsetMax.x);
        float randomOffsetY = Random.Range(_generationOffsetMin.y, _generationOffsetMax.y);

        return new Vector2(randomOffsetX, randomOffsetY);
    } 
}
