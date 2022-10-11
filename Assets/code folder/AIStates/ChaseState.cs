using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ChaseState : AIState
{
    public AttackState attackState;
    public bool isInAttackRange;
    public override AIState RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            ChasePlayer();
        }
        return this;
    }
    void ChasePlayer()
    {
        float speed = AIStateManagerpointer.speed;

        //update current target
        AIStateManagerpointer.currentTarget = AIStateManagerpointer.targets.OrderBy
            (target => Vector2.Distance(target.position, AIStateManagerpointer.transform.position)).FirstOrDefault();

        Transform currentTarget = AIStateManagerpointer.currentTarget;
        float distance = Vector2.Distance(transform.position, currentTarget.position);
        Vector2 direction = currentTarget.position - transform.position;

        AIStateManagerpointer.Enemy.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }
}
