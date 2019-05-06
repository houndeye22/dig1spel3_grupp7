using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Rigidbody2D bossBody;

    public ProjectileDirection1 projectileDirection;
    public float jumpHight;
    public float JumpLenght;
    public int timesJumped;
    public int onGround;
    public int nextAction;

    public int shots;
    public float timeBetweenShot;
    public float startTimeBetweenShot = 0.5f;

    public int heal = 2;

    public GameObject player;


    void Start()
    {
        bossBody = GetComponent<Rigidbody2D>();
        //Invoke("NextAction", 3);
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
            onGround = 0;
        }
        if (player.transform.position.x > transform.position.x && timesJumped == 0 && onGround >= 1)
        {
            bossBody.velocity = new Vector2(JumpLenght, jumpHight);
            timesJumped++;
            onGround = 0;
        }
        Invoke("NextAction", 5);
    }
    
    void Attack()
    {
        projectileDirection.Bullet();
        Invoke("NextAction", 5);
    }

    void Regenerate()
    {
        EnemyHealth.invulnerable = true;
        print("reg");

        for(int i = 0; i < heal; i++)
        {
            if(EnemyHealth.bossCurrentHealth < EnemyHealth.enemyMaxHealth)
            {
                EnemyHealth.bossCurrentHealth++;
            }
        }
        Invoke("NextAction", 5);
    }

    void NextAction()
    {
        EnemyHealth.invulnerable = false;
        nextAction = Random.Range(0, 5);
        timesJumped = 0;
        shots = 0;
        if (nextAction == 0 || nextAction == 3)
        {
            Jumping();
        }
        else if(nextAction == 1 || nextAction == 2)
        {
            Attack();
        }
        else if( nextAction == 4)
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