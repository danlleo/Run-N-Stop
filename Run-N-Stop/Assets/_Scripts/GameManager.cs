using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        Victory,
        Fail,
        Playing
    }

    [HideInInspector]
    public GameState State;

    [SerializeField] private LevelLoader _levelLoader;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        State = GameState.Playing;
    }

    private void OnEnable()
    {
        _levelLoader.gameObject.SetActive(true);
        _levelLoader.InvokeFadeOut();
    }
}
