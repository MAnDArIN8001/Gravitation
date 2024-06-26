using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    private bool _isAnimationDone;
    private bool _isInLoading;

    public void LoadSceneAsync(int sceneIndex)
    {
        if (_isInLoading)
        {
            return;
        }

        _isInLoading = true;

        StartCoroutine(LoadingSceneAsync(sceneIndex));
    }

    private void CloseFadeAnimation()
    {
        _isAnimationDone = true;
    }

    private IEnumerator LoadingSceneAsync(int sceneIndex)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneIndex);

        while (!scene.isDone && !_isAnimationDone)
        {
            yield return null;
        }
    }
}
