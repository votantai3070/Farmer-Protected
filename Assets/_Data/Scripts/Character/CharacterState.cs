using UnityEngine;

public class CharacterState
{
    protected Enemy enemyBase;
    protected StateMachine stateMachine;
    protected string animBoolName;

    protected float stateTime;

    public CharacterState(Enemy enemyBase, StateMachine stateMachine, string animBoolName)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        enemyBase.anim.SetBool(animBoolName, true);

        if (animBoolName == "Dead")
            enemyBase.anim.SetTrigger("Dead");
    }

    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);
    }

    public virtual void Update()
    {
        stateTime -= Time.deltaTime;
    }
}
