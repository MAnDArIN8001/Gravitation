using System;
using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    private Observable<int> _score = new();

    private Player _player;

    public event Action<int> OnScoreChanged 
    {
        add => _score.OnValueChanged += value;
        remove => _score.OnValueChanged -= value;
    }

    [Inject]
    private void Initialize(Player player)
    {
        _player = player;
    }

    private void OnEnable()
    {
        _player.OnCollideWithGroundablePlanet += HandleCollisionWithGroundablePlanet;
        _player.OnKill += SaveScoreResult;
    }

    private void HandleCollisionWithGroundablePlanet(Planet _)
    {
        _score.Value += 1;
    }

    private void OnDisable()
    {
        _player.OnCollideWithGroundablePlanet -= HandleCollisionWithGroundablePlanet;
        _player.OnKill -= SaveScoreResult;
    }


    private void SaveScoreResult()
    {
        PlayerPrefs.SetInt(ProjectConsts.LevelScorePrefsName, _score.Value);
    }
}
