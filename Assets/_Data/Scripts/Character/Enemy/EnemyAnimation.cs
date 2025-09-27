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
                if (attackAnimation != null)
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
                if (attackAnimation != null)
                    attackAnimation.SetTrigger("AttackFX");
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
                if (attackAnimation != null)
                    attackAnimation.SetTrigger("AttackFX");
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
                if (attackAnimation != null)
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
    public void SwitchUndeadAnimation(string ani)
    {
        switch (ani)
        {
            //case "ATTACK":
            //    animator.SetTrigger("Attack");
            //    if (attackAnimation != null)
            //        attackAnimation.SetTrigger("AttackFX");
            //    break;
            //case "RUN":
            //    animator.SetTrigger("Run");
            //    break;
            case "DEAD":
                animator.SetTrigger("Dead");
                break;
            //case "ABILITY":
            //    animator.SetTrigger("Ability");
            //    break;
            case "HIT":
                animator.SetTrigger("Hit");
                break;
            default:
                Debug.LogWarning("");
                break;
        }
    }

    public void SwitchGolemAnimation(string ani)
    {
        switch (ani)
        {
            case "ATTACK_A":
                animator.SetTrigger("AttackA");
                if (attackAnimation != null)
                    attackAnimation.SetTrigger("AttackAFX");
                break;
            case "ATTACK_B":
                animator.SetTrigger("AttackB");
                if (attackAnimation != null)
                    attackAnimation.SetTrigger("AttackBFX");
                break;
            case "ATTACK_C":
                animator.SetTrigger("AttackC");
                if (attackAnimation != null)
                    attackAnimation.SetTrigger("AttackCFX");
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
        else if (enemy.characterData.characterName == "Bat")
            SwitchBatAnimation("HIT");
        else if (enemy.characterData.characterName == "Bone")
            SwitchBoneAnimation("HIT");
        else if (enemy.characterData.characterName == "Slime")
            SwitchSlimeAnimation("HIT");
        else if (enemy.characterData.characterName == "Golem")
            SwitchGolemAnimation("HIT");
        else if (enemy.characterData.characterName == "Undead")
            SwitchUndeadAnimation("HIT");
    }
}
