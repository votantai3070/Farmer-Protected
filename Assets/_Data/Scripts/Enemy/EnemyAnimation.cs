using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    public void SwitchBatAnimation(string ani)
    {
        switch (ani)
        {
            case "ATTACK":
                animator.SetTrigger("Attack");
                break;
            case "FLY":
                animator.SetTrigger("Fly");
                break;
            case "DEAD":
                animator.SetTrigger("Dead");
                break;
            default:
                Debug.LogWarning("");
                break;
        }
    }

    public void SwitchSlimeAnimation(string ani)
    {
        switch (ani)
        {
            case "ATTACK":
                animator.SetTrigger("Attack");
                break;
            case "RUN":
                animator.SetTrigger("Run");
                break;
            case "DEAD":
                animator.SetTrigger("Dead");
                break;
            default:
                Debug.LogWarning("");
                break;
        }
    }
}
