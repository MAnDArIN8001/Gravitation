using UnityEngine;
using Zenject;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuView;

    private ScenManager _sceneManager;
    private PlayerForcer _playerForcer;

    [Inject]
    private void Initialize(ScenManager scenManager, PlayerForcer playerForcer)
    {
        _sceneManager = scenManager;
        _playerForcer = playerForcer;
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
        _playerForcer.enabled = true;
        _menuView.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        _playerForcer.enabled = false;
        _menuView.SetActive(true);
    }
}
