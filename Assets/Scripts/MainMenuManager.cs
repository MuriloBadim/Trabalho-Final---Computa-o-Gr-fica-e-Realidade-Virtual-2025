using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text difficultyText;

    private int difficulty = 1;

    void Start()
    {
        Debug.Log("MainMenuManager attached");
        difficulty = PlayerPrefs.GetInt("Difficulty", 1);
        UpdateDifficultyText();
    }

    public void PlayGame()
    {
        Debug.Log("PlayGame called");
        SceneManager.LoadScene("Jogo");
    }

    public void ChangeDifficulty()
    {
        difficulty++;
        if (difficulty > 2) difficulty = 1;
        PlayerPrefs.SetInt("Difficulty", difficulty);
        UpdateDifficultyText();
        Debug.Log("Dificuldade agora: " + difficulty);
    }

    void UpdateDifficultyText()
    {
        if (difficultyText != null)
        {
            string levelName = (difficulty == 1) ? "Normal" : "Difícil";
            string multiplier = (difficulty == 1) ? "1x" : "2x";

            difficultyText.text = $"Dificuldade: {levelName} ({multiplier})";
        }
    }

    public void OpenRanking()
    {
        SceneManager.LoadScene("Ranking");
    }

    public void OpenSobre()
    {
        SceneManager.LoadScene("Sobre");
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}
