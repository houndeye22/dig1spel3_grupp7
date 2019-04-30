using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public Projectile projectile;
    private Rigidbody2D spearBody;

    private void Start()
    {
        spearBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            projectile.speed = 0;
        }
    }

   
}
