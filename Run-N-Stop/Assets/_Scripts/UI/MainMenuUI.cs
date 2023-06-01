using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(() =>
        {
            SceneLoadManager.Instance.LoadNewGame();
        });
    }
}
