using System;
using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour, IKillable
{  
    public event Action OnKill;
    public event Action OnEndKillEffect; 
    
    protected void InvokeOnEndKillEffect()
    {
        OnEndKillEffect?.Invoke();   
    }
    public virtual void Kill()
    {
        OnKill?.Invoke();
    }
    public void WaitEndKillEffect(ParticleSystem killEffect) =>
        StartCoroutine(WaitEndEffect(killEffect, InvokeOnEndKillEffect));
    
    protected IEnumerator WaitEndEffect(ParticleSystem effect, Action action)
    {
        Debug.Log("Start Effect");
        while (effect.isPlaying)
        {
            yield return null; // Ждать до следующего кадра
        }
        
        action?.Invoke();
        Debug.Log("End Effect");
    }
}
