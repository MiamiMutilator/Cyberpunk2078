using UnityEngine;
using System.Collections;


public class KillSword : MonoBehaviour
{
    private Animator anim;
    public bool attacked;
    public bool canAttack;
    private Collider SwordHitBox;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwordHitBox = GetComponent<Collider>();
        SwordHitBox.enabled = false;
        anim = GetComponentInParent<Animator>();
        attacked = false;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (attacked == false && canAttack == true)
            {
                anim.SetTrigger("Attack1");
                StartCoroutine(AttackCooldown());
                StartCoroutine(AttackTransition());
            }
            if (attacked == true && canAttack == true)
            {
                anim.SetTrigger("Attack2");
                StartCoroutine(AttackCooldown());
                attacked = false;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<EnemyController>().Kill();
        }
    }

    private IEnumerator AttackTransition()
    {
        attacked = true;
        yield return new WaitForSeconds(1);
        attacked = false;
        yield break;
    }
    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        SwordHitBox.enabled = true;
        yield return new WaitForSeconds(0.4f);
        canAttack = true;
        SwordHitBox.enabled = false;
        yield break;

    }
}
