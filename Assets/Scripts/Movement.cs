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
    public bool hasJumped;

    public int dashSpeed;
    public bool canDash;
    public float dashTimerRecharge;
    public float dashTimerMaxRecharge = 1;
    public bool isDashing;

    public Slider slider;


    void Start()
    {
        rbod1 = GetComponent<Rigidbody2D>();
        //gCheck = GetComponent<GroundCheck>();
        rbod1.gravityScale = 6;
        dashTimerRecharge = 0;
        canMove = true;
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {


        slider.value = dashTimerRecharge;

        if(gCheck.isGrounded == true)
        {
            isDashing = false;
        }

        if (canMove == true)
        {
            Jump();
            Dash();
            rbod1.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rbod1.velocity.y);
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

        dashTimerRecharge += Time.deltaTime;
        if (dashTimerRecharge <= dashTimerMaxRecharge)
        {
            canDash = true;
        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetButton("Fire2"))
        {
            dashTimerRecharge += Time.deltaTime;
            if (canDash == true)
            {
                isDashing = true;
                rbod1.velocity = Vector3.Lerp(new Vector3(1, 0), new Vector3(dashSpeed, 0), 0.125f);
            }
        }
        if (Input.GetAxis("Horizontal") < 0 && Input.GetButton("Fire2"))
        {
            dashTimerRecharge += Time.deltaTime;
            if (canDash == true)
            {
                isDashing = true;
                rbod1.velocity = Vector3.Lerp(new Vector3(1, 0), new Vector3(-dashSpeed, 0), 0.125f);
            }
        }
    }
}