using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackOnCollision : MonoBehaviour
{
    private Rigidbody2D rbody;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && HPScript.unTargetable == false && collision.transform.position.x < transform.position.x)
        {
            Movement.canMove = false;
            rbody.velocity = new Vector2(5f, 10f);
            Invoke("CanMoveAgain", 0.7f);
        }
        if (collision.tag == "Enemy" && HPScript.unTargetable == false && collision.transform.position.x > transform.position.x)
        {
            Movement.canMove = false;
            rbody.velocity = new Vector2(-5f, 10f);
            Invoke("CanMoveAgain", 0.7f);
        }
    }

    public void CanMoveAgain()
    {
        Movement.canMove = true;
    }*/
}
