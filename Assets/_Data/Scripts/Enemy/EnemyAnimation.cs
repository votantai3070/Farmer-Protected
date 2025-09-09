using UnityEditor.U2D.Animation;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Enemy enemy;
    public Animator animator;
    public Animator attackAnimation;

    public void SwitchBatAnimation(string ani)
    {
        switch (ani)
        {
            case "ATTACK":
                animator.SetTrigger("Attack");
                attackAnimation.SetTrigger("AttackFX");
                break;
            case "FLY":
                animator.SetTrigger("Fly");
                break;
            case "DEAD":
                animator.SetTrigger("Dead");
                break;
            case "HIT":
                animator.SetTrigger("Hit");
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
            case "HIT":
                animator.SetTrigger("Hit");
                break;
            default:
                Debug.LogWarning("");
                break;
        }
    }

    public void SwitchBoneAnimation(string ani)
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
            case "HIT":
                animator.SetTrigger("Hit");
                break;
            default:
                Debug.LogWarning("");
                break;
        }
    }

    public void SwitchRatAnimation(string ani)
    {
        switch (ani)
        {
            case "ATTACK":
                animator.SetTrigger("Attack");
                attackAnimation.SetTrigger("AttackFX");
                break;
            case "RUN":
                animator.SetTrigger("Run");
                break;
            case "DEAD":
                animator.SetTrigger("Dead");
                break;
            case "ABILITY":
                animator.SetTrigger("Ability");
                break;
            case "HIT":
                animator.SetTrigger("Hit");
                break;
            default:
                Debug.LogWarning("");
                break;
        }
    }

    public void GetAnimationHitForEnemy()
    {
        if (enemy.characterData.characterName == "Rat")
            SwitchRatAnimation("HIT");
        if (enemy.characterData.characterName == "Bat")
            SwitchBatAnimation("HIT");
        if (enemy.characterData.characterName == "Bone")
            SwitchBoneAnimation("HIT");
        if (enemy.characterData.characterName == "Slime")
            SwitchSlimeAnimation("HIT");
    }
}
