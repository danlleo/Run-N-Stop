using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static event EventHandler OnPlayerHit;

    public void InvokeOnPlayerHit()
    {
        OnPlayerHit?.Invoke(this, EventArgs.Empty);
    }
}
