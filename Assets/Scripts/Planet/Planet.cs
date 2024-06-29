using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float _attractionForce;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private PlanetTypes _planetType;

    public float AttractionForce => _attractionForce;

    public PlanetTypes PlanetType => _planetType;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotationSpeed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SafeZone>(out var safeZone))
        {
            Destroy(gameObject);
        }
    }
}
