using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Rigidbody2D bossBody;

    public float jumpHight;
    public float JumpLenght;
    public int timesJumped;
    public int onGround;
    public int nextAction;

    public int heal = 2;

    public GameObject shotPoint;
    public GameObject player;
    public GameObject projectile;


    void Start()
    {
        bossBody = GetComponent<Rigidbody2D>();
        Invoke("NextAction", 3);
    }

    
    void Update()
    {
        
    }

    void Jumping()
    {
        if(player.transform.position.x < transform.position.x && timesJumped == 0 && onGround >= 1)
        {
            bossBody.velocity = new Vector2 (-JumpLenght, jumpHight);
            timesJumped++;
            Invoke("NextAction", 5);
            onGround = 0;
        }
        if (player.transform.position.x > transform.position.x && timesJumped == 0 && onGround >= 1)
        {
            bossBody.velocity = new Vector2(JumpLenght, jumpHight);
            timesJumped++;
            Invoke("NextAction", 5);
            onGround = 0;
        }
    }
    
    void Attack()
    {
        Instantiate(projectile, shotPoint.transform.position, transform.rotation);
        print("Attack");
        Invoke("NextAction", 5);
    }

    void Regenerate()
    {
        EnemyHealth.invulnerable = true;
        print("reg");

        for(int i = 0; i < heal; i++)
        {
            if(EnemyHealth.enemyCurrentHealth < EnemyHealth.enemyMaxHealth)
            {
                EnemyHealth.enemyCurrentHealth++;
            }
        }
        Invoke("NextAction", 5);
    }

    void NextAction()
    {
        EnemyHealth.invulnerable = false;
        nextAction = Random.Range(0, 3);
        timesJumped = 0;
        if (nextAction == 0)
        {
            Jumping();
        }
        else if(nextAction == 1)
        {
            Attack();
        }
        else if( nextAction == 2)
        {
            Regenerate();
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            onGround++;
        }
    }
}


//bossCol.gameObject.tag == "Ground" && 