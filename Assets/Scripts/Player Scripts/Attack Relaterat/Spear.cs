using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public Projectile projectile;
    private Rigidbody2D spearBody;
    public float speed;
    public float flyTime;

    private void Start()
    {
        spearBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        flyTime += Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -flyTime * 20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
