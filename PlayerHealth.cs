using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public Animator animator;
    public int health = 5;
    public int lives = 1;
    

    void Update()
    {
       
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            health -= 1;
            animator.SetTrigger("Hit");
            
        }

        if (health <= 0 && lives > 0)
        {
            Respawn();
            
        }
        //if (other.CompareTag("1up"))
        //{
            //lives += 1;
        //}

    }
    public void takeDamage(int eDamage)
    {
        health -= 1;
    }


    void Respawn()
    {
        player.transform.position = respawnPoint.position;
        lives -= 1;
        health = 2;
        if (lives == 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        animator.SetTrigger("Death");
        Time.timeScale = 0f;
    }
}
