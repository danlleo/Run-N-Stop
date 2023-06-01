using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    [SerializeField] private Transform _cubicBezierPrefab;

    private List<Transform> _bezierCurves = new List<Transform>();

    private Vector3 nextBezierCurvePosition;

    public void AddBezierCurve()
    {
        if (_bezierCurves.Count == 0)
        {
            nextBezierCurvePosition = Vector3.zero;
        }
        else
        {
            Vector3 startPoint = _bezierCurves[^1].Find("PointD").position;
            nextBezierCurvePosition = startPoint;
        }

        Quaternion targetBezierRotation = _bezierCurves.Count == 0 ? Quaternion.identity : _bezierCurves[^1].transform.rotation;

        Transform bezierCurve = Instantiate(_cubicBezierPrefab, nextBezierCurvePosition, targetBezierRotation);

        if (_bezierCurves.Count > 0 )
        {
            Transform previousBezierCurve = _bezierCurves[^1];
            Transform startPointTransform = bezierCurve.Find("PointA");

            startPointTransform.position = previousBezierCurve.Find("PointD").position;
            bezierCurve.GetComponent<BezierCurve>().SetNewPosition(previousBezierCurve.Find("PointD"));
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
