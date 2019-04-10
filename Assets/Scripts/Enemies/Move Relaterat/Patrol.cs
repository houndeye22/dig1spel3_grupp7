using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    public bool movingRight = true;

    public bool left = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InvisibleWall")
        {
            left = !left;
        }
    }

    void Update()
    {
        if(EnemyKnockback.enemyCanMove == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (left == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
