using System;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    private Player _player;

    private ScenManager _scenManager;

    private LevelData _levelData;

    private LevelLoader _levelLoader;
    private GameObject level;

    private void Awake()
    {
        var levelId = PlayerPrefs.GetInt(PlayerPrefsConst.LevelID);
        level = LevelLoader.Create($"Levels/{levelId}").gameObject;
    }

    [Inject]
    private void Initialize(Player player, ScenManager scenManager, LevelData levelData)
    {
        _player = player;
        _scenManager = scenManager;
        _levelData = levelData;
    }

    private void OnEnable()
    {
        _player.OnCollideWithTargetPlanet += HandleCollisionWithTargetPlanet;
        _player.OnCollideWithWrongPlanet += HandleCollisionWithWrongPlanet;
    }

    private void OnDisable()
    {
        _player.OnCollideWithTargetPlanet -= HandleCollisionWithTargetPlanet;
        _player.OnCollideWithWrongPlanet -= HandleCollisionWithWrongPlanet;
    }

    private void OnDestroy()
    {
        Destroy(level);
    }

    private void HandleCollisionWithWrongPlanet()
    {
        _scenManager.LoadSceneAsync(ProjectConsts.MenuLvlId);

        _levelData.LevelResult = LevelResult.Loose;
    }

    private void HandleCollisionWithTargetPlanet()
    {
        _scenManager.LoadSceneAsync(ProjectConsts.MenuLvlId);

        _levelData.LevelResult = LevelResult.Win;
    }
}
