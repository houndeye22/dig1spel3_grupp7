using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rbodyDash;
    public float dashSpeed;
    private float dashTime;
    public float dashTimeStart;
    private int direction;
    private bool isDashing;

    private void Start()
    {
        rbodyDash = GetComponent<Rigidbody2D>();
        dashTime = dashTimeStart;
        isDashing = false;
    }



    private void Update()
    {

        if (Input.GetAxis("Horizontal") > 0)
        {
            if(Input.GetButtonDown("Fire2"))
            {

            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {

        }

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                direction = 1;
                isDashing = true;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                direction = 2;
                isDashing = true;
            }
        }
        else
        {
            if (dashTime < 0)
            {
                direction = 0;
                isDashing = false;
                dashTime = dashTimeStart;
                rbodyDash.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rbodyDash.velocity = Vector2.left * dashSpeed;
                }
                if (direction == 2)
                {
                    rbodyDash.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
}
