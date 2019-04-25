using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEnemyController : MonoBehaviour
{
    public float speed;
    public Animator animator;

    private bool mRight = true;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.SetFloat("Speed", speed);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            if(mRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                mRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                mRight = true;
            }
        }
    }
}
