using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPatrol : MonoBehaviour
{
    public Animator animator;

    public float jumpHight;
    public float JumpLenght;
    public int timesJumped;
    public int jumpsUntillTurn;
    public bool left = false;

    public float sizeY = 1;
    public float sizeX = 1;

    public int onGround;

    public Rigidbody2D jumpBody;

    public float timer;
    public float maxTimer = 1;

    private void Start()
    {
        jumpBody = GetComponent<Rigidbody2D>();
        Invoke("Jumping", 1f);
    }

    void FixedUpdate()
    {
        if (left == true)
        {
            transform.localScale = new Vector3(-sizeX, sizeY, transform.position.z);
        }
        else
        {
            transform.localScale = new Vector3(sizeX, sizeY, transform.position.z);
        }

        if (timesJumped == jumpsUntillTurn)
        {
            left = !left;
            timesJumped = 0;
        }

        timer += 1;
        if (timer >= maxTimer)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
    }

    void Jumping()
    {
        animator.SetBool("isJumping", true);
        if (timesJumped < jumpsUntillTurn && onGround >= 1 && left == false)
        {
            jumpBody.velocity = new Vector2(JumpLenght, jumpHight);
            timesJumped++;
            onGround = 0;
        }
        if (timesJumped < jumpsUntillTurn && onGround >= 1 && left == true)
        {
            jumpBody.velocity = new Vector2(-JumpLenght, jumpHight);
            timesJumped++;
            onGround = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            onGround++;
            Invoke("Jumping", 0.5f);
            animator.SetBool("touchdown", true);
            animator.SetBool("isFalling", false);
            timer = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            animator.SetBool("touchdown", false);
        }
    }
}