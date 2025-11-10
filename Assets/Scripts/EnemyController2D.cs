using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float amplitude = 1f;
    public float frequency = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(
            transform.position.x - moveSpeed * Time.deltaTime,
            startPos.y + offsetY,
            transform.position.z
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
