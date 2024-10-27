using System;
using UnityEngine;
using Zenject;

public class PlayerMover : MonoComplexityAdjuster
{
    public event Action OnJumped;

    [SerializeField] private bool _isOnPlanet = false;

    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private Player _player;

    private InputManager _inputManager;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }
    [Inject]
    void Inject(InputManager inputManager)
    {
        _inputManager = inputManager;
    }

    private void ClickEventHandler(Vector3 obj)
    {
        if (_isOnPlanet)
        {
            transform.SetParent(null);
            OnJumped?.Invoke();
            
            Jump();

            _isOnPlanet = false;
        }
    }

    private void OnEnable()
    {
        _player.OnCollideWithGroundablePlanet += HandleCollisionWithGroundablePlanet;
        _inputManager.ClickEvent += ClickEventHandler;
    }

    private void OnDisable()
    {
        _player.OnCollideWithGroundablePlanet -= HandleCollisionWithGroundablePlanet;
        _inputManager.ClickEvent -= ClickEventHandler;

    }

    private void Jump()
    {
        _rigidbody.velocity = transform.up * _jumpForce;
    }

    private void HandleCollisionWithGroundablePlanet()
    {
        _isOnPlanet = true;
    }

    public override void SetComplexity(float complexity)
    {
        _jumpForce += complexity * 0.1f;
    }
}
