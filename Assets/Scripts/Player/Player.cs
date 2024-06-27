using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public event Action OnDied;
    public event Action OnCollideWithTargetPlanet;

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
            if (planet.PlanetType == PlanetTypes.Wrong)
            {
                OnDied?.Invoke();
            } 
            else if (planet.PlanetType == PlanetTypes.Target)
            {
                OnCollideWithTargetPlanet?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (collision.TryGetComponent<SafeZone>(out var safeZone))
        {
            OnDied?.Invoke();
        }
    }
}
