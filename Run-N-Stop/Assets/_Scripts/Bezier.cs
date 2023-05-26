using UnityEngine;

public class Bezier : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _pointC;
    [SerializeField] private Transform _pointD;

    private float _t;

    private void Update()
    {
        _t = (_t % 1) + Time.deltaTime;

        transform.position = CubicBezier(QuadraticBezier(_pointA.position, _pointB.position, _pointC.position, _t), QuadraticBezier(_pointB.position, _pointC.position, _pointD.position, _t), _t);
    }

    private Vector3 LinearBezier(Vector3 pointA, Vector3 pointB, float t)
    {
        return Vector3.Lerp(pointA, pointB, t);
    }

    private Vector3 QuadraticBezier(Vector3 pointA, Vector3 pointB, Vector3 pointC, float t)
    {
        return (1 - t) * ((1 - t) * pointA + t * pointB) + t * ((1 - t) * pointB + t * pointC);
    }

    private Vector3 CubicBezier(Vector3 pointA, Vector3 pointB, float t)
    {
        return (1 - t) * pointA + t * t * pointB;
    }
}
