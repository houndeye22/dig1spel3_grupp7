using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public Movement mov;
    public GameObject dust;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            mov.isJumping = false;

            Instantiate(dust, transform.position, transform.rotation);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        mov.dashKeystrokeCounter = 0;
    }
}

