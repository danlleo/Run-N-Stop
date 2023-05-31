using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public static PlayerAnimationController Instance { get; private set; }

    private Animator _animator;

    private static readonly int IsRunningParam = Animator.StringToHash("IsRunning");
    private static readonly int PlayerVictoryTrigger = Animator.StringToHash("OnPlayerFinish");
    private static readonly int PlayerObstacleHitTrigger = Animator.StringToHash("OnPlayerHit");

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsRunningParam, PlayerManager.PlayerState.Running == PlayerManager.Instance.State);
    }

    public void TriggerPlayerVictory()
    {
        _animator.SetTrigger(PlayerVictoryTrigger);
    }

    public void TriggerPlayerObstacleHit()
    {
        _animator.SetTrigger(PlayerObstacleHitTrigger);
    }
}
