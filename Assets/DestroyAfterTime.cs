using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    public float startTime;
    public float timeLeft;
    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
