using System.Collections;
using Interfaces;
using UnityEngine;
using Zenject;


public class ComplexityManager
{
    private IComplexityAdjuster[] _complexityAdjusters;
    private float _complexity = 1f;
    private MonoBehaviour _context;
    
    [Inject]
    private void Inject(IComplexityAdjuster[] complexityAdjusters, MonoBehaviour context)
    {
        _complexityAdjusters = complexityAdjusters;
        _context = context;
        Debug.Log(_complexityAdjusters.Length);
        _context.StartCoroutine(ComplexityCounter());
    }

    IEnumerator ComplexityCounter()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(1f);
            _complexity *= 1.001f;
            foreach (var complexityAdjuster in _complexityAdjusters)
            {
                complexityAdjuster.SetComplexity(_complexity);
            }
        }
    }
}
