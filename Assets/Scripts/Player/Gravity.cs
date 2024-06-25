using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour
{
    private float attractionForce = 10f; // Сила притяжения
    
    private HashSet<Transform> gravityObjects;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravityObjects = new();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Gravity))
        {   
            gravityObjects.Add(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Gravity))
        {
            gravityObjects.Remove(other.transform);
        }
    }
    
    private void FixedUpdate()
    {
        foreach (var gravityObject in gravityObjects)
        {
            var delta = transform.position - gravityObject.transform.position;
            Vector3 directionToCenter = -delta.normalized;
            rigidbody2D.AddForce(directionToCenter * attractionForce);
        }
    }


}