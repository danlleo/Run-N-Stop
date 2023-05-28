using UnityEngine;

public class Punchcube : Obstacle
{
    private float _t;

    private bool _isIncreasing;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Start()
    {
        _startPosition = transform.position - Vector3.forward * 2.5f;
        _endPosition = transform.position + Vector3.forward * 2.5f;
    }

    private void Update()
    {
        print(_startPosition);
        print(_endPosition);

        if (_t >= 1f)
            _isIncreasing = false;
        else if (_t <= 0f)
            _isIncreasing = true;

        _t = _isIncreasing ? _t + Time.deltaTime : _t - Time.deltaTime;
        _t = Mathf.Clamp01(_t);

        transform.position = Vector3.Lerp(_startPosition, _endPosition, EaseIn(_t));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Follower follower))
        {
            InvokeOnPlayerHit();
        }
    }

    private float EaseIn(float t)
    {
        return t * t;
    }
}
