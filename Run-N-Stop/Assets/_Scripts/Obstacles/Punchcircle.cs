using UnityEngine;

public class Punchcircle : Obstacle
{
    [SerializeField] private float _rotatingSpeed;

    private void Update()
    {
        transform.Rotate(_rotatingSpeed * Time.deltaTime * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Follower follower))
        {
            InvokeOnPlayerHit(transform.root.gameObject);
        }
    }
}
