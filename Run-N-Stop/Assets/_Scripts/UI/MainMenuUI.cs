using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private Button _playButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(() =>
        {
            _levelLoader.InvokeFadeIn(SceneLoadManager.Instance.LoadNewGame);
        });
    }
}
