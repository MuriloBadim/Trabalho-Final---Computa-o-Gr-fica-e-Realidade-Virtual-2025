using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text difficultyText;

    private int difficulty = 1; // 1 = fácil, 2 = médio, 3 = difícil

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
        if (difficulty > 3) difficulty = 1;
        PlayerPrefs.SetInt("Difficulty", difficulty);
        UpdateDifficultyText();
        Debug.Log("Dificuldade agora: " + difficulty);
    }

    void UpdateDifficultyText()
    {
        if (difficultyText != null)
        {
            string levelName = difficulty == 1 ? "Fácil" : difficulty == 2 ? "Médio" : "Difícil";
            difficultyText.text = "Dificuldade: " + levelName;
        }
    }

    public void OpenSkin()
    {
        SceneManager.LoadScene("SkinScene");
    }


    public void OpenRanking()
    {
        Debug.Log("Abrir ranking futuramente...");
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}
