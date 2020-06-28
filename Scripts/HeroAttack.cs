using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public GameObject selectedUnit;
    EnermyController e;

    public bool canAttack;
    Animator anim;

    public float autoAttackCooldown;
    public float autoAttackCurTime;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTarget();
            FaceTarget();
        }

        if(selectedUnit != null)
        {
            Vector3 toTarget = (selectedUnit.transform.position - transform.position).normalized;

            float distance = Vector3.Distance(this.transform.position, selectedUnit.transform.position);

            if (distance < 5)
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }
        }

        if (selectedUnit != null && canAttack && e.health > 0)
        {
            if (autoAttackCurTime < autoAttackCooldown)
            {
                autoAttackCurTime += Time.deltaTime;
            }
            else
            {
                anim.SetTrigger("isAttacking");
                SoundManager.PlaySound("attack");
                Attack();
                autoAttackCurTime = 0;
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (selectedUnit.transform.position - transform.position).normalized;
        Quaternion lookRadius = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRadius, Time.deltaTime * 5f);
    }

    void SelectTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.transform.tag == "Enemy")
            {
                selectedUnit = hit.transform.gameObject;

                e = selectedUnit.transform.gameObject.transform.GetComponent<EnermyController>();
            }
        }
    }

    void Attack()
    {
        e.TakeDamage(5);
    }

}
