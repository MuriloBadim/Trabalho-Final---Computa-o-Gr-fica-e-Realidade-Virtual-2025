using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float amplitude = 1f;
    public float frequency = 2f;

    private Vector3 startPos;
    private EnemyData data;

    void Start()
    {
        startPos = transform.position;

        // tenta pegar EnemyData (obrigatório no prefab)
        data = GetComponent<EnemyData>();

        if (data == null)
        {
            Debug.LogError("ERRO: Este inimigo não possui EnemyData anexado!", gameObject);
        }
    }

    void Update()
    {
        // movimento
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = new Vector3(
            transform.position.x - moveSpeed * Time.deltaTime,
            startPos.y + offsetY,
            transform.position.z
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // tiro
        if (other.CompareTag("Projectile"))
        {
            if (data == null) return;

            data.health--;

            Destroy(other.gameObject); // destrói o tiro ao bater

            if (data.health <= 0)
            {
                GameManager.Instance.AddScore(data.points);
                Destroy(gameObject);
            }
        }

        // colisão com o jogador
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // mata o jogador
            Destroy(gameObject);       // opcional: inimigo morre junto
        }
    }
}
