using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public static bool enemyCanMove = true;
    private Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword" && collision.transform.position.x < transform.position.x)
        {
            enemyCanMove = false;
            rbody.velocity = new Vector2(5f, 10f);
            Invoke("CanMoveAgain", 0.7f);
        }
        if (collision.tag == "Sword" && collision.transform.position.x > transform.position.x)
        {
            enemyCanMove = false;
            rbody.velocity = new Vector2(-5f, 10f);
            Invoke("CanMoveAgain", 0.7f);
        }
    }

    public void CanMoveAgain()
    {
        enemyCanMove = true;

    }
}
