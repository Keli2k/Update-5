using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{

    private EnemyController parent;

    private void Start()
    {
        parent = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Player")
        {
            parent.Target = collison.transform;
        }
    }
}
