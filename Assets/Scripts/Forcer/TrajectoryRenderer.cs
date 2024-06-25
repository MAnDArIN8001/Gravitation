using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] private int _pointsCount;

    [SerializeField] private float _maxTrajectoryLength;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 force)
    {
        Vector3[] points = new Vector3[_pointsCount];

        _lineRenderer.positionCount = _pointsCount;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + force * _maxTrajectoryLength * time;
        }

        _lineRenderer.SetPositions(points);
    }
}
