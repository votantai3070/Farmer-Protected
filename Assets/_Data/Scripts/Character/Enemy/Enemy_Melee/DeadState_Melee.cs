using System.Collections;
using UnityEngine;

public class DeadState_Melee : CharacterState
{
    private Enemy_Melee enemy;

    public DeadState_Melee(Enemy enemyBase, StateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Melee;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.CanMove(false);

        ObjectPool.instance.DelayReturnToPool(enemy.transform.parent.gameObject, enemy.GetAnimationClipDuration("Dead"));
        enemy.spawnEnemy.ReturnEnemy(enemy.transform.parent.gameObject);
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
