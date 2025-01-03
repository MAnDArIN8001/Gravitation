using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Entity
{
    public event Action<Planet> OnCollideWithGroundablePlanet;
    public event Action OnCollideWithLevelLayer;

    [SerializeField] private float _minVelocityMagnitude;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Planet>(out var planet))
        {
            switch (planet.PlanetType)
            {
                case PlanetTypes.Ungroundable:
                    Kill();
                    break;

                case PlanetTypes.Groundable:
                    OnCollideWithGroundablePlanet?.Invoke(planet);
                    transform.SetParent(planet.transform);
                    break;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LevelLayer>(out var layer))
        {
            OnCollideWithLevelLayer?.Invoke();
        }
    }

    
    public override void Kill()
    {
        _spriteRenderer.enabled = false;
        base.Kill();
   }


}
