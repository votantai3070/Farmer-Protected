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

        enemy.CanMove(false);


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        ObjectPool.instance.DelayReturnToPool(enemy.transform.parent.gameObject, enemy.GetAnimationClipDuration("Dead"));
        enemy.spawnEnemy.ReturnEnemy(enemy.transform.parent.gameObject);
    }
}
