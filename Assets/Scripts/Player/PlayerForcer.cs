using UnityEngine;
using Zenject;

public class PlayerForcer : MonoBehaviour
{
    private bool _isSliding = false;

    [SerializeField] private float _maxForce;
    [SerializeField] private float _minForce;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _force;

    private Vector2 _startSlidingPoint;
    private Vector2 _lastMousePosition;

    private Player _player;

    [Inject]
    private void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            _isSliding = true;
            _startSlidingPoint = Input.mousePosition;
        }

        if (_isSliding)
        {
            _force += (_lastMousePosition.y - Input.mousePosition.y) * _sensitivity;

            if (_force < _minForce)
            {
                _force = _minForce;
            }
            else if (_force > _maxForce)
            {
                _force = _maxForce;
            }

            _lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 direction = _startSlidingPoint - (Vector2)Input.mousePosition;

            _isSliding = false;

            ThrowPlayer(direction.normalized);
        }

        _lastMousePosition = Input.mousePosition;
    }

    private void ThrowPlayer(Vector2 direction)
    {
        _player.Rigidbody.AddForce(direction * _force);
    }
}
