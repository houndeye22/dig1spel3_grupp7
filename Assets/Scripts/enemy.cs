using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool isLeft;
    public bool canWalk;
    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        canWalk = false;
    }

    public void Move(bool flip)
    {
        rbody = GetComponent<Rigidbody2D>();
        if (flip == true)
        {
            isLeft = !isLeft;
        }

        if (isLeft == true && canWalk == true)
        {
            rbody.velocity = new Vector2(-moveSpeed, rbody.velocity.y);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (isLeft == false && canWalk == true)
        {
            rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            rbody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InvisibleWall")
        {
            Move(true);
        }
    }
}