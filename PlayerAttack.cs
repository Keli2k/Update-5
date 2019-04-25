using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCooldown;
    public float startAttackCooldown;
    public Transform attackP;
    public LayerMask findEnemy;
    public float attackRange;
    public int damage;
    public Animator animator;
    void Update()
    {

        if (attackCooldown <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(attackP.position, attackRange, findEnemy);
                animator.SetTrigger("Attack");

                for (int i = 0; i < nearbyEnemies.Length; i++)
                {
                    nearbyEnemies[i].GetComponent<EnemyController>().TakeDamage(damage);
                    
                }
                attackCooldown = startAttackCooldown;
            }
             //Cooldown Between attacks

        }


        else
        {
            attackCooldown -= Time.deltaTime;

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackP.position, attackRange);
    }

}
