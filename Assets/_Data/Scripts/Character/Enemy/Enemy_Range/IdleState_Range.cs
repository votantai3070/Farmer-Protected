public class IdleState_Range : CharacterState
{
    private Enemy_Range enemy;

    public IdleState_Range(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Range;
    }

    public override void Enter()
    {
        base.Enter();

        stateTime = enemy.idleTime;
        enemy.CanMove(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTime <= 0)
            stateMachine.ChangeState(enemy.moveState);
    }
}
