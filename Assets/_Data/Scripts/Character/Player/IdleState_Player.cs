using UnityEngine;

public class IdleState_Player : CharacterState
{
    private PlayerController player;

    public IdleState_Player(PlayerController playerBase, StateMachine stateMachine, string animBoolName) : base(playerBase, stateMachine, animBoolName)
    {
        player = playerBase;
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

        if (InputManager.Instance.MoveInput.magnitude > 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
