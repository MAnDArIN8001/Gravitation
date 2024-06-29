using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayerForcer : MonoBehaviour, ITickable
{
    private bool _isSliding = false;

    [SerializeField] private float _maxForce;
    [SerializeField] private float _minForce;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _force;
    

    private Vector2 _startSlidingPoint;
    private Vector3 _forceDirection;

    private TrajectoryRenderer _trajectroyRenderer;

    private bool _enabled = false;
    
    private Player _player;
    private TickableManager _tickableManager;

    [Inject]
    private void Initialize(Player player, TickableManager tickableManager)
    {
        _player = player;
        _tickableManager = tickableManager;
        Enable();
    }

    public void Enable()
    {
        if (!_enabled)
        {
            _tickableManager.Add(this);
            _enabled = true;
        }
    }

    public void Disable()
    {
        if (_enabled)
        {
            _tickableManager.Remove(this);
            _enabled = false;
        }
    }
    private void Awake()
    {
        _trajectroyRenderer = GetComponent<TrajectoryRenderer>();
    }

    private void ThrowPlayer(Vector2 direction)
    {
        _player.Rigidbody.AddForce(direction * _force);
    }

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            var mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);

            _isSliding = true;
        }

        if (_isSliding)
        {
            var playerPosition = _player.transform.position;
            var mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
            _forceDirection = -(playerPosition - mousePosition).normalized;
            
            _force = (playerPosition - mousePosition).magnitude * _sensitivity;
            
            if (_force < _minForce)
            {
                _force =  _minForce;
            }
            else if (_force > _maxForce)
            {
                _force = _maxForce;
            }
            _trajectroyRenderer.ShowTrajectory(playerPosition, _forceDirection * (_force/_maxForce));
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isSliding = false;
            
            _trajectroyRenderer.HideTrajectory();
            
            ThrowPlayer(_forceDirection);
            Disable();
        }
    }
}
