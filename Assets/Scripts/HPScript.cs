using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public static int healthRemaining;
    public static int maxHealth = 6;



    public static bool unTargetable = false;

    void Start()
    {
        healthRemaining = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && unTargetable == false && PlayerAttack.noDmg == false)
        {
            healthRemaining--;
            unTargetable = true;
            Invoke("Targetable", 1f);
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
