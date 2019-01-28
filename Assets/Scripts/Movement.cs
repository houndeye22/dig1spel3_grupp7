using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rbod1;
    public int moveSpeed;
    public float jumpThrust;
    public float dashSpeed;
    public float dashTime;
    public float dashStart;
    private int direction;


    // Start is called before the first frame update
    void Start()
    {
        dashSpeed = 4;
        rbod1 = GetComponent<Rigidbody2D>();
        dashTime = dashStart;
    }

    // Update is called once per frame
    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = dashStart;
                    rbod1.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (direction == 1)
                    {
                        rbod1.velocity = Vector2.left * dashSpeed;
                    } else
                    {
                        rbod1.velocity = Vector2.right * dashSpeed;
                    }
                }
            }
        }
    }

    void FixedUpdate()
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
