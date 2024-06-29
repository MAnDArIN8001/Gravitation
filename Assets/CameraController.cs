using System;
using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{

    private Transform _player;
    // Скорость следования камеры за игроком
    public float smoothSpeed = 0.125f;

    // Смещение камеры относительно игрока
    public Vector3 offset;
    [Inject]
    private void Inject(Player player)
    {
        _player = player.transform;
    }


    void LateUpdate()
    {
        // Целевая позиция камеры с учетом смещения
        Vector3 desiredPosition = _player.position + offset;

        // Плавное перемещение камеры к целевой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Устанавливаем новую позицию камеры
        transform.position = smoothedPosition;
    }
}