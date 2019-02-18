using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    Rigidbody2D knockRbody;
    public float knockbackPwr;
    public float knockbackDur;
    public float knockbackLenght;
    public bool knockFromRight;

    void Start()
    {
        knockRbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            if (knockFromRight)
            {
                knockRbody.AddForce(transform.forward *-knockbackPwr);
            }
            else
            {
                knockRbody.velocity = new Vector2(knockbackPwr, knockbackPwr);
            }
            
        }
    }
}
