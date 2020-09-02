using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private float moveSpeed = 2;
    private bool moving;
    private float timeBetweenMove = 3;
    private float timeBetweenMoveCounter;
    private float timeToMove = 1;
    private float timeToMoveCounter;

    private int moveDirection;
    private Vector2 lastMove;

    public BoxCollider2D bounds;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    private bool canWalk;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;

        if(bounds != null)
        {
            minBounds = bounds.bounds.min;
            maxBounds = bounds.bounds.max;
            canWalk = true;
        }
    }

    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;

            switch (moveDirection)
            {
                case 0:
                    rb.velocity = new Vector2(0, moveSpeed);
                    if(canWalk && transform.position.y > maxBounds.y)
                    {
                        moving = false;
                        timeBetweenMoveCounter = timeBetweenMove;
                    }
                    break;
                case 1:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    if (canWalk && transform.position.x > maxBounds.x)
                    {
                        moving = false;
                        timeBetweenMoveCounter = timeBetweenMove;
                    }
                    break;
                case 2:
                    rb.velocity = new Vector2(0, -moveSpeed);
                    if (canWalk && transform.position.y < minBounds.y)
                    {
                        moving = false;
                        timeBetweenMoveCounter = timeBetweenMove;
                    }
                    break;
                case 3:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    if (canWalk && transform.position.x < minBounds.x)
                    {
                        moving = false;
                        timeBetweenMoveCounter = timeBetweenMove;
                    }
                    break;
            }

            if (timeToMoveCounter < 0.0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0.0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                moveDirection = (int) Random.Range(0.0f, 4.0f);
                switch (moveDirection)
                {
                    case 0:
                        lastMove = new Vector2(0.0f, 1.0f);
                        break;
                    case 1:
                        lastMove = new Vector2(1.0f, 0.0f);
                        break;
                    case 2:
                        lastMove = new Vector2(0.0f, -1.0f);
                        break;
                    case 3:
                        lastMove = new Vector2(-1.0f, 0.0f);
                        break;
                }
            }
        }

        animator.SetFloat("X", rb.velocity.x);
        animator.SetFloat("Y", rb.velocity.y);
        animator.SetFloat("LastX", lastMove.x);
        animator.SetFloat("LastY", lastMove.y);
        animator.SetBool("Moving", moving);
    }
}
