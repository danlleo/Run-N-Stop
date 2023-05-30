using UnityEngine;

public class Punchbag : MonoBehaviour
{
    [SerializeField, Range(0f, 180f)] private float _targetAngle;

    private float _t;

    private bool _isIncreasing;

    private void Update()
    {
        if (_t >= 1f)
            _isIncreasing = false;
        else if (_t <= 0f)
            _isIncreasing = true;

        _t = _isIncreasing ? _t + Time.deltaTime : _t - Time.deltaTime;
        _t = Mathf.Clamp01(_t);

        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0f, 0f, _targetAngle), Quaternion.Euler(0f, 0f, -_targetAngle), InterpolateUtils.EaseInOut(_t));
    }
}
