using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTim3 : MonoBehaviour
{
    public float timeUntillDestroy;
    public float timePassed;

    private void Start()
    {
        timePassed = timeUntillDestroy;
    }

    void Update()
    {
        timePassed -= Time.deltaTime;

        if(timePassed <= 0)
        {
            Destroy(gameObject);
        }
    }
}
