using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private ParticleSystem _jumpEffect;

    private Player _player;
    private PlayerMover _playerMover;
    private ParticleSystem _destroyEffect;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _player.OnKill += HandleDeath;
        _playerMover.OnJumped += HandleJump;
    }

    private void OnDisable()
    {
        _player.OnKill -= HandleDeath;
        _playerMover.OnJumped += HandleJump;
        Destroy(_destroyEffect);
    }

    private void HandleDeath()
    {
       _destroyEffect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
       _player.WaitEndKillEffect(_destroyEffect);
       _player.OnEndKillEffect += PlayerOnOnEndKillEffect;
       void PlayerOnOnEndKillEffect()
       {
           OnDisable();
       }
    }

    private void HandleJump()
    {
        Quaternion effectRotation = transform.rotation;
        effectRotation.z += 180;

        Instantiate(_jumpEffect, transform.position, effectRotation);
    }

    private void OnDestroy()
    {
        Destroy(_destroyEffect);
    }
}
