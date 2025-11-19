using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2D : MonoBehaviour
{
    public int enemiesToDestroy = 5;
    public float timeLimit = 60f;
    private int destroyedEnemies = 0;
    private float timer;

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            EndGame(false);

        if (destroyedEnemies >= enemiesToDestroy)
            EndGame(true);
    }

    public void EnemyDestroyed()
    {
        destroyedEnemies++;
    }

    void EndGame(bool win)
    {
        Debug.Log(win ? "Vitória!" : "Derrota!");
        SceneManager.LoadScene("MainMenu");
    }
}
