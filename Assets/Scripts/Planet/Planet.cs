using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float _attractionForce;

    [SerializeField] private PlanetTypes _planetType;

    public float AttractionForce => _attractionForce;

    public PlanetTypes PlanetType => _planetType;
}
