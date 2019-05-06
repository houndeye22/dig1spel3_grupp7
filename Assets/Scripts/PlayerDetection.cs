using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public enemy enemy;
    public Transform player;
    public Transform flyingEnemy;
    public Transform nestPosition;
    public bool chasisng;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.canWalk = true;
            enemy.Move(false);
        }        
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chasisng = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            flyingEnemy.transform.position = Vector2.MoveTowards
                (flyingEnemy.transform.position, player.transform.position, enemy.moveSpeed * Time.deltaTime);
            chasisng = true;
        }
    }

    private void Update()
    {
        transform.position = flyingEnemy.transform.position;

        if (chasisng == false)
        {
            flyingEnemy.transform.position = Vector2.MoveTowards
                (flyingEnemy.transform.position, nestPosition.transform.position, enemy.moveSpeed * Time.deltaTime);
        }
    }
}
