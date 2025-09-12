using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI timeText;
    public float startTime = 180f;

    [HideInInspector] public float currentTime;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        currentTime = startTime;
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
}
