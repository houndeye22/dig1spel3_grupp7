using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    private Rigidbody2D spearBody;
    public float speed;
    public float flyTime;

    private void Start()
    {
        spearBody = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        spearBody.velocity = ((Vector2)transform.right * speed * Time.deltaTime);

        Vector2 dir = spearBody.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
