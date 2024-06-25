using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour
{
    [SerializeField] private float _attractionForce = 10f; // Сила притяжения
    [SerializeField] private float _rotationSpeed = 1f;
    
    private HashSet<Transform> _gravityObjects;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gravityObjects = new();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Gravity))
        {
            _gravityObjects.Add(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Gravity))
        {
            _gravityObjects.Remove(other.transform);
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

            Vector3 directionToCenter = -delta.normalized;
            _rigidbody2D.AddForce(directionToCenter * _attractionForce);
        }

        float angle = Mathf.Atan2(min.y, min.x) * Mathf.Rad2Deg - 90f;
        
        var targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}