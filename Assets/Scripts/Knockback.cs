using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    private GameObject player;
    private Transform playerTransform;
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();


        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "<ENTER_TAG_HERE>")
        {
            if (transform.position.x < playerTransform.position.x)
            {
                print("Right");
                rbody.velocity = new Vector2(Random.Range(-maxX, -minX), Random.Range(-maxY, -minY));
            }
            else
                print("Left");
            rbody.velocity = new Vector2(Random.Range(maxX, minX), Random.Range(maxY, minY));
        }
    }

    //TESTRUN ta bort i spel senare
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.x < playerTransform.position.x)
            {
                print("Right");
                rbody.velocity = new Vector2(Random.Range(-maxX, -minX), Random.Range(maxY, minY));
            }
            else
            {
                print("left");
                rbody.velocity = new Vector2(Random.Range(maxX, minX), Random.Range(maxY, minY));
            }
        }
    }
}


