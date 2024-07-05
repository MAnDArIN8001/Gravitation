using UnityEngine;
using TMPro;

public class GameMenuScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scorText;

    private void Start()
    {
        int scoreValue = PlayerPrefs.GetInt(ProjectConsts.LevelScorePrefsName);

        _scorText.text = $"Score is: {scoreValue}";
    }
}
