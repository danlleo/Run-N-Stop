using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static event EventHandler OnPlayerHit;

    protected void InvokeOnPlayerHit(GameObject obstacle)
    {
        OnPlayerHit?.Invoke(this, EventArgs.Empty);
        Destroy(obstacle);
    }
}
