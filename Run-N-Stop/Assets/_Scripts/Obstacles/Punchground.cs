using UnityEngine;

public class Punchground : Obstacle
{
    private float _t;

    private bool _isIncreasing;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = transform.position + Vector3.up * 2.5f;
    }

    private void Update()
    {
        if (_t >= 1f)
            _isIncreasing = false;
        else if (_t <= 0f)
            _isIncreasing = true;

        _t = _isIncreasing ? _t + Time.deltaTime : _t - Time.deltaTime;
        _t = Mathf.Clamp01(_t);

        transform.position = Vector3.Lerp(_startPosition, _endPosition, InterpolateUtils.EaseExponential(_t));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Follower follower))
        {
            InvokeOnPlayerHit();
        }
    }
}
