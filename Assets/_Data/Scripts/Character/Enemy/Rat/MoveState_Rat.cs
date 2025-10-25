using UnityEngine;

public class MoveState_Rat : CharacterState
{
    private RatController enemy;

    public MoveState_Rat(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as RatController;
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
            stateMachine.ChangeState(enemy.attackState);
        }


        enemy.DeadAnimation();
    }
}
