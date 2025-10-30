using UnityEngine;

public class CharacterState
{
    protected Character characterBase;
    protected StateMachine stateMachine;
    protected string animBoolName;

    protected float stateTime;

    public CharacterState(Character characterBase, StateMachine stateMachine, string animBoolName)
    {
        this.characterBase = characterBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        if (animBoolName == "Dead")
        {
            characterBase.anim.SetTrigger("Dead");
            return;
        }

        characterBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        characterBase.anim.SetBool(animBoolName, false);
    }

    public virtual void Update()
    {
        stateTime -= Time.deltaTime;

        //Debug.Log("animBoolName: " + animBoolName);
    }
}
