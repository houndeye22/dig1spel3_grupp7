using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMove : MonoBehaviour
{
    private Animator move;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            move.SetTrigger("move"); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
