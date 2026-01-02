using UnityEngine;

public class HANPlayer : Unit
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Animator animator;

    Vector2 moveInput;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ReadInput();
        UpdateAnimator();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    void ReadInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(x) > Mathf.Abs(y))
            y = 0;
        else
            x = 0;

        moveInput = new Vector2(x, y).normalized;
    }

    void UpdateAnimator()
    {
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);
    }
    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }
}
