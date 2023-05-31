using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public enum PlayerState
    {
        Idle,
        Running,
    }

    [HideInInspector]
    public PlayerState State;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        State = PlayerState.Idle;
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
        SceneLoadManager.Instance.ReloadCurrentScene();
    }
}
