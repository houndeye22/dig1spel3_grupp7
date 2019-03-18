using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 3;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
