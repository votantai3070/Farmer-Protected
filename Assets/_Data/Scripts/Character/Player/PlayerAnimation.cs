using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public InputManager inputManager;
    public PlayerController player;

    Vector2 lastMoveDir;

    private void Update()
    {
        if (player.isAttacked) return;
        //UpdateMoveAnimation(inputManager.MoveInput);
        //UpdateLastMoveDir();
    }

    //private void UpdateLastMoveDir()
    //{
    //    if (inputManager.MoveInput.x != 0 || inputManager.MoveInput.y != 0)
    //    {
    //        lastMoveDir = inputManager.MoveInput;
    //    }
    //    //SwitchAnimationState("IDLE");
    //}

    //private void UpdateMoveAnimation(Vector2 moveInput)
    //{
    //    animator.SetFloat("x", moveInput.x);
    //    animator.SetFloat("y", moveInput.y);
    //}

    public void SwitchAnimationState(string state)
    {
        switch (state)
        {
            //case "IDLE":
            //    animator.SetFloat("lastMoveX", lastMoveDir.x);
            //    animator.SetFloat("lastMoveY", lastMoveDir.y);
            //    break;
            //case "WALK":
            //    animator.SetBool("Walk", inputManager.MoveInput.magnitude > 0);
            //    break;
            //case "BOW":
            //    animator.SetTrigger("Bow");
            //    break;
            //case "SLASH":
            //    animator.SetTrigger("Slash");
            //    break;
            //case "THROW":
            //    animator.SetTrigger("Throw");
            //    break;
            //case "DAMAGE":
            //    animator.SetTrigger("Damage");
            //    break;  
            case "RUN":
                animator.SetFloat("Run", inputManager.MoveInput.magnitude);
                break;
            case "DEAD":
                animator.SetTrigger("Dead");
                break;
            default:
                Debug.LogWarning("Unknown animation state: " + state);
                break;
        }
    }
}
