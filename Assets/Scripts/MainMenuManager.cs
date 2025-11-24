using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text difficultyText;

<<<<<<< HEAD
    private int difficulty = 1; // 1 = fácil, 2 = médio, 3 = difícil
=======
    private int difficulty = 1;
>>>>>>> master

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
<<<<<<< HEAD
        if (difficulty > 3) difficulty = 1;
=======
        if (difficulty > 2) difficulty = 1;
>>>>>>> master
        PlayerPrefs.SetInt("Difficulty", difficulty);
        UpdateDifficultyText();
        Debug.Log("Dificuldade agora: " + difficulty);
    }

    void UpdateDifficultyText()
    {
        if (difficultyText != null)
        {
<<<<<<< HEAD
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
=======
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
>>>>>>> master
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}
