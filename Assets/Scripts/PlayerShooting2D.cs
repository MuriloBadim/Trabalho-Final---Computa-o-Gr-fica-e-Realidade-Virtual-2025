using UnityEngine;

public class PlayerShooting2D : MonoBehaviour
{
    [Header("Sprite / Visual")]
    public Sprite projectileSprite;
    public string projectileSortingLayer = "Player";
    public int projectileSortingOrder = 5;

    [Header("Movimentação do tiro")]
    public Vector3 projectileScale = new Vector3(5f, 5f, 1f);
    public float projectileSpeed = 10f;
    public float projectileLifetime = 5f;

    [Header("Tiro")]
    public Transform firePointLeft;
    public Transform firePointRight;
    public float fireRate = 0.1f;
    private float nextFireTime = 0f;

    [Header("Som do tiro")]
    public AudioSource audioSource;
    public AudioClip shootSFX;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // cria os tiros
        CreateProjectile(firePointLeft.position);
        CreateProjectile(firePointRight.position);

        // toca o som
        if (audioSource != null && shootSFX != null)
            audioSource.PlayOneShot(shootSFX);
    }

    void CreateProjectile(Vector3 position)
    {
        GameObject projectile = new GameObject("Projectile");

        SpriteRenderer sr = projectile.AddComponent<SpriteRenderer>();
        sr.sprite = projectileSprite;
        sr.sortingLayerName = projectileSortingLayer;
        sr.sortingOrder = projectileSortingOrder;

        projectile.transform.position = position;
        projectile.transform.localScale = projectileScale;

        Rigidbody2D rb = projectile.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        CircleCollider2D cc = projectile.AddComponent<CircleCollider2D>();
        cc.isTrigger = true;

        rb.linearVelocity = Vector2.up * projectileSpeed;

        projectile.AddComponent<ProjectileCollision>();

        Destroy(projectile, projectileLifetime);
    }
}
