using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public static int healthRemaining;
    public static int maxHealth = 6;

    private PlayerKnockback knockback;


    public static bool unTargetable = false;

    void Start()
    {
        healthRemaining = maxHealth;
        knockback = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerKnockback>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && unTargetable == false)
        {
            healthRemaining--;
            unTargetable = true;
            Invoke("Targetable", 1.5f);

            StartCoroutine(knockback.Knockback(0.02f, 300f, knockback.transform.position));
        }
        if (collision.tag == " Health" && healthRemaining < maxHealth)
        {
            healthRemaining++;
            print(healthRemaining);
        }
    }

    void Targetable()
    {
        unTargetable = false;
    }
}
