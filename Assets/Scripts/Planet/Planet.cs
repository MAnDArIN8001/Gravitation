using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float _attractionForce;
    [SerializeField] private float _rotationSpeed;

    [SerializeField, Range(-1, 1)] private int _rotationDirection;

    [SerializeField] private PlanetTypes _planetType;

    public float AttractionForce => _attractionForce;
    public float RotationSpeed
    {
        get => _rotationSpeed;
        set => _rotationSpeed = value;
    } 

    public PlanetTypes PlanetType => _planetType;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotationDirection * _rotationSpeed);
    }
}
