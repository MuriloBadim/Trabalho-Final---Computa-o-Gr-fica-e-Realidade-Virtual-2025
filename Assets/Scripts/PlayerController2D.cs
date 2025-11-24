using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
<<<<<<< HEAD
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
=======
    [Header("Velocidade e Aceleração")]
    public float minSpeed = 100f;
    public float maxSpeed = 300f;
    public float acceleration = 50f;
    public float deceleration = 50f;

    private float currentSpeed;

    [Header("Multiplicador da Velocidade de Movimento")]
    public float baseMoveSpeed = 2f;
>>>>>>> master

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
=======
        currentSpeed = minSpeed;
>>>>>>> master
    }

    void Update()
    {
<<<<<<< HEAD
        // Movimento
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        // Tiro
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
=======
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed += acceleration * Time.deltaTime;

        if (Input.GetKey(KeyCode.C))
            currentSpeed -= deceleration * Time.deltaTime;

        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
>>>>>>> master
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        // Corrigido: movimento correto no Rigidbody
        rb.linearVelocity = moveInput.normalized * moveSpeed;

        rb.rotation = 0; // Impede rotação da nave ao colidir com algo
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
=======
        rb.linearVelocity = moveInput.normalized * currentSpeed * baseMoveSpeed;

        rb.rotation = 0;
>>>>>>> master
    }
}
