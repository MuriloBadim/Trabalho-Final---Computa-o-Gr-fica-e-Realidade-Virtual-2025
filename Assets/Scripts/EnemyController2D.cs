using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float amplitude = 1f;
    public float frequency = 2f;

    private Vector3 startPos;
    private EnemyData data;
    private Transform player;

    private bool blockedByBarrier = false;
    private bool isDead = false;

    void Start()
    {
        startPos = transform.position;

        data = GetComponent<EnemyData>();

        if (data == null)
            Debug.LogError("ERRO: EnemyData faltando no inimigo!", gameObject);

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
        else
            Debug.LogError("ERRO: Nenhum objeto com a Tag 'Player' foi encontrado!");

        ApplyDifficulty();
    }

    void ApplyDifficulty()
    {
        int diff = PlayerPrefs.GetInt("Difficulty", 1);

        if (diff == 1)
        {
            // NORMAL
            return;
        }
        else
        {
            // DIFÍCIL – aumenta vida e velocidade
            moveSpeed *= 1.5f;
            data.health += 2;
        }
    }

    void Update()
    {
        if (player == null || blockedByBarrier || isDead)
            return;

        // Movimento em direção ao jogador
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Movimento senoidal
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude * Time.deltaTime;
        transform.position += new Vector3(0, offsetY, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Bateu na barreira
        if (other.CompareTag("EnemyBoundary"))
        {
            blockedByBarrier = true;
            return;
        }

        // Tiro
        if (other.CompareTag("Projectile"))
        {
            if (data == null || isDead) return;

            data.health--;
            Destroy(other.gameObject);

            if (data.health <= 0)
            {
                Die();
            }
        }

        // Jogador
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDied();
            Destroy(other.gameObject); // remove o jogador
            Destroy(gameObject);       // inimigo morre também
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBoundary"))
        {
            blockedByBarrier = false;
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        GameManager.Instance.AddScore(data.points);

        Destroy(gameObject);
    }
}
