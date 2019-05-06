using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHearts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && HPScript.healthRemaining < HPScript.maxHealth)
        {
            Destroy(gameObject);
            HPScript.healthRemaining++;
        }
    }
}
