using UnityEngine;

public class AttackState_Range : CharacterState
{
    private Enemy_Range enemy;
    private float lastAttackTime = -10f;

    public AttackState_Range(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Range;
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

        Attack();
    }

    private void Attack()
    {
        float attackAnimDuration = enemy.GetAnimationClipDuration("Attack");

        if (Time.time >= lastAttackTime + attackAnimDuration + enemy.attackCooldown)
        {
            lastAttackTime = Time.time;
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
