using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    
    private HashSet<Planet> _gravityObjects;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gravityObjects = new();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Planet>(out var planet))
        {
            _gravityObjects.Add(planet);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Planet>(out var planet))
        {
            _gravityObjects.Remove(planet);
        }
    }

    private void FixedUpdate()
    {
        if(_gravityObjects.Count == 0) return;
        
        Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        foreach (var gravityObject in _gravityObjects)
        {
            var delta = transform.position - gravityObject.transform.position;

            if (delta.magnitude < min.magnitude)
            {
                min = delta;
            }

            float attracrtionForce = gravityObject.AttractionForce;
            Vector3 directionToCenter = -delta.normalized;

            _rigidbody2D.AddForce(directionToCenter * attracrtionForce);
        }

        float angle = Mathf.Atan2(min.y, min.x) * Mathf.Rad2Deg - 90f;
        
        var targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}