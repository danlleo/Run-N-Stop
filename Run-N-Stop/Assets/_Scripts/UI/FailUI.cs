using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FailUI : MonoBehaviour
{
    [SerializeField] private Transform _failUI;
    [SerializeField] private Transform _background;
    [SerializeField] private Button _restartButton;

    [SerializeField, Range(0f, 1f)] private float _targetAlphaValue;
    [SerializeField, Range(0f, 2f)] private float _alphaFadeDuration;

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += Obstacle_OnPlayerHit;

        _restartButton.onClick.AddListener(() =>
        {
            SceneLoadManager.Instance.ReloadCurrentScene();
        });
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerHit -= Obstacle_OnPlayerHit;
    }

    private void Obstacle_OnPlayerHit(object sender, System.EventArgs e)
    {
        _failUI.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
        PlayerManager.Instance.State = PlayerManager.PlayerState.Idle;
    }

    private IEnumerator FadeIn()
    {
        CanvasGroup backgroundCanvasGroup = _background.GetComponent<CanvasGroup>();

        float startTime = Time.time;
        float startAlpha = backgroundCanvasGroup.alpha;

        while (backgroundCanvasGroup.alpha < _targetAlphaValue)
        {
            float elapsedTime = Time.time - startTime;
            float normalizedTime = elapsedTime / _alphaFadeDuration;

            backgroundCanvasGroup.alpha = Mathf.Lerp(startAlpha, _targetAlphaValue, normalizedTime);

            yield return null;
        }
    }
}
