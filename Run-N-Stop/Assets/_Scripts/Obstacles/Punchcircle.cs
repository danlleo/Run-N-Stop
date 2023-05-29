using UnityEngine;

public class Punchcircle : Obstacle
{
    [SerializeField] private float _rotatingSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotatingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Follower follower))
        {
            InvokeOnPlayerHit();
        }
    }
}
