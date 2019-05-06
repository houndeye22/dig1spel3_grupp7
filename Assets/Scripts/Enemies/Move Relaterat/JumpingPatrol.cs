using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPatrol : MonoBehaviour
{
    public float jumpHight;
    public float JumpLenght;
    public int timesJumped;
    public int jumpsUntillTurn;
    public bool left = false;

    public int onGround;

    public Rigidbody2D jumpBody;

    private void Start()
    {
        jumpBody = GetComponent<Rigidbody2D>();
        Invoke("Jumping", 1f);
    }

    void Update()
    {
        if (timesJumped == jumpsUntillTurn)
        {
            left = !left;
            timesJumped = 0;
        }
    }

    void Jumping()
    {
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
        }
    }
}
