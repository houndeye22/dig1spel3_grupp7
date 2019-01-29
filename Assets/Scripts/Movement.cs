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
            rbod1.velocity = new Vector2(rbod1.velocity.x, jumpThrust / 3);
        
        }
        //Adds a small numeral
        if(Input.GetButton("Jump"))
        {
            jumpTime += Time.deltaTime;
        }
        if(isGrounded  == true)
        {
            jumpTime = 0;
        }
        if (Input.GetButton("Jump") && jumpTime < jumpMax && isJumping == true)
        {
            rbod1.AddForce(Vector2.up * jumpThrust * 2);
        }
        else
        {
            isJumping = false;
        }
        //if(Input.GetButtonUp("Jump"))
        //{
        //    isJumping = false;
        //}


        //Jump1();

    }



    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        isJumping = false;
        hasJumped = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }




    void Jump1()
    {

        if (isJumping == true)
        {
            if (Input.GetAxisRaw("Jump") == 0)
            {
                hasJumped = true;
            }
        }
        if (hasJumped == true)
        {
            isJumping = false;
        }



        if (Input.GetAxisRaw("Jump") > 0 && isGrounded == true)
        {
            jumpTime = 0;
        }


        if (Input.GetAxisRaw("Jump") > 0 && hasJumped == false)
        {
            isJumping = true;
        }
        if (Input.GetAxisRaw("Jump") > 0 && isJumping == true)
        {
            if (jumpTime < jumpMax)
            {

                jumpTime += Time.deltaTime;
                rbod1.AddForce(Vector2.up * jumpThrust); //new Vector2(rbod1.velocity.x, jumpCounter);

                if (jumpTime < jumpMax / 5)
                {
                    rbod1.AddForce(Vector2.up * jumpTime * 5);
                }

            }
            else
            {
                isJumping = false;
            }
        }
    }
}
