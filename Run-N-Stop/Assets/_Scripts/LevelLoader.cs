using System;
using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public delegate void LoadAction();

    public static event EventHandler<LoadAction> OnFadeIn;

    [SerializeField] private CanvasGroup _canvasGroup;

    [Header("Fade-In Properties")]
    [SerializeField, Range(0f, 1f)] private float _targetFadeInAlpha;
    [SerializeField, Range(0f, 2f)] private float _alpaFadeInDuration;

    [Header("Fade-Out Properties")]
    [SerializeField, Range(0f, 1f)] private float _targetFadeOutAlpha;
    [SerializeField, Range(0f, 2f)] private float _alpaFadeOutDuration;

    private IEnumerator FadeIn(LoadAction loadAction)
    {
        float startTime = Time.time;
        float startAlpha = _canvasGroup.alpha;

        while (_canvasGroup.alpha < _targetFadeInAlpha)
        {
            float elapsedTime = Time.time - startTime;
            float normalizedTime = elapsedTime / _alpaFadeInDuration;

            _canvasGroup.alpha = Mathf.Lerp(startAlpha, _targetFadeInAlpha, normalizedTime);

            yield return null;
        }

        OnFadeIn?.Invoke(this, loadAction);
    }

    private IEnumerator FadeOut()
    {
        float startTime = Time.time;
        float startAlpha = 1f;

        while (_canvasGroup.alpha > _targetFadeOutAlpha)
        {
            float elapsedTime = Time.time - startTime;
            float normalizedTime = elapsedTime / _alpaFadeInDuration;

            _canvasGroup.alpha = Mathf.Lerp(startAlpha, _targetFadeInAlpha, normalizedTime);

            yield return null;
        }
    }

    public void InvokeFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    public void InvokeFadeIn(LoadAction loadAction)
    {
        StartCoroutine(FadeIn(loadAction));
    }
}
