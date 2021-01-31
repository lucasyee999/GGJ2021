using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState
{
    private EnemyController _owner;
    private float _idleTime;

    public EnemyIdleState(EnemyController owner)
    {
        _owner = owner;
    }

    public void Enter()
    {
        _idleTime = Random.Range(_owner.MinIdleTime, _owner.MaxIdleTime);
    }

    public void Execute()
    {
        _idleTime -= Time.deltaTime;

        if (_idleTime <= 0)
        {
            _owner.stateMachine.ChangeState(new EnemyPatrolState(_owner));
        }


    }

    public void Exit()
    {

    }
}
