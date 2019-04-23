using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public static bool enemyCanMove = true;
    private Rigidbody2D rbody;
    public float knockbackPwr = 5;
    public float knockbackDir = 3;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword" && collision.transform.position.x < transform.position.x)
        {
            enemyCanMove = false;
            rbody.velocity = new Vector2(knockbackDir, knockbackPwr);
            Invoke("CanMoveAgain", 1f);
        }
        if (collision.tag == "Sword" && collision.transform.position.x > transform.position.x)
        {
            enemyCanMove = false;
            rbody.velocity = new Vector2(-knockbackDir, knockbackPwr);
            Invoke("CanMoveAgain", 1f);
        }
    }

    public void CanMoveAgain()
    {
        enemyCanMove = true;
    }
}
