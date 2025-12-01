using UnityEngine;
using UnityEngine.SceneManagement;
// If you use TextMeshPro:
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score")]
    public int score = 0;
    public int targetScore = 15;     // eggs needed to win
    public TextMeshProUGUI scoreText;  // drag UI text here

    [Header("Timer")]
    public float timeLeft = 30f;       // countdown start time (seconds)
    public TextMeshProUGUI timerText;  // drag UI text here

    [Header("Scenes")]
    public string loseSceneName = "TabScene";
    public string winSceneName = "WinScene";

    void Awake()
    {
        // Simple singleton so PlayerCollector can call GameManager.Instance
        if (Instance == null)
        {
            Instance = this;
            // Optionally: DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Countdown
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0f)
            timeLeft = 0f;

        UpdateUI();

        if (timeLeft <= 0f)
        {
            Lose();
        }
    }

    public void AddEgg(int amount)
    {
        score += amount;
        UpdateUI();

        if (score >= targetScore)
        {
            Win();
        }
    }

    public void HitBomb()
    {
        // Called when the player collides with the bomb
        SceneManager.LoadScene(loseSceneName);
    }

    void Win()
    {
        SceneManager.LoadScene(winSceneName);
    }

    void Lose()
    {
        SceneManager.LoadScene(loseSceneName);
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Eggs: " + score.ToString();

        if (timerText != null)
            timerText.text = Mathf.CeilToInt(timeLeft).ToString();
    }
}