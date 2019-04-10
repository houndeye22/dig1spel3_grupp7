using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ojj : MonoBehaviour
{
    private float moveInput;
    private Rigidbody2D rBody;

    public float moveSpeed;


    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rBody.velocity = new Vector2(moveInput * moveSpeed, rBody.velocity.y);
    }
}