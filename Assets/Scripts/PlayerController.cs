using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    private float moveSpeed = 5;
    private bool moving;
    private Vector2 lastMove;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moving = false;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal > 0.5f || horizontal < -0.5f)
        {
            transform.Translate(new Vector3(horizontal * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
            moving = true;
            lastMove = new Vector2(horizontal, 0.0f);
        }

        if (vertical > 0.5f || vertical < -0.5f)
        {
            transform.Translate(new Vector3(0.0f, vertical * moveSpeed * Time.deltaTime, 0.0f));
            moving = true;
            lastMove = new Vector2(0.0f, vertical);
        }

        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
        animator.SetFloat("LastX", lastMove.x);
        animator.SetFloat("LastY", lastMove.y);
        animator.SetBool("Moving", moving);
    }
}
