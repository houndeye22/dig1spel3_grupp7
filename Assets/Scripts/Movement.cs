using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public Animator animator;

    public GroundCheck gCheck;
    public Rigidbody2D rbod1;
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
    public float dashTimerMax = 0.25f;

    public int dashKeystrokeCounter;

    public Slider slider;

    public bool movingLeft;
    public bool movingRight;


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

        if (Input.GetAxis("Horizontal") > 0)
        {
            movingRight = true;
            movingLeft = false;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            movingRight = false;
            movingLeft = true;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

    }

    void FixedUpdate()
    {

        //slider.value = dashTimer;

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
        if (gCheck.isGrounded == true)
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

    }
}
