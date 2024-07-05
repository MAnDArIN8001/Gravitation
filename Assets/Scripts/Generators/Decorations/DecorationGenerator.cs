using UnityEngine;

public abstract class DecorationGenerator : MonoBehaviour
{
    [SerializeField] protected GameObject[] _decorations;

    [SerializeField] protected Transform _leftBorderPoint;
    [SerializeField] protected Transform _rightRandomPoint;

    protected abstract void GenerateDecoration();
}
