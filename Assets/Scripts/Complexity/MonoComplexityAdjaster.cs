using Interfaces;
using UnityEngine;

public abstract class MonoComplexityAdjuster: MonoBehaviour, IComplexityAdjuster
{
    public abstract void SetComplexity(float complexity);
}
