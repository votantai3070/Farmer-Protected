using UnityEngine;

public class IdleState_Rat : CharacterState
{
    private RatController enemy;

    public IdleState_Rat(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as RatController;
    }

    public override void Enter()
    {
        base.Enter();

        stateTime = enemy.idleTime;
        enemy.CanMove(false);
        enemy.EnableCollider2D(false);

    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();

        if (stateTime <= 0f)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
