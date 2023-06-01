using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private List<Transform> _curves;

    [SerializeField] private float _moveDuration;

    private Vector3 _startPosition;
    private BezierCurve _bezierCurve;

    private Vector3 _a;
    private Vector3 _b;
    private Vector3 _c;
    private Vector3 _d;

    private int _curveIndex;

    private float _t;
    private float _elapsedTime;

    private void Start()
    {
        _bezierCurve = _curves[0].GetComponent<BezierCurve>();
        _startPosition = _curves[0].Find("PointA").position;
        transform.position = _startPosition;
        ResetPosition();
    }

    private void Update()
    {
        if (GameManager.Instance.State != GameManager.GameState.Playing)
            return;

        if (!Input.GetMouseButton(0))
        {
            PlayerManager.Instance.State = PlayerManager.PlayerState.Idle;
            return;
        }

        PlayerManager.Instance.State = PlayerManager.PlayerState.Running;

        _elapsedTime += Time.deltaTime;
        _t = Mathf.Clamp01(_elapsedTime / _moveDuration);

        if (_t >= 1f)
            MoveToNewCurve();

        Vector3 direction = _bezierCurve.CubicBezier(_a, _b, _c, _d, _t);
        Quaternion targetRotation = Quaternion.LookRotation(direction - transform.position);

        transform.SetPositionAndRotation(direction, targetRotation);
    }

    private void MoveToNewCurve()
    {
        _curveIndex++;

        if (_curveIndex < _curves.Count) 
        {
            _a = _curves[_curveIndex - 1].Find("PointD").Find("PointA").position;
            _b = _curves[_curveIndex].Find("PointB").position;
            _c = _curves[_curveIndex].Find("PointC").position;
            _d = _curves[_curveIndex].Find("PointD").position;
        }

        _elapsedTime = 0;
    }

    private void ResetPosition()
    {
        _a = _curves[0].Find("PointA").position;
        _b = _curves[0].Find("PointB").position;
        _c = _curves[0].Find("PointC").position;
        _d = _curves[0].Find("PointD").position;
    }
}
