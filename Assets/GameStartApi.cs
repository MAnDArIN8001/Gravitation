using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class GameStartApi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        YandexGame.GameReadyAPI();   
    }
}
