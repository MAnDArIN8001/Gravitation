using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

public class ScenManager : MonoBehaviour
{
    private bool _isAnimationDone = false;
    private bool _isInLoading;

    [SerializeField] private string _fadeInKey;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void LoadSceneAsync(int sceneIndex)
    {
        if (_isInLoading)
        {
            return;
        }

        switch (sceneIndex)
        {
        }
        
        _isInLoading = true;
        _animator.SetTrigger(_fadeInKey);

        StartCoroutine(LoadingSceneAsync(sceneIndex));
    }

    public void LoadSceneWithAdd(int sceneIndex)
    {
        YandexGame.FullscreenShow();
        StartCoroutine(WaitEndOfAdd(sceneIndex));
    }
    
    private void CloseFadeAnimation()
    {
        _isAnimationDone = true;
    }

    private IEnumerator WaitEndOfAdd(int sceneIndex)
    {
        yield return new WaitForSeconds(YandexGame.timerShowAd);
        LoadSceneAsync(sceneIndex);
    }
    private IEnumerator LoadingSceneAsync(int sceneIndex)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneIndex);

        scene.allowSceneActivation = false;

        yield return new WaitUntil(() => _isAnimationDone);

        scene.allowSceneActivation = true;
    }
}
