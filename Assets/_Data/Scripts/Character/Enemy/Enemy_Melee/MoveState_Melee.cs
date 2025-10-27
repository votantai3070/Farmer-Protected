using System;
using UnityEngine;

public class MoveState_Melee : CharacterState
{
    private Enemy_Melee enemy;

    public MoveState_Melee(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Melee;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.CanMove(true);

    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();
        if (enemy.aIPath.reachedEndOfPath)
        {
            //Debug.Log("Switch to Attack State");
            if (enemy.enemyName == EnemyName.Undead)
                stateMachine.ChangeState(enemy.idleState);
            else
                stateMachine.ChangeState(enemy.attackState);
        }


        enemy.DeadAnimation();
    }
}
