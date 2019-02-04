using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isAttacking = false;
   
    public float attackCd = 1f;
    public float attackTriggerCd = 0.3f;

    public GameObject attackTriggerUp;
    public GameObject attackTriggerRight;
    public GameObject attackTriggerLeft;
    public GameObject attackTriggerDown;

    void Awake()
    {
        attackTriggerDown.SetActive(false);
        attackTriggerRight.SetActive(false);
        attackTriggerUp.SetActive(false);
        attackTriggerLeft.SetActive(false);
    }

    void Update()
    {
        //if(Input.GetAxis("") > 0)

        if (Input.GetButtonDown("Fire1") && !isAttacking && Input.GetAxis("Horizontal") > 0)
        {
            isAttacking = true;
            attackTriggerRight.SetActive(true);
            Invoke("CanAttack", attackCd);
            Invoke("AttackTriggerActive", attackTriggerCd);
        }
        else if (Input.GetButtonDown("Fire1") && !isAttacking && Input.GetAxis("Horizontal") < 0)
        {
            isAttacking = true;
            attackTriggerLeft.SetActive(true);
            Invoke("CanAttack", attackCd);
            Invoke("AttackTriggerActive", attackTriggerCd);
        }
        else if (Input.GetButtonDown("Fire1") && !isAttacking && Input.GetAxis("Vertical") > 0)
        {
            isAttacking = true;
            attackTriggerUp.SetActive(true);
            Invoke("CanAttack", attackCd);
            Invoke("AttackTriggerActive", attackTriggerCd);
        }
        else if (Input.GetButtonDown("Fire1") && !isAttacking && Input.GetAxis("Vertical") < 0)
        {
            isAttacking = true;
            attackTriggerDown.SetActive(true);
            Invoke("CanAttack", attackCd);
            Invoke("AttackTriggerActive", attackTriggerCd);
        }
    }

    void CanAttack()
    {
        isAttacking = false;
    }

    void AttackTriggerActive()
    {

        attackTriggerDown.SetActive(false);
        attackTriggerRight.SetActive(false);
        attackTriggerUp.SetActive(false);
        attackTriggerLeft.SetActive(false);
    }


}
