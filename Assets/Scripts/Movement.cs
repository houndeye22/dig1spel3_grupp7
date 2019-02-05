using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rbod1;
    public int moveSpeed;
    public float jumpThrust;

    public float jumpMax;
    public float jumpTime;

    public bool isJumping;
    public bool hasJumped;


    void Start()
    {
        rbod1 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rbod1.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rbod1.velocity.y);

        print(Input.GetButton("Jump"));


        //If you jump while grounded...
        if (Input.GetButton("Jump") && isGrounded == true)
        {
            isJumping = true;
            rbod1.velocity = new Vector2(rbod1.velocity.x, jumpThrust / 7);

        }
        //Subtracts a small numeral
        if (Input.GetButton("Jump"))
        {
            if (jumpTime > 0)
            {
                jumpTime -= Time.deltaTime;
            }
        }
        if (isGrounded == true)
        {
            jumpTime = jumpMax;
        }
        if (Input.GetButton("Jump") && jumpTime > 0 && isJumping == true)
        {
            rbod1.AddForce(Vector2.up * jumpThrust * jumpTime * 20);
        }
        else
        {
            isJumping = false;
        }

    }



    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        isJumping = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }




}