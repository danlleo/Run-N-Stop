using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    private const float GIZMOS_STEP = 0.05f;

    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _pointC;
    [SerializeField] private Transform _pointD;

    private Vector3 LinearBezier(Vector3 a, Vector3 b, float t) => (1 - t) * a + t * b;

    private Vector3 QuadraticBezier(Vector3 a, Vector3 b, Vector3 c, float t) => (1 - t) * LinearBezier(a, b, t) + t * LinearBezier(b, c, t);

    public Vector3 CubicBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t) => (1 - t) * QuadraticBezier(a, b, c, t) + t * QuadraticBezier(b, c, d, t);

    private void OnDrawGizmos()
    {
        Vector3 prevPoint = _pointA.position;

        Gizmos.color = Color.yellow;

        Gizmos.DrawSphere(_pointA.position, 0.2f);
        Gizmos.DrawSphere(_pointD.position, 0.2f);

        Gizmos.color = Color.green;

        for (float t = GIZMOS_STEP; t <= 1f; t += GIZMOS_STEP)
        {
            Vector3 point = CubicBezier(_pointA.position, _pointB.position, _pointC.position, _pointD.position, t);
            Gizmos.DrawLine(prevPoint, point);
            prevPoint = point;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_pointA.position, _pointB.position);
        Gizmos.DrawLine(_pointC.position, _pointD.position);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_pointB.position, 0.2f);
        Gizmos.DrawSphere(_pointC.position, 0.2f);
    }

    public void SetNewPosition(Transform pointD) => _pointA = pointD;
}