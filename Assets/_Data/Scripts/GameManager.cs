using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class GameManager : MonoBehaviour, IGameManager
{
    [Header("UI Setting")]
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject gameOverPanel;

    public float startTime = 180f;
    [HideInInspector] public float currentTime;

    [Header("Atlas Setting")]
    public SpriteAtlas itemAtlas;
    public SpriteAtlas characterAtlas;
    public SpriteAtlas UIAtlas;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        currentTime = startTime;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (timeText != null && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            ShowTime(currentTime);
        }
    }

    void ShowTime(float timeToShow)
    {
        if (timeToShow < 0) timeToShow = 0;

        timeText.text = string.Format("{0:00}:{1:00}",
            Mathf.FloorToInt(timeToShow / 60),
            Mathf.FloorToInt(timeToShow % 60));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void GameResume()
    {
        throw new System.NotImplementedException();
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
    }

    public void GameWin()
    {
        throw new System.NotImplementedException();
    }

    public void GameQuit()
    {
        throw new System.NotImplementedException();
    }

    public void GameRestart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene != null) SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
    }
}
