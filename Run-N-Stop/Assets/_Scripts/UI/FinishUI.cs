using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    [SerializeField] private Transform _finishUI;
    [SerializeField] private Transform _background;
    [SerializeField] private Button _nextLevelButton;

    [SerializeField, Range(0f, 1f)] private float _colorLerpTargetValue;

    private void OnEnable()
    {
        FinishGround.OnPlayerFinish += FinishGround_OnPlayerFinish;

        _nextLevelButton.onClick.AddListener(() =>
        {
            SceneLoadManager.Instance.ReloadCurrentScene();
        });
    }

    private void FinishGround_OnPlayerFinish(object sender, System.EventArgs e)
    {
        _finishUI.gameObject.SetActive(true);
        StartCoroutine(LerpBackgroundColor());
    }

    private IEnumerator LerpBackgroundColor()
    {
        CanvasGroup backgroundCanvasGroup = _background.GetComponent<CanvasGroup>();

        float elapsedValue = 0f;
        
        while (elapsedValue < _colorLerpTargetValue)
        {
            backgroundCanvasGroup.alpha = Mathf.Lerp(0, _colorLerpTargetValue, elapsedValue);
            elapsedValue += Time.deltaTime;

            yield return null;
        }

        backgroundCanvasGroup.alpha = _colorLerpTargetValue;
    }
}
