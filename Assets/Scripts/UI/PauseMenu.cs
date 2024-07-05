using UnityEngine;
using Zenject;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuView;

    private ScenManager _sceneManager;

    [Inject]
    private void Initialize(ScenManager scenManager)
    {
        _sceneManager = scenManager;
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
        _menuView.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        _menuView.SetActive(true);
    }
}
