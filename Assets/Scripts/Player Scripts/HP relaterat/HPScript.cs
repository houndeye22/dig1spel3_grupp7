using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public static int healthRemaining;
    public static int maxHealth = 6;

    public GameObject blood;



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
            Instantiate(blood, transform.position, transform.rotation);
            unTargetable = true;
            Invoke("Targetable", 1f);
            FindObjectOfType<SoundManeger>().Play("PlayerHurt");
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
