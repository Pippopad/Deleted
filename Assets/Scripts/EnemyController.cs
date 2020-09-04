using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private float moveSpeed = 5;
    private bool moving;
    private float timeBetweenMove = 2;
    private float timeBetweenMoveCounter;
    private float timeToMove = 2;
    private float timeToMoveCounter;

    private Vector3 moveDirection;
    private Vector2 lastMove;

    private static bool exists;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    void Update()
    {
        if(moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rb.velocity = moveDirection;

            if(timeToMoveCounter < 0.0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        } else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0.0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1.0f, 1.0f) * moveSpeed, Random.Range(-1.0f, 1.0f) * moveSpeed, 0.0f);
                lastMove = new Vector2(moveDirection.x, moveDirection.y);
            }
        }

        animator.SetFloat("X", moveDirection.x);
        animator.SetFloat("Y", moveDirection.y);
        animator.SetFloat("LastX", lastMove.x);
        animator.SetFloat("LastY", lastMove.y);
        animator.SetBool("Moving", moving);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Load Attack Scene
        }
    }
}
