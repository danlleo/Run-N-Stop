using UnityEngine;

public class Bezier : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _pointC;

    private float _t;

    private void Update()
    {
        _t = (_t % 1) + Time.deltaTime;

        transform.position = QuadraticBezier(_pointA.position, _pointB.position, _pointC.position, _t);
    }

    private Vector3 LinearBezier(Vector3 pointA, Vector3 pointB, float t)
    {
        return Vector3.Lerp(pointA, pointB, t);
    }

    private Vector3 QuadraticBezier(Vector3 pointA, Vector3 pointB, Vector3 pointC, float t)
    {
        return (1 - t) * ((1 - t) * pointA + (t) * pointB) + t * ((1 - t) * pointB + t * pointC);
    }
}
