﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int enemyCurrentHealth;
    public static int bossCurrentHealth;
    public static int enemyMaxHealth;
    public static bool invulnerable = false;

    public GameObject blood;

    //private BoxCollider2D boxCol;
    //private CircleCollider2D cirCol;
    private SpriteRenderer rend;

    private void Start()
    {
        enemyCurrentHealth = maxHealth;
        bossCurrentHealth = maxHealth;
        enemyMaxHealth = maxHealth;
        //boxCol = GetComponent<BoxCollider2D>();
        //cirCol = GetComponent<CircleCollider2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(invulnerable == false)
        {
            if (collision.tag == "Weapon")
            {
                TakeDmg();
                Instantiate(blood, transform.position, transform.rotation);
            }
        }
    }

    void Update()
    { 
        if (enemyCurrentHealth <= 0)
        {
            //EnemyKnockback.enemyCanMove = false;
            //Time.timeScale = 0.3f;
            //Invoke("SetNormalTime", 0.05f);
            Invoke("DestroyObject", 1f);
            //rend.rendererPriority = -10;
            
        }
    }

    void SetNormalTime()
    {
        Time.timeScale = 1f;
    }

    void DestroyObject()
    {
        FindObjectOfType<SoundManeger>().Play("EnemyDeath");
        Destroy(gameObject);
    }

    public void TakeDmg()
    {
        enemyCurrentHealth--;
        print(enemyCurrentHealth);
        FindObjectOfType<SoundManeger>().Play("EnemyHit");
    }
}
