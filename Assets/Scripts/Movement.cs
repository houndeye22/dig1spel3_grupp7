using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rbod1;
    public int moveSpeed;
    public float jumpThrust;
    private Rigidbody2D rbodyDash;
    public float dashSpeed = 50;
    private float dashTime;
    public float startDashTime = 0.1f;
    private int direction;
    public bool isDashing;

    void Start()
    {
        rbodyDash = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        rbod1 = GetComponent<Rigidbody2D>();
        isDashing = true;
    }


    void FixedUpdate()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isDashing = false;
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                isDashing = false;
                direction = 2;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rbodyDash.velocity = Vector2.zero;
                isDashing = true;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rbodyDash.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rbodyDash.velocity = Vector2.right * dashSpeed;
                }
            }
        }

        if (isDashing == true)
        {
            rbod1.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rbod1.velocity.y);

            if (Input.GetAxisRaw("Jump") > 0)
            {
                if (isGrounded == true)
                {
                    rbod1.velocity = new Vector2(rbod1.velocity.x, jumpThrust);
                }
            }
        }
    }


    public bool isGrounded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}

