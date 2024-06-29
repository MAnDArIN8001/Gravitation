using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffect;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.OnDied += HandleCollisionWithPlanet;
        _player.OnCollideWithPlanet += HandleCollisionWithPlanet;

    }

    private void OnDisable()
    {
        _player.OnCollideWithPlanet -= HandleCollisionWithPlanet;
        _player.OnDied -= HandleCollisionWithPlanet;
    }

    private void HandleCollisionWithPlanet()
    {
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
    }
}
