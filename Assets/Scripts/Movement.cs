using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GroundCheck gCheck;
    Rigidbody2D rbod1;
    public int moveSpeed = 10;
    public float jumpThrust = 30;

    public static bool canMove;

    public float jumpMax = 0.3f;
    public float jumpTime;

    public bool isJumping;

    public Vector2 dashSpeed;
    public bool canDash;
    public bool isDashing;

    public float dashTimer;
    public float dashTimerMax;

    public int dashKeystrokeCounter;

    public Slider slider;


    void Start()
    {
        rbod1 = GetComponent<Rigidbody2D>();
        //gCheck = GetComponent<GroundCheck>();
        rbod1.gravityScale = 6;

        canMove = true;
        canDash = true;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            dashKeystrokeCounter += 1;
        }
    }

    void FixedUpdate()
    {


<<<<<<< HEAD

        if (Input.GetAxisRaw("Jump") > 0)

        print(Input.GetButton("Jump"));
        Dash();
        Jump();
=======
        slider.value = dashTimer;

        if (gCheck.isGrounded == true)
        {
            isDashing = false;
        }

        if (canMove == true)
        {

            DashHandler();

            if (isDashing == false)
            {
                Jump();
            }


            //Normal movement
            rbod1.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rbod1.velocity.y);

            if (canDash == true)
            {
                Dash();
            }
            if (gCheck.isGrounded == true)
            {
                dashKeystrokeCounter = 0;
            }
        }

        if (Input.GetButtonUp("Fire2") && dashKeystrokeCounter >= 1)
        {
            canDash = false;
        }
>>>>>>> 4f953382c174d0207ff561c992960019afbdfdce
    }




    void Jump()
    {
        //If you jump while grounded...
        if (Input.GetButton("Jump") && gCheck.isGrounded == true)
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
<<<<<<< HEAD


        Jump1();

        if (isGrounded == true)
=======
        if (gCheck.isGrounded == true)
>>>>>>> 4f953382c174d0207ff561c992960019afbdfdce
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



    void Dash()
    {


        if (dashKeystrokeCounter >= 1)
        {
            canDash = false;
        }
        else
        {
            canDash = true;
        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetButton("Fire2"))
        {
            if (dashTimer <= dashTimerMax && canDash == true)
            {
                dashTimer += Time.deltaTime;
                if (canDash == true)
                {
                    isDashing = true;
                    rbod1.MovePosition(rbod1.position + dashSpeed * Time.deltaTime);
                }
            }

        }
        if (Input.GetAxis("Horizontal") < 0 && Input.GetButton("Fire2"))
        {
            if (dashTimer <= dashTimerMax && canDash == true)
            {
                dashTimer += Time.deltaTime;
                if (canDash == true)
                {
                    isDashing = true;
                    rbod1.MovePosition(rbod1.position - dashSpeed * Time.deltaTime);
                }
            }

        }
    }

    void DashHandler()
    {
        if (dashTimer > dashTimerMax)
        {
            canDash = false;
        }
        if (dashTimer <= dashTimerMax)
        {
            canDash = true;
        }
        else
        {
            canDash = false;
        }
<<<<<<< HEAD
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
                    rbod1.AddForce(Vector2.up * jumpThrust * 2.5f);
                }

            }
            else
            {
                isJumping = false;
            }
        }
=======

        if (dashKeystrokeCounter <= 1)
        {
            if (gCheck.isGrounded == true && dashTimer >= 0 && !Input.GetButton("Fire2"))
            {
                dashTimer -= Time.deltaTime / 10;
            }
            if (isJumping == true && dashTimer >= 0 && !Input.GetButton("Fire2"))
            {
                dashTimer -= Time.deltaTime / 10;
            }
        }

>>>>>>> 4f953382c174d0207ff561c992960019afbdfdce
    }
}