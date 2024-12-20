using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] float stopDistance = 1f;
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] int damage = 1;
    [SerializeField] int attackSpeed = 10;

    float attackTime = 0f;

    void Update()
    {
        if(playerTransform != null)
        {
            if(!HasReachedPlayer())
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            } else if(Time.time >= attackTime)
            {
                //Coroutines are frame independent, unity will not wait in the same frame for the method to be over
                StartCoroutine(Attack());
                attackTime = Time.time + timeBetweenAttacks;
            }
        }
    }

    private bool HasReachedPlayer()
    {
        return Vector2.Distance(transform.position, playerTransform.position) < stopDistance;
    }

    private IEnumerator Attack()
    {
        playerTransform.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = playerTransform.position;

        //How much of the action alredy happened. From 0 (0%) to 1 (100%)
        float percent = 0;
        while(percent <= 1)
        {
            //AttachSpeed is used to make the action faster making the enemy position change faste feeling like a simple attack
            percent += Time.deltaTime * 1;
            //This formula goes from 0 to 1 and back to 0. This is used to make the enemy to go from a to b and then come back to a
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            //The formula is being used to find the position between a and b giving the interpolation point
            //For example if a is in 3 and b is in 6 and the formula equals 0.5 that means that the interpolated point is in 4.5,
            //bacause 0.5 means 50% so the middle of the 2 positions
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
}
