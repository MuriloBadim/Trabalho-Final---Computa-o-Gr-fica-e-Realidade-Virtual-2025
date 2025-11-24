using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Pontuação")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    [Header("Game Win")]
    public GameObject gameWinPanel;

    private bool isGameOver = false;
    private bool hasWon = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScore();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (gameWinPanel != null)
            gameWinPanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        if (isGameOver || hasWon) return;

        score += amount;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void PlayerDied()
    {
        if (hasWon) return;

        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    // 🔥 GAME WIN
    public void GameWin()
    {
        if (isGameOver) return;

        hasWon = true;

        if (gameWinPanel != null)
            gameWinPanel.SetActive(true);

        Time.timeScale = 0f;

        Debug.Log("🎉 VITÓRIA! O jogador venceu o jogo!");
    }

    // 🔥 CHAMADO PELO SPAWNER QUANDO TERMINA TODAS AS ONDAS
    public void FinishGame()
    {
        int finalScore = score;

        // Carregar dificuldade
        int difficulty = PlayerPrefs.GetInt("Difficulty", 1);

        // Se difícil → dobra
        if (difficulty == 2)
            finalScore *= 2;

        // Salvar score no ranking
        RankingManager.SaveScore(finalScore);

        Debug.Log("🏆 Score salvo no ranking: " + finalScore);

        // Voltar ao menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
