using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraContoller : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float desiredWidth = 10f; // Задайте желаемую ширину
    public float ratioThreshold = 1f; // Задайте порог по высоте
    private float _defaultSize;

    void Start()
    {
        _defaultSize = virtualCamera.m_Lens.OrthographicSize;
    }

    private void Update()
    {
        var ratio = (float)Screen.width / Screen.height;
        // Проверяем, если высота экрана больше порога
        if (ratio < ratioThreshold)
        {
            UpdateCameraSize();
        }
        else
        {
            virtualCamera.m_Lens.OrthographicSize = _defaultSize;
        }
    }

    void UpdateCameraSize()
    {
        float aspectRatio = (float)Screen.width / Screen.height ;
        float orthographicSize = desiredWidth / (2 * aspectRatio);
        virtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
