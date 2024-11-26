using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    public void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            music.Pause();
        }
        else
        {
            music.UnPause();
        }
    }
}
