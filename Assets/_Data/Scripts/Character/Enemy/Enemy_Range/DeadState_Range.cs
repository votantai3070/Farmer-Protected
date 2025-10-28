using UnityEngine;

public class DeadState_Range : CharacterState
{
    private Enemy_Range enemy;

    public DeadState_Range(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemyBase as Enemy_Range;
    }

    public override void Enter()
    {
        base.Enter();
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
