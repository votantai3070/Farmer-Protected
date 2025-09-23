using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class GameManager : MonoBehaviour, IGameManager
{
    [Header("UI Setting")]
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private GameObject selectDiffPanel;

    public float currentTime;

    [Header("Atlas Setting")]
    public SpriteAtlas itemAtlas;
    public SpriteAtlas characterAtlas;
    public SpriteAtlas UIAtlas;

    [Header("Difficulty Setting")]
    public DifficultData currentDifficultData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        if (selectDiffPanel != null)
            selectDiffPanel.SetActive(false);
        if (gameWinPanel != null)
            gameWinPanel.SetActive(false);
        //if (timeText != null)
        //    timeText.enabled = false;
        string diff = PlayerPrefs.GetString("Difficulty", "Easy");

        currentDifficultData = Resources.Load<DifficultData>($"Difficulties/{diff}");
    }

    void Update()
    {
        if (timeText != null && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            ShowTime(currentTime);
        }
    }

    public void ShowTime(float timeToShow)
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
        Time.timeScale = 1f;
        Input.ResetInputAxes();
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
    }

    public void GameWin()
    {
        GamePause();
        if (gameWinPanel != null)
            gameWinPanel.SetActive(true);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameRestart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene != null) SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        if (selectDiffPanel != null)
            selectDiffPanel.SetActive(false);
        if (timeText != null)
            timeText.enabled = true;
        GameResume();
    }

    public void SelectDifficulty()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        if (selectDiffPanel != null)
            selectDiffPanel.SetActive(true);
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);
    }
}
