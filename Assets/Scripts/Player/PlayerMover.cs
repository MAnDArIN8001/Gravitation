using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public event Action OnJumped;

    [SerializeField] private bool _isOnPlanet = false;

    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private Player _player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.OnCollideWithGroundablePlanet += HandleCollisionWithGroundablePlanet;
    }

    private void OnDisable()
    {
        _player.OnCollideWithGroundablePlanet -= HandleCollisionWithGroundablePlanet;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && _isOnPlanet)
        {
            transform.SetParent(null);
            OnJumped?.Invoke();
            
            Jump();

            _isOnPlanet = false;
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = transform.up * _jumpForce;
    }

    private void HandleCollisionWithGroundablePlanet()
    {
        _isOnPlanet = true;
    }
}
