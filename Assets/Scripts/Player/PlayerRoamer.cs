using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRoamer : MonoBehaviour
{
    [SerializeField] private float _maxForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetRandomVelocity();
    }

    private void OnMouseDown()
    {
        SetRandomVelocity();
    }

    private void SetRandomVelocity()
    {
        float randomForce = Random.Range(0.0f, _maxForce);

        Vector2 randomDirection = GetRandomDirection();

        _rigidbody.velocity = randomDirection * randomForce;
    }

    private Vector2 GetRandomDirection() => new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
}
