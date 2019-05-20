using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public Movement mov;
    public GameObject dust;


    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            mov.isJumping = false;

            Dust();

            mov.animator.SetBool("isJumping", !isGrounded);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        mov.dashKeystrokeCounter = 0;
    }

    public void Dust()
    {
        Instantiate(dust, transform.position, transform.rotation);

    }
}

