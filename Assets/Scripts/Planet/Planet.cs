using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Planet : Entity
{
    public float AttractionForce => _attractionForce;
    public float RotationSpeed
    {
        get => _rotationSpeed;
        set => _rotationSpeed = value;
    }
    
    [SerializeField] private float _attractionForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField, Range(-1, 1)] private int _rotationDirection;
    [SerializeField] private PlanetTypes _planetType;
    
    [Space]
    [SerializeField]
    [CanBeNull]
    private ParticleSystem _destroyEffect;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _circle;
     
    private void Start()
    {
        if (_destroyEffect != null) _destroyEffect.gameObject.SetActive(false);
    }


    public override void Kill()
    {
        base.Kill();
        
        _spriteRenderer.enabled = false;
        _circle.enabled = false;
        
        _destroyEffect.gameObject.SetActive(true);
        _destroyEffect.Play();
        
        WaitEndKillEffect(_destroyEffect);
        OnEndKillEffect += OnEndKillEffectHandler;

        void OnEndKillEffectHandler()
        {
            OnEndKillEffect -= OnEndKillEffectHandler;
            Debug.Log("Destroy Planet");
            Destroy(this);// вроде удаляет в конце текущего кадра
            Destroy(_destroyEffect);
        }
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
    
    public PlanetTypes PlanetType => _planetType;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotationDirection * _rotationSpeed);
    }
    

}
