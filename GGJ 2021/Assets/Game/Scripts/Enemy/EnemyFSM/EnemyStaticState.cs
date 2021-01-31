using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaticState : IState
{
    private EnemyController _owner;

    private float timer = 0.0f;
    private float randomInterval;

    public EnemyStaticState(EnemyController owner)
    {
        _owner = owner;
    }

    public void Enter()
    {
        this.timer = 0.0f;
        this.randomInterval = Random.Range(2.0f, 5.0f);
    }

    public void Execute()
    {
        this.timer += Time.deltaTime;
        if (this.timer > this.randomInterval)
        {
            _owner.FlipSideways();
            this.timer = 0.0f;
            this.randomInterval = Random.Range(2.0f, 5.0f);
        }
    }

    public void Exit()
    {
        this.timer = 0.0f;
    }
}
