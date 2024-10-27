using UnityEngine;
using Zenject;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuView;

    private ScenManager _sceneManager;
    private PlayerMover _playerMover;

    [Inject]
    private void Initialize(ScenManager scenManager, PlayerMover playerMover)
    {
        _sceneManager = scenManager;
        _playerMover = playerMover;
    }

    public void GoToMainMenu()
    {
        _sceneManager.LoadSceneAsync(ProjectConsts.MainMenuSceneId);
    }

    public void RestartLevel()
    {
        _sceneManager.LoadSceneAsync(ProjectConsts.GameplaySceneId);
    }

    public void ClosePauseMenu()
    {
        _playerMover.enabled = true;
        _menuView.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        _playerMover.enabled = false;
        _menuView.SetActive(true);
    }
}
