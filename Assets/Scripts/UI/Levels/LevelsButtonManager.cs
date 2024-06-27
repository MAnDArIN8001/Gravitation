using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class LevelsButtonManager : MonoBehaviour
{
    [SerializeField] private LevelsButton _childPrefab;
    [Inject] private ScenManager _scenManager;
    public void OnButtonPressHandler(int LevelId)
    {
        PlayerPrefs.SetInt(PlayerPrefsConst.LevelID, LevelId);
        _scenManager.LoadSceneAsync(ProjectConsts.GameScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        // Создание дочерних объектов
        int numberOfChildren = 5;
        for (int i = 0; i < numberOfChildren; i++)
        {
            // Создание нового дочернего объекта
            var child = Instantiate(_childPrefab);

            // Назначение родительского объекта (текущий объект)
            child.transform.parent = this.transform;

            // Позиционирование дочернего объекта
            child.transform.localPosition = new Vector3(i * 2.0f, 0, 0); // Смещение по X для наглядности
        }
    }


}
