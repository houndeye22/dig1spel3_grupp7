using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    Rigidbody2D rbody2;

    void Start()
    {
        rbody2 = GetComponent<Rigidbody2D>();
    }

    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rbody2.AddForce(new Vector3(knockDir.x * -100, knockDir.y * knockPwr, transform.position.z));
        }

        yield return 0;
    }
}
