using UnityEngine;

public class MoveState_Player : CharacterState
{
    private PlayerController player;

    public MoveState_Player(Character characterBase, StateMachine stateMachine, string animBoolName) : base(characterBase, stateMachine, animBoolName)
    {
        player = characterBase as PlayerController;
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

        HandleMovement();

        if (InputManager.Instance.MoveInput.magnitude == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    private void HandleMovement()
    {
        player.rb.linearVelocity = InputManager.Instance.MoveInput * player.settings.speed;
    }
}
