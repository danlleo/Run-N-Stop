using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1000)]
public class SceneLoadManager : MonoBehaviour
{
    private static readonly string FIRST_LEVEL = "GameScene";

    public static SceneLoadManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void LoadNewGame()
    {
        Scene firstLevel = SceneManager.GetSceneByName(FIRST_LEVEL);
        SceneManager.LoadScene(firstLevel.buildIndex);
    }
}
