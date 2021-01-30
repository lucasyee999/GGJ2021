using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : IState
{
    private EnemyController _owner;

    private int currentPatrolPoint;

    public EnemyPatrolState(EnemyController owner)
    {
        _owner = owner;
    }

    public void Enter()
    {
        currentPatrolPoint = 0;
        float closestDistance = Vector2.Distance(_owner.transform.position, _owner.PatrolPoints[0].position);
        for(int i = 1; i < _owner.PatrolPoints.Length; ++i)
        {
            if(Vector2.Distance(_owner.PatrolPoints[i].position, _owner.transform.position) < closestDistance)
            {
                currentPatrolPoint = i;
                closestDistance = Vector2.Distance(_owner.PatrolPoints[i].position, _owner.transform.position);
            }
        }
    }

    public void Execute()
    {
        if (Vector2.Distance(_owner.PatrolPoints[currentPatrolPoint].position, _owner.transform.position) < 0.1f)
        {
            // if its the last patrol point
            if(currentPatrolPoint == _owner.PatrolPoints.Length - 1)
            {
                currentPatrolPoint = 0;
            }
            else
            {
                currentPatrolPoint++;
            }
        }
        _owner.MoveTowards(_owner.PatrolPoints[currentPatrolPoint], _owner.PatrolMovementSpeed);

    }

    public void Exit()
    {

    }
}
