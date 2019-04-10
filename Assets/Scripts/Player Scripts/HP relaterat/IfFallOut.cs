using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfFallOut : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        HPScript.healthRemaining = 0;
        
    }
}
