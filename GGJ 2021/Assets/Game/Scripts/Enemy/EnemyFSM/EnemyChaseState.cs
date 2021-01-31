using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : IState
{
    private EnemyController _owner;
    private Transform _target;

    public EnemyChaseState(EnemyController owner, Transform target)
    {
        _owner = owner;
        _target = target;
    }

    public void Enter()
    {
        if (!GameManager.instance.found)
        {
            SoundManager.instance.PlaySFX(1);
        }
    }

    public void Execute()
    {
        _owner.MoveTowards(_target, _owner.ActualChaseSpeed);

    }

    public void Exit()
    {

    }
}
