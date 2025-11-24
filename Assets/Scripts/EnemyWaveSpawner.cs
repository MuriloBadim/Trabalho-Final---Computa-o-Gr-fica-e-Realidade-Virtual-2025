using UnityEngine;
using System.Collections;

public class EnemyWaveSpawner : MonoBehaviour
{
    [Header("Inimigos")]
    public GameObject[] enemyPrefabs; // inimigo pequeno, grande, etc.

    [Header("Spawn")]
    public Transform[] spawnPoints; // posições onde podem nascer
    public float timeBetweenWaves = 5f; // tempo entre as ondas

    [Header("Configuração das ondas")]
    public int enemiesPerWave = 3; // número fixo de inimigos por onda
    public float timeBetweenEnemies = 1f; // tempo entre o spawn de cada inimigo

    [Header("Configuração de Ondas")]
    public int totalWaves = 10; // Número total de ondas (ajuste para o valor desejado)

    private int waveNumber = 1;
    private bool isWaveActive = false;  // Variável para controlar a execução de cada onda

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

                // TentaSpawn para cada inimigo da onda
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    try
                    {
                        SpawnRandomEnemy();
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogError("Erro ao spawnar inimigo na Wave " + waveNumber + ":" + ex);
                    }

                    // Tempo entre spawns
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }

                Debug.Log("Wave " + waveNumber + " finalizada!");

                waveNumber++;

                // Tempo entre as ondas
                yield return new WaitForSeconds(timeBetweenWaves);

                // Garantir que a onda não fica presa
                isWaveActive = false;
            }
            else
            {
                // Espera curto intervalo antes de checar novamente
                yield return null;
            }
        }

        Debug.Log("Todas as " + totalWaves + " ondas foram spawnadas!");
    }

    void SpawnRandomEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            throw new System.Exception("Nenhum prefab de inimigo definido em enemyPrefabs!");
        }
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            throw new System.Exception("Nenhum ponto de spawn definido em spawnPoints!");
        }

        // Escolher inimigo aleatório
        GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        // Escolher ponto de spawn aleatório
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar o inimigo no ponto de spawn
        GameObject spawnedEnemy = Instantiate(enemy, point.position, Quaternion.identity);
        Debug.Log("Inimigo spawnado: " + enemy.name + " no ponto " + point.name);

        // Destruir o inimigo após 20 segundos
        Destroy(spawnedEnemy, 20f);
    }
}
