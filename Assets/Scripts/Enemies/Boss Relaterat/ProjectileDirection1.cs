using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDirection1 : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public float offset;
    

    void Update()
    {
        Vector3 difference = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    } 

    public void Bullet()
    {
        Instantiate(projectile, transform.position, transform.rotation);
   
    }
}
