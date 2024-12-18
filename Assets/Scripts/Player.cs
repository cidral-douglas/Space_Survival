using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveAmount = getMoveInput().normalized * speed;
        runningAnimation();
        
    }

    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    private Vector2 getMoveInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void runningAnimation()
    {
        if (moveAmount != Vector2.zero)
        {
            setIsRunning(true);
        }
        else
        {
            setIsRunning(false);
        }
    }

    private void setIsRunning(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }
}
