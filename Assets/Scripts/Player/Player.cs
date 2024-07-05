using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public event Action OnDied;
    public event Action OnCollideWithGroundablePlanet;
    public event Action OnCollideWithLevelLayer;

    [SerializeField] private float _minVelocityMagnitude;

    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Planet>(out var planet))
        {
            if (planet.PlanetType == PlanetTypes.Ungroundable)
            {
                OnDied?.Invoke();
            } 
            else if (planet.PlanetType == PlanetTypes.Groundable)
            {
                OnCollideWithGroundablePlanet?.Invoke();

                transform.SetParent(planet.transform);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SafeZone>(out var safeZone))
        {
            OnDied?.Invoke();
        }
    }
}
