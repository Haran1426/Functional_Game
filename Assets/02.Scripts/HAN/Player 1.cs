using UnityEngine;

public class Player1 : MonoBehaviour
{
    private int HP;
    private int maxHP = 100;

    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator animator;

    void Start()
    {
        HP = maxHP;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;

        float speed = moveInput.magnitude;

        animator.SetFloat("Speed", speed);
        animator.SetBool("IsMove", speed > 0.1f);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
