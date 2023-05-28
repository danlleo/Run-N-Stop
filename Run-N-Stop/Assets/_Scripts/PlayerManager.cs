using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += Obstacle_OnPlayerHit;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerHit -= Obstacle_OnPlayerHit;
    }

    private void Obstacle_OnPlayerHit(object sender, EventArgs e)
    {
        print("Farted");
    }
}
