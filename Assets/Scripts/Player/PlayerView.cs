using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private GameObject _jumpEffect;

    private Player _player;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _player.OnDied += HandleDeath;
        _playerMover.OnJumped += HandleJump;
    }

    private void OnDisable()
    {
        _player.OnDied -= HandleDeath;
        _playerMover.OnJumped += HandleJump;
    }

    private void HandleDeath()
    {
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
    }

    private void HandleJump()
    {
        Quaternion effectRotation = transform.rotation;
        effectRotation.z += 180;

        Instantiate(_jumpEffect, transform.position, effectRotation);
    }
}
