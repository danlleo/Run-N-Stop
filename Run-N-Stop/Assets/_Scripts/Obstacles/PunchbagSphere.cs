using UnityEngine;

public class PunchbagSphere : Obstacle
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Follower follower))
        {
            InvokeOnPlayerHit(transform.root.gameObject);
        }
    }
}
