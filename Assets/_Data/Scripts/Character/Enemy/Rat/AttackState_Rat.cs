using UnityEngine;

public class AttackState_Rat : CharacterState
{
    private RatController enemy;
    private float lastAttackTime = -10f;

    public AttackState_Rat(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as RatController;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.EnableCollider2D(true);
    }

    public override void Exit()
    {
        base.Exit();

        enemy.EnableCollider2D(false);
    }

    public override void Update()
    {
        base.Update();

        Attack();

        enemy.DeadAnimation();

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
