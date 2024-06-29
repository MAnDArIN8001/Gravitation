using UnityEngine;
using Zenject;

public abstract class Generator : MonoBehaviour
{
    [SerializeField] protected Vector2 _generationOffsetMin;
    [SerializeField] protected Vector2 _generationOffsetMax;

    [SerializeField] protected Transform[] _generationPoints;

    [SerializeField] protected Planet[] _planets;

    protected PlayerMover _playerMover;

    [Inject]
    protected virtual void Initialize(PlayerMover playerMover)
    {
        _playerMover = playerMover;
    }

    private void OnEnable()
    {
        _playerMover.OnJumped += GenerateObstacle;
        _playerMover.OnJumped += MakeOffsetStep;
    }

    private void OnDisable()
    {
        _playerMover.OnJumped -= GenerateObstacle;
        _playerMover.OnJumped -= MakeOffsetStep;
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
