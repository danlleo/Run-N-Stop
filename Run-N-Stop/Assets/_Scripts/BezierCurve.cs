using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    private const float GizmosStep = 0.05f;

    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _pointC;
    [SerializeField] private Transform _pointD;

    private float _t;

    private void Update()
    {
        _t = (_t % 1) + Time.deltaTime;

        transform.position = CubicBezier(_pointA.position, _pointB.position, _pointC.position, _pointD.position, _t);
    }

    private Vector3 LinearBezier(Vector3 a, Vector3 b, float t) => (1 - t) * a + t * b;

    private Vector3 QuadraticBezier(Vector3 a, Vector3 b, Vector3 c, float t) => (1 - t) * LinearBezier(a, b, t) + t * LinearBezier(b, c, t);

    private Vector3 CubicBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t) => (1 - t) * QuadraticBezier(a, b, c, t) + t * QuadraticBezier(b, c, d, t);

    private void OnDrawGizmos()
    {
        Vector3 prevPoint = _pointA.position;

        for (float t = GizmosStep; t <= 1f; t += GizmosStep)
        {
            Vector3 point = CubicBezier(_pointA.position, _pointB.position, _pointC.position, _pointD.position, t);
            Gizmos.DrawLine(prevPoint, point);
            prevPoint = point;
        }
    }
}
