using UnityEngine;
using TMPro;
using Zenject;

public class ScoreVIew : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private ScoreManager _scoreManager;

    [Inject] 
    private void Initialize(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    private void OnEnable()
    {
        _scoreManager.OnScoreChanged += HandleScoreChangings;
    }

    private void OnDisable()
    {
        _scoreManager.OnScoreChanged -= HandleScoreChangings;
    }

    private void HandleScoreChangings(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }
}
