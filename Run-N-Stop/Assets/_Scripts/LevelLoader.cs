using System;
using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public delegate void LoadAction();

    public static event EventHandler<LoadAction> OnFadeIn;

    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField, Range(0f, 2f)] private float _targetAlpa;
    [SerializeField, Range(0f, 2f)] private float _alpaFadeDuration;

    private IEnumerator FadeIn(LoadAction loadAction)
    {
        float startTime = Time.time;
        float startAlpha = 0f;

        while (_canvasGroup.alpha < startAlpha)
        {
            float elapsedTime = Time.time - startTime;
            float normalizedTime = elapsedTime / _alpaFadeDuration;

            _canvasGroup.alpha = Mathf.Lerp(startAlpha, _targetAlpa, normalizedTime);

            yield return null;
        }

        OnFadeIn?.Invoke(this, loadAction);
    }

    public void InvokeFadeIn(LoadAction loadAction)
    {
        StartCoroutine(FadeIn(loadAction));
    }
}
