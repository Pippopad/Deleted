using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private float moveSpeed = 5;
    private bool moving;
    public Vector2 lastMove;

    private static bool exists;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if(!exists)
        {
            exists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        moving = false;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal > 0.5f || horizontal < -0.5f)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            moving = true;
            lastMove = new Vector2(horizontal, 0.0f);
        }

        if(vertical > 0.5f || vertical < -0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * moveSpeed);
            moving = true;
            lastMove = new Vector2(0.0f, vertical);
        }

        if (horizontal < 0.5f && horizontal > -0.5f) rb.velocity = new Vector2(0f, rb.velocity.y);
        if (vertical < 0.5f && vertical > -0.5f) rb.velocity = new Vector2(rb.velocity.x, 0f);

        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
        animator.SetFloat("LastX", lastMove.x);
        animator.SetFloat("LastY", lastMove.y);
        animator.SetBool("Moving", moving);
    }
}
