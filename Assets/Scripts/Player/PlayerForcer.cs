using System;
using UnityEngine;
using Zenject;

public class PlayerForcer : MonoBehaviour
{
    public event Action OnForced;

    private bool _isSliding = false;

    [SerializeField] private float _maxForce;
    [SerializeField] private float _minForce;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _force;

    private Vector2 _startSlidingPoint;
    private Vector2 _lastMousePosition;

    private TrajectoryRenderer _trajectroyRenderer;

    private Player _player;

    private InputManager _inputManager;

    [Inject]
    private void Initialize(Player player, InputManager inputManager)
    {
        _player = player;
        _inputManager = inputManager;

        _inputManager.ClickEvent += ClickEventHandler;
        _inputManager.ClickEndEvent += ClickEndEventHandler;
    }

    private void Awake()
    {
        _trajectroyRenderer = GetComponent<TrajectoryRenderer>();
    }



    private void ClickEventHandler(Vector3 obj)
    {
        _isSliding = true;
        _startSlidingPoint = obj;
        //Update
    }

    private void ClickEndEventHandler(Vector3 obj)
    {
        //Update
        if (!_isSliding)
        {
            return;
        }

        Vector2 direction = _startSlidingPoint - (Vector2)Input.mousePosition;

        _isSliding = false;
        _inputManager.ClickEvent -= ClickEventHandler;
        _inputManager.ClickEndEvent -= ClickEndEventHandler;
        
        ThrowPlayer(direction.normalized);
        Destroy(gameObject);
    }

    private void Update()
    {
        //ClickEventHandler
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

            Vector3 currentDirection = (Vector3)_startSlidingPoint - Input.mousePosition;

            _trajectroyRenderer.ShowTrajectory(transform.position, currentDirection.normalized * (_force / _maxForce));
        }

        //ClickEndEventHandler
        _lastMousePosition = Input.mousePosition;
    }

    private void ThrowPlayer(Vector2 direction)
    {
        _player.Rigidbody.AddForce(direction * _force);

        OnForced?.Invoke();
    }
    
}
