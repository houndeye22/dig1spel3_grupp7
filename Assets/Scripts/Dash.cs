using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public float dashSpeed;
    private float dashTime;
    public float dashStartTime;
    private int direction;

    Rigidbody2D rbodyDash;

    
    void Start()
    {
        rbodyDash = GetComponent<Rigidbody2D>();
        dashTime = dashStartTime;
    }

    private void Update()
    {
    if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }

        }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = dashStartTime;
                    rbodyDash.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (direction == 1)
                    {
                        rbodyDash.velocity = Vector2.left* dashSpeed;
                    }
                else if (direction == 2)
                    {
                        rbodyDash.velocity = Vector2.right* dashSpeed;
                    }
                }
            }
    }
}
