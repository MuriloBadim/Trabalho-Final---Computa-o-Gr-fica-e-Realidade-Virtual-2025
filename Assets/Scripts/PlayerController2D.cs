using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Velocidade e Aceleração")]
    public float minSpeed = 100f;
    public float maxSpeed = 300f;
    public float acceleration = 50f;
    public float deceleration = 50f;

    private float currentSpeed;

    [Header("Multiplicador da Velocidade de Movimento")]
    public float baseMoveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = minSpeed;
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed += acceleration * Time.deltaTime;

        if (Input.GetKey(KeyCode.C))
            currentSpeed -= deceleration * Time.deltaTime;

        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * currentSpeed * baseMoveSpeed;

        rb.rotation = 0;
    }
}
