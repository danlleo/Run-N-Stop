using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private List<Transform> _curves;

    private Vector3 _startPosition;
    private BezierCurve _bezierCurve;

    private Vector3 a;
    private Vector3 b;
    private Vector3 c;
    private Vector3 d;

    private float _t;

    private void Start()
    {
        _startPosition = _curves[0].Find("Offset").Find("PointA").position;
        transform.position = _startPosition;
        _bezierCurve = _curves[0].GetComponent<BezierCurve>();
        a = _curves[0].Find("Offset").Find("PointA").position;
        b = _curves[0].Find("Offset").Find("PointB").position;
        c = _curves[0].Find("Offset").Find("PointC").position;
        d = _curves[0].Find("Offset").Find("PointD").position;
    }

    private void Update()
    {
        _t = (_t % 1) + Time.deltaTime;

        transform.position = _bezierCurve.CubicBezier(a, b, c, d, _t);
    }
}
