using System.Collections;
using UnityEngine;

public class DeadState_Rat : CharacterState
{
    private RatController enemy;

    public DeadState_Rat(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as RatController;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.CanMove(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

    }

}
