using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    [SerializeField] private float _nextBezierCurveOffset = 10f;

    [SerializeField] private Transform _cubicBezierPrefab;

    private List<Transform> _bezierCurves;

    private Vector3 nextBezierCurvePosition;

    private void Awake()
    {
        _bezierCurves = new List<Transform>();
    }

    public void AddBezierCurve()
    {
        if (_bezierCurves.Count == 0)
        {
            nextBezierCurvePosition = Vector3.zero;
        }
        else
        {
            Vector3 startPoint = _bezierCurves[^1].Find("Offset").Find("PointD").position;
            nextBezierCurvePosition = startPoint + (Vector3.right * _nextBezierCurveOffset);
        }

        Transform bezierCurve = Instantiate(_cubicBezierPrefab, nextBezierCurvePosition, Quaternion.identity);

        if (_bezierCurves.Count > 0 )
        {
            Transform previousBezierCurve = _bezierCurves[^1];
            Transform startPointTransform = bezierCurve.Find("Offset").Find("PointA");

            startPointTransform.position = previousBezierCurve.Find("Offset").Find("PointD").position;
            bezierCurve.GetComponent<BezierCurve>().SetNewPosition(previousBezierCurve.Find("Offset").Find("PointD"));
        }

        _bezierCurves.Add(bezierCurve);
    }

    public void RemoveBezierCurve()
    {
        if (_bezierCurves.Count <= 0)
        {
            print("List of bezier curves is already empty!");
            return;
        }

        Transform bezierCurve = _bezierCurves[^1];

        _bezierCurves.Remove(bezierCurve);
        DestroyImmediate(bezierCurve.gameObject);
    }
}
