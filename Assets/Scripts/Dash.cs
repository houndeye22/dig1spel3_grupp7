using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rbodyDash;
    public float dashSpeed = 50;
    private float dashTime;
    public float startDashTime = 0.1f;
    private int direction;

    private void Start()
    {
        rbodyDash = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    public void FixedUpdate()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
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
    }
}