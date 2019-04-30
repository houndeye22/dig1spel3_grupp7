using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float offset;

    public GameObject spear;
    public Transform throwPoint;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(spear, throwPoint.transform.position, throwPoint.transform.rotation);
        }
    }

    public void Throw()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(spear, throwPoint.transform.position, throwPoint.transform.rotation);
        }
    }
}
