using System;
using UnityEngine;

public class FinishGround : MonoBehaviour
{
    public static event EventHandler OnPlayerFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Follower follower))
        {
            OnPlayerFinish?.Invoke(this, EventArgs.Empty);
        }
    }
}
