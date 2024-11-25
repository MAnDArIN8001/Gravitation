using System.Collections;
using Interfaces;
using UnityEngine;
using Zenject;

public class SafeZone : MonoBehaviour, IComplexityAdjuster 
{
    [SerializeField] private float _followingSpeed;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed = 0.001f;
    [SerializeField] private float _waitTime;
    
    private Vector3 _lastPlayerPosition;
    private Player _player;
    private float _waitTimeCash;
    private bool _flag;

    [Inject]
    private void Initialize(Player player)
    {
        _player = player;
        _player.OnCollideWithGroundablePlanet += PlayerOnOnCollideWithGroundablePlanet;
        _waitTimeCash = _waitTime;

    }

    private void PlayerOnOnCollideWithGroundablePlanet()
    {        
        _waitTime = _waitTimeCash;
        _flag = false;
        StartCoroutine(TimeCounter());

    }

    private void FixedUpdate()
    {
        if (_player.transform.position == _lastPlayerPosition)
        {
            return;
        }
        if(_waitTime <= 0 && _flag)
        {
            transform.Translate( _speed * Vector3.up); 
            return;
        }

        Vector3 direction = (_player.transform.position - transform.position) + _offset;
        direction.x = 0;
        direction.z = 0;
        if (direction.y >= -0.1f && direction.y <= 0.1f) _flag = true;

        transform.Translate(direction * (_followingSpeed * Time.fixedDeltaTime)); 
    }

    IEnumerator TimeCounter()
    {
        while (_waitTime > 0)
        {
            _waitTime -= 1f;
            yield return new WaitForSeconds(1f);
        }
    }

    public void SetComplexity(float complexity)
    {
        _waitTime /= complexity;
    }
}
