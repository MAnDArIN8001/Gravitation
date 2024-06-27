using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Zenject;

public class LevelsButtonManager : MonoBehaviour
{
    [SerializeField] private LevelsButton _childPrefab;
    [Inject] private ScenManager _scenManager;
    public void OnButtonPressHandler(int LevelId)
    {
        PlayerPrefs.SetInt(PlayerPrefsConst.LevelID, LevelId);
        _scenManager.LoadSceneAsync(ProjectConsts.GameplayScene);
    }
    // Start is called before the first frame update
    void Start()
    {

        int numberOfChildren = 5;
        
        for (int i = 0; i < numberOfChildren; i++)
        {
            var child = Instantiate(_childPrefab);
      
            child.transform.parent = this.transform;
            
            int levelId = i + 1;
            
            var action = new UnityAction(() => OnButtonPressHandler(levelId));
            child.onClick.AddListener(action);

            child.transform.localPosition = new Vector3(i * 2.0f, 0, 0); 
        }
    }


}
