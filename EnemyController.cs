using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected float speed = 3.0f;
    public Transform player;
    public int health = 2;
    private Transform target;
    public Animator animator;
    private DEnemyController patrol;
    public float eSAttackCD;
    private float eAttackCD;
    public Transform eAttackP;
    public LayerMask findPlayer;
    public float eAttackRange;
    public int eDamage;
    
    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        patrol = GetComponent<DEnemyController>();
        
    }

    // Update is called once per frame

    void Update()
    {
        if (target != null)
        {
            FollowTarget();
            transform.eulerAngles = new Vector3(0, -180, 0);
            if (eAttackCD <= 0)
            {
                
                animator.SetTrigger("eAttack");
                Collider2D[] targetPlayer = Physics2D.OverlapCircleAll(eAttackP.position, eAttackRange, findPlayer);
                

                for (int i = 0; i < targetPlayer.Length; i++)
                {
                    targetPlayer[i].GetComponent<PlayerHealth>().takeDamage(eDamage);

                }

                eAttackCD = eSAttackCD;
            }
            else
            {
                eAttackCD -= Time.deltaTime;
            }
        }

       
        
        
    }
    


    

    public void TakeDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    
        void Die()
        {
            Destroy(gameObject);
        }
        

   
            void FollowTarget()
    {
        if (target != null)
        {
            
            patrol.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetFloat("Speed", speed);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(eAttackP.position, eAttackRange);
    }

}

