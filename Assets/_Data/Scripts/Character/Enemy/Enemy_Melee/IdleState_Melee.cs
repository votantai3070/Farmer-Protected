public class IdleState_Melee : CharacterState
{
    private Enemy_Melee enemy;

    public IdleState_Melee(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Melee;
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
