using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public InputManager inputManager;
    public PlayerController player;

    private void Update()
    {
        if (player.isAttacked) return;
    }

    public void SwitchAnimationState(string state)
    {
        switch (state)
        {
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
