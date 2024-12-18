using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] float stopDistance = 1f;

    void Update()
    {
        if(playerTransform != null)
        {
            if(HasReachedPlayer())
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
        }
    }

    private bool HasReachedPlayer()
    {
        return Vector2.Distance(transform.position, playerTransform.position) > stopDistance;
    }
}
