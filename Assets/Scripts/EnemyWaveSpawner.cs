using UnityEngine;
using System.Collections;

public class EnemyWaveSpawner : MonoBehaviour
{
    [Header("Inimigos")]
    public GameObject[] enemyPrefabs;

    [Header("Spawn")]
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;

    [Header("Configuração das ondas")]
    public int enemiesPerWave = 3;
    public float timeBetweenEnemies = 1f;

    [Header("Total de ondas")]
    public int totalWaves = 10;

    private int waveNumber = 1;
    private bool isWaveActive = false;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (waveNumber <= totalWaves)
        {
            if (!isWaveActive)
            {
                Debug.Log("Iniciando Wave " + waveNumber + " de " + totalWaves);

                isWaveActive = true;

                for (int i = 0; i < enemiesPerWave; i++)
                {
                    SpawnRandomEnemy();
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }

                Debug.Log("Wave " + waveNumber + " finalizada!");

                waveNumber++;

                yield return new WaitForSeconds(timeBetweenWaves);

                isWaveActive = false;
            }
            else
            {
                yield return null;
            }
        }

        // 🔥 Final das ondas 🔥
        Debug.Log("🔥 Todas as ondas foram concluídas!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameWin();   // Mostra tela de vitória

           

            GameManager.Instance.FinishGame();  // Volta ao menu / termina o jogo
        }
    }

    void SpawnRandomEnemy()
    {
        GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject spawnedEnemy = Instantiate(enemy, point.position, Quaternion.identity);

        // Destruir depois de 20s (caso o jogador não mate)
        Destroy(spawnedEnemy, 20f);
    }
}
