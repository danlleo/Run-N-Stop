using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

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
        FinishGround.OnPlayerFinish += FinishGround_OnPlayerFinish;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerHit -= Obstacle_OnPlayerHit;
        FinishGround.OnPlayerFinish -= FinishGround_OnPlayerFinish;
    }

    private void FinishGround_OnPlayerFinish(object sender, EventArgs e)
    {
        SceneLoadManager.Instance.ReloadCurrentScene();
    }

    private void Obstacle_OnPlayerHit(object sender, EventArgs e)
    {
        SceneLoadManager.Instance.ReloadCurrentScene();
    }
}
