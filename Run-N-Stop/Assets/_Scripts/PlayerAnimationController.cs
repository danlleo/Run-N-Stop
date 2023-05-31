using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private static readonly int IsRunningParam = Animator.StringToHash("isRunning");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsRunningParam, PlayerManager.PlayerState.Running == PlayerManager.Instance.State);
    }
}
