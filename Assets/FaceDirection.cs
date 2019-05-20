using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour
{

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector2(2, transform.localScale.y);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-2, transform.localScale.y);
        }
    }
}