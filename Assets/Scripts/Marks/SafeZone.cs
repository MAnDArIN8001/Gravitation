using UnityEngine;
using Zenject;

public class SafeZone : MonoBehaviour 
{
    [SerializeField] private float _followingSpeed;

    [SerializeField] private Vector3 _offset;
    private Vector3 _lastPlayerPosition;

    private Player _player;

    [Inject]
    private void Initialize(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        if (_player.transform.position == _lastPlayerPosition)
        {
            return;
        }

        Vector3 direction = (_player.transform.position - transform.position) + _offset;
        direction.x = 0;

        transform.Translate(direction * _followingSpeed * Time.fixedDeltaTime); 
    }
}
